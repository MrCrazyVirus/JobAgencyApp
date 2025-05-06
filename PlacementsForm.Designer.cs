namespace EmploymentAgency
{
    partial class PlacementsForm
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
            this.dgvPlacements = new System.Windows.Forms.DataGridView();
            this.lblJobSeeker = new System.Windows.Forms.Label();
            this.lblVacancy = new System.Windows.Forms.Label();
            this.lblPlacementDate = new System.Windows.Forms.Label();
            this.cbJobSeeker = new System.Windows.Forms.ComboBox();
            this.cbVacancy = new System.Windows.Forms.ComboBox();
            this.dtpPlacementDate = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlacements)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPlacements
            // 
            this.dgvPlacements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlacements.Location = new System.Drawing.Point(12, 12);
            this.dgvPlacements.Name = "dgvPlacements";
            this.dgvPlacements.ReadOnly = true;
            this.dgvPlacements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlacements.Size = new System.Drawing.Size(776, 200);
            this.dgvPlacements.TabIndex = 0;
            this.dgvPlacements.SelectionChanged += new System.EventHandler(this.dgvPlacements_SelectionChanged);
            // 
            // lblJobSeeker
            // 
            this.lblJobSeeker.AutoSize = true;
            this.lblJobSeeker.Location = new System.Drawing.Point(12, 230);
            this.lblJobSeeker.Name = "lblJobSeeker";
            this.lblJobSeeker.Size = new System.Drawing.Size(66, 13);
            this.lblJobSeeker.TabIndex = 1;
            this.lblJobSeeker.Text = "Соискатель:*";
            // 
            // lblVacancy
            // 
            this.lblVacancy.AutoSize = true;
            this.lblVacancy.Location = new System.Drawing.Point(12, 260);
            this.lblVacancy.Name = "lblVacancy";
            this.lblVacancy.Size = new System.Drawing.Size(55, 13);
            this.lblVacancy.TabIndex = 2;
            this.lblVacancy.Text = "Вакансия:*";
            // 
            // lblPlacementDate
            // 
            this.lblPlacementDate.AutoSize = true;
            this.lblPlacementDate.Location = new System.Drawing.Point(12, 290);
            this.lblPlacementDate.Name = "lblPlacementDate";
            this.lblPlacementDate.Size = new System.Drawing.Size(89, 13);
            this.lblPlacementDate.TabIndex = 3;
            this.lblPlacementDate.Text = "Дата размещения:";
            // 
            // cbJobSeeker
            // 
            this.cbJobSeeker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbJobSeeker.Location = new System.Drawing.Point(120, 227);
            this.cbJobSeeker.Name = "cbJobSeeker";
            this.cbJobSeeker.Size = new System.Drawing.Size(200, 21);
            this.cbJobSeeker.TabIndex = 4;
            // 
            // cbVacancy
            // 
            this.cbVacancy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVacancy.Location = new System.Drawing.Point(120, 257);
            this.cbVacancy.Name = "cbVacancy";
            this.cbVacancy.Size = new System.Drawing.Size(200, 21);
            this.cbVacancy.TabIndex = 5;
            // 
            // dtpPlacementDate
            // 
            this.dtpPlacementDate.Location = new System.Drawing.Point(120, 287);
            this.dtpPlacementDate.Name = "dtpPlacementDate";
            this.dtpPlacementDate.Size = new System.Drawing.Size(200, 20);
            this.dtpPlacementDate.TabIndex = 6;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(350, 227);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(350, 257);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 23);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Обновить";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(350, 287);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(350, 384);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 23);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // PlacementsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dtpPlacementDate);
            this.Controls.Add(this.cbVacancy);
            this.Controls.Add(this.cbJobSeeker);
            this.Controls.Add(this.lblPlacementDate);
            this.Controls.Add(this.lblVacancy);
            this.Controls.Add(this.lblJobSeeker);
            this.Controls.Add(this.dgvPlacements);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "PlacementsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление размещениями - Кадровое агентство";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlacements)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvPlacements;
        private System.Windows.Forms.Label lblJobSeeker;
        private System.Windows.Forms.Label lblVacancy;
        private System.Windows.Forms.Label lblPlacementDate;
        private System.Windows.Forms.ComboBox cbJobSeeker;
        private System.Windows.Forms.ComboBox cbVacancy;
        private System.Windows.Forms.DateTimePicker dtpPlacementDate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnBack;
    }
}