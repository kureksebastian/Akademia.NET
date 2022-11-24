using System.Data;

namespace StudentsDiary
{
    public partial class AddEditStudent : Form
    {
        private FileHelper<List<Student>> _fileHelper = new FileHelper<List<Student>>(Program.FilePath);

        private int _studnetId;
        private Student _student;
        private List<Group> _groups;

        public AddEditStudent(int id = 0)
        {
            InitializeComponent();
            _groups = GroupsHelper.GetGroups("Brak");
            InitGroupsCombobox();
            tbFirstName.Select();

            _studnetId = id;
            GetStudentData();
        }

        private void InitGroupsCombobox()
        {
            cbGroupId.DataSource = _groups;
            cbGroupId.DisplayMember = "Name";
            cbGroupId.ValueMember = "Id";
        }

        private void GetStudentData()
        {
            if (_studnetId != 0)
            {
                Text = "Edytowanie ucznia";
                var students = _fileHelper.DeserializeFromFile();
                _student = students.FirstOrDefault(x => x.Id == _studnetId);

                if (_student == null)
                {
                    throw new Exception("Brak studenta o danym id");
                }
                FillTextBoxes();
            }
        }

        private void FillTextBoxes()
        {
            tbId.Text = _student.Id.ToString();
            tbFirstName.Text = _student.FirstName;
            tbLastName.Text = _student.LastName;
            tbPolish.Text = _student.PolishLang;
            tbForeign.Text = _student.ForeigLang;
            tbMath.Text = _student.Math;
            tbPhisics.Text = _student.Physics;
            tbTechnology.Text = _student.Technology;
            rtbComments.Text = _student.Comments;
            cbIsAdditonalClasses.Checked = _student.IsAdditonalClasses;
            cbGroupId.SelectedItem = _groups.FirstOrDefault(x => x.Id == _student.GroupId);
        }

        private void bthConfirm_Click(object sender, EventArgs e)
        {
            var students = _fileHelper.DeserializeFromFile();    

            if(_studnetId != 0)
            {
                students.RemoveAll(x => x.Id == _studnetId);
            }
            else
            {
                AssignIdToNewStudent(students);
            }

            AddNewStudenToList(students);

            _fileHelper.SerializeToFile(students);

            Close();
        }

        private void AddNewStudenToList(List<Student> students)
        {
            var student = new Student
            {
                Id = _studnetId,
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                Comments = rtbComments.Text,
                ForeigLang = tbForeign.Text,
                PolishLang = tbPolish.Text,
                Math = tbMath.Text,
                Physics = tbPhisics.Text,
                Technology = tbTechnology.Text,
                IsAdditonalClasses = cbIsAdditonalClasses.Checked,
                GroupId = (cbGroupId.SelectedItem as Group).Id
            };

            students.Add(student);
        }

        private void AssignIdToNewStudent(List<Student> students)
        {
            var studentWithHighestId = students.OrderByDescending(x => x.Id).FirstOrDefault();

            _studnetId = studentWithHighestId == null ? 1 : studentWithHighestId.Id + 1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
