namespace EmploymentAgency
{
    partial class VacanciesForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvVacancies = new System.Windows.Forms.DataGridView();
            this.lblEmployer = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblSalary = new System.Windows.Forms.Label();
            this.lblIsFilled = new System.Windows.Forms.Label();
            this.cbEmployer = new System.Windows.Forms.ComboBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.chkIsFilled = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVacancies)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVacancies
            // 
            this.dgvVacancies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVacancies.Location = new System.Drawing.Point(12, 12);
            this.dgvVacancies.Name = "dgvVacancies";
            this.dgvVacancies.ReadOnly = true;
            this.dgvVacancies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVacancies.Size = new System.Drawing.Size(776, 200);
            this.dgvVacancies.TabIndex = 0;
            this.dgvVacancies.SelectionChanged += new System.EventHandler(this.dgvVacancies_SelectionChanged);
            // 
            // lblEmployer
            // 
            this.lblEmployer.AutoSize = true;
            this.lblEmployer.Location = new System.Drawing.Point(12, 230);
            this.lblEmployer.Name = "lblEmployer";
            this.lblEmployer.Size = new System.Drawing.Size(79, 13);
            this.lblEmployer.TabIndex = 1;
            this.lblEmployer.Text = "Работодатель:*";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 260);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(92, 13);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Название вакансии:*";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 290);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(56, 13);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Описание:";
            // 
            // lblSalary
            // 
            this.lblSalary.AutoSize = true;
            this.lblSalary.Location = new System.Drawing.Point(12, 350);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(57, 13);
            this.lblSalary.TabIndex = 4;
            this.lblSalary.Text = "Зарплата:";
            // 
            // lblIsFilled
            // 
            this.lblIsFilled.AutoSize = true;
            this.lblIsFilled.Location = new System.Drawing.Point(12, 380);
            this.lblIsFilled.Name = "lblIsFilled";
            this.lblIsFilled.Size = new System.Drawing.Size(67, 13);
            this.lblIsFilled.TabIndex = 5;
            this.lblIsFilled.Text = "Заполнена:";
            // 
            // cbEmployer
            // 
            this.cbEmployer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmployer.Location = new System.Drawing.Point(120, 227);
            this.cbEmployer.Name = "cbEmployer";
            this.cbEmployer.Size = new System.Drawing.Size(200, 21);
            this.cbEmployer.TabIndex = 6;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(120, 257);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(200, 20);
            this.txtTitle.TabIndex = 7;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(120, 287);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 60);
            this.txtDescription.TabIndex = 8;
            // 
            // txtSalary
            // 
            this.txtSalary.Location = new System.Drawing.Point(120, 347);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(200, 20);
            this.txtSalary.TabIndex = 9;
            // 
            // chkIsFilled
            // 
            this.chkIsFilled.AutoSize = true;
            this.chkIsFilled.Location = new System.Drawing.Point(120, 380);
            this.chkIsFilled.Name = "chkIsFilled";
            this.chkIsFilled.Size = new System.Drawing.Size(15, 14);
            this.chkIsFilled.TabIndex = 10;
            this.chkIsFilled.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(350, 227);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 23);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(350, 257);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 23);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Обновить";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(350, 287);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 23);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(350, 384);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 23);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // VacanciesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.chkIsFilled);
            this.Controls.Add(this.txtSalary);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.cbEmployer);
            this.Controls.Add(this.lblIsFilled);
            this.Controls.Add(this.lblSalary);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblEmployer);
            this.Controls.Add(this.dgvVacancies);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "VacanciesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление вакансиями - Кадровое агентство";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVacancies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvVacancies;
        private System.Windows.Forms.Label lblEmployer;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.Label lblIsFilled;
        private System.Windows.Forms.ComboBox cbEmployer;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.CheckBox chkIsFilled;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnBack;
    }
}