namespace StudentsDiary
{
    public partial class Main : Form
    {
        private FileHelper<List<Student>> _fileHelper = new FileHelper<List<Student>>(Program.FilePath);
        private List<Group> _groups;

        public Main()
        {
            InitializeComponent();
            _groups = GroupsHelper.GetGroups("Wszyscy");
            InitGroupsCombobox();
            RefreshDiary();
            SetColumnsHeader();
            HideColumns();

        }

        private void InitGroupsCombobox()
        {
            cbGroupIdSort.DataSource = _groups;
            cbGroupIdSort.DisplayMember = "Name";
            cbGroupIdSort.ValueMember = "Id";
        }

        private void HideColumns()
        {
            dgvDiary.Columns[nameof(Student.GroupId)].Visible = false;
        }

        private void RefreshDiary()
        {
            var students = _fileHelper.DeserializeFromFile();
            dgvDiary.DataSource = students;
        }

        private void SetColumnsHeader()
        {
            dgvDiary.Columns[0].HeaderText = "Numer";
            dgvDiary.Columns[1].HeaderText = "Imiê";
            dgvDiary.Columns[2].HeaderText = "Nazwisko";
            dgvDiary.Columns[3].HeaderText = "Uwagi";
            dgvDiary.Columns[4].HeaderText = "Matematyka";
            dgvDiary.Columns[5].HeaderText = "Technologia";
            dgvDiary.Columns[6].HeaderText = "Fizyka";
            dgvDiary.Columns[7].HeaderText = "J. Polski";
            dgvDiary.Columns[8].HeaderText = "J. Obcy";
            dgvDiary.Columns[9].HeaderText = "D. Zajecia";
            dgvDiary.Columns[10].HeaderText = "Numer Grupy";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addEditStudent = new AddEditStudent();
            addEditStudent.FormClosing += AddEditStudent_FormClosing;
            addEditStudent.ShowDialog();
        }

        private void AddEditStudent_FormClosing(object? sender, FormClosingEventArgs e)
        {
            RefreshDiary();
        }

        private void bthEdit_Click(object sender, EventArgs e)
        {
            if(dgvDiary.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zazacz ucznia do edycji.");

                return;
            }

            var addEditStudent = new AddEditStudent(
                Convert.ToInt32(dgvDiary.SelectedRows[0].Cells[0].Value));
            addEditStudent.FormClosing += AddEditStudent_FormClosing;
            addEditStudent.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDiary.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zazacz ucznia do usuniecia.");

                return;
            }

            var selectedStudent = dgvDiary.SelectedRows[0];

            var confirmDelete = MessageBox.Show(
                $"Czy usunac ucznia {(selectedStudent.Cells[1].Value.ToString() + " " + selectedStudent.Cells[2].Value.ToString()).Trim()}",
                "Usuwanie", MessageBoxButtons.OKCancel);

            if(confirmDelete == DialogResult.OK)
            {
                DeleteStudent(Convert.ToInt32(selectedStudent.Cells[0].Value));
                RefreshDiary();
            }
        }

        private void DeleteStudent(int id)
        {
            var students = _fileHelper.DeserializeFromFile();
            students.RemoveAll(x => x.Id == id);
            _fileHelper.SerializeToFile(students);
        }

        private void bthRefresh_Click(object sender, EventArgs e)
        {
            var students = _fileHelper.DeserializeFromFile();
            var selectedGroupId = (cbGroupIdSort.SelectedItem as Group).Id;

            if (selectedGroupId != 0)
            {
                students = students.Where(x => x.GroupId == selectedGroupId).ToList();
                dgvDiary.DataSource = students;
            }
            dgvDiary.DataSource = students;
        }
    }
}