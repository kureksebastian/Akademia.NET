namespace StudentsDiary
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAdd = new System.Windows.Forms.Button();
            this.bthEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.bthRefresh = new System.Windows.Forms.Button();
            this.dgvDiary = new System.Windows.Forms.DataGridView();
            this.cbGroupIdSort = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiary)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Lime;
            this.btnAdd.Location = new System.Drawing.Point(12, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Dodaj";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // bthEdit
            // 
            this.bthEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.bthEdit.Location = new System.Drawing.Point(106, 12);
            this.bthEdit.Name = "bthEdit";
            this.bthEdit.Size = new System.Drawing.Size(75, 23);
            this.bthEdit.TabIndex = 1;
            this.bthEdit.Text = "Edit";
            this.bthEdit.UseVisualStyleBackColor = false;
            this.bthEdit.Click += new System.EventHandler(this.bthEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(198, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Usuń";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // bthRefresh
            // 
            this.bthRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.bthRefresh.Location = new System.Drawing.Point(294, 12);
            this.bthRefresh.Name = "bthRefresh";
            this.bthRefresh.Size = new System.Drawing.Size(75, 23);
            this.bthRefresh.TabIndex = 3;
            this.bthRefresh.Text = "Odśwież";
            this.bthRefresh.UseVisualStyleBackColor = false;
            this.bthRefresh.Click += new System.EventHandler(this.bthRefresh_Click);
            // 
            // dgvDiary
            // 
            this.dgvDiary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDiary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDiary.BackgroundColor = System.Drawing.Color.White;
            this.dgvDiary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiary.Location = new System.Drawing.Point(12, 57);
            this.dgvDiary.Name = "dgvDiary";
            this.dgvDiary.RowHeadersVisible = false;
            this.dgvDiary.RowTemplate.Height = 25;
            this.dgvDiary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiary.Size = new System.Drawing.Size(928, 311);
            this.dgvDiary.TabIndex = 4;
            // 
            // cbGroupIdSort
            // 
            this.cbGroupIdSort.FormattingEnabled = true;
            this.cbGroupIdSort.Location = new System.Drawing.Point(401, 12);
            this.cbGroupIdSort.Name = "cbGroupIdSort";
            this.cbGroupIdSort.Size = new System.Drawing.Size(138, 23);
            this.cbGroupIdSort.TabIndex = 5;
            this.cbGroupIdSort.Text = "Wszyscy";
            // 
            // Main
            // 
            this.ClientSize = new System.Drawing.Size(952, 385);
            this.Controls.Add(this.cbGroupIdSort);
            this.Controls.Add(this.dgvDiary);
            this.Controls.Add(this.bthRefresh);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.bthEdit);
            this.Controls.Add(this.btnAdd);
            this.Name = "Main";
            this.Text = "Dziennik";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnAdd;
        private Button bthEdit;
        private Button btnDelete;
        private Button bthRefresh;
        private DataGridView dgvDiary;
        private ComboBox cbGroupIdSort;
    }
}