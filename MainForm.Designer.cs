namespace EmploymentAgency
{
    partial class MainForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuJobSeekers = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmployers = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVacancies = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPlacements = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuJobSeekers,
            this.mnuEmployers,
            this.mnuVacancies,
            this.mnuPlacements,
            this.mnuUsers,
            this.mnuExit});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // mnuJobSeekers
            // 
            this.mnuJobSeekers.Name = "mnuJobSeekers";
            this.mnuJobSeekers.Size = new System.Drawing.Size(98, 20);
            this.mnuJobSeekers.Text = "Поиск работы";
            this.mnuJobSeekers.Click += new System.EventHandler(this.mnuJobSeekers_Click);
            // 
            // mnuEmployers
            // 
            this.mnuEmployers.Name = "mnuEmployers";
            this.mnuEmployers.Size = new System.Drawing.Size(95, 20);
            this.mnuEmployers.Text = "Работодатели";
            this.mnuEmployers.Click += new System.EventHandler(this.mnuEmployers_Click);
            // 
            // mnuVacancies
            // 
            this.mnuVacancies.Name = "mnuVacancies";
            this.mnuVacancies.Size = new System.Drawing.Size(71, 20);
            this.mnuVacancies.Text = "Вакансии";
            this.mnuVacancies.Click += new System.EventHandler(this.mnuVacancies_Click);
            // 
            // mnuPlacements
            // 
            this.mnuPlacements.Name = "mnuPlacements";
            this.mnuPlacements.Size = new System.Drawing.Size(89, 20);
            this.mnuPlacements.Text = "Размещения";
            this.mnuPlacements.Click += new System.EventHandler(this.mnuPlacements_Click);
            // 
            // mnuUsers
            // 
            this.mnuUsers.Name = "mnuUsers";
            this.mnuUsers.Size = new System.Drawing.Size(97, 20);
            this.mnuUsers.Text = "Пользователи";
            this.mnuUsers.Click += new System.EventHandler(this.mnuUsers_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(54, 20);
            this.mnuExit.Text = "Выход";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Кадровое агентство - Главное меню";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuJobSeekers;
        private System.Windows.Forms.ToolStripMenuItem mnuEmployers;
        private System.Windows.Forms.ToolStripMenuItem mnuVacancies;
        private System.Windows.Forms.ToolStripMenuItem mnuPlacements;
        private System.Windows.Forms.ToolStripMenuItem mnuUsers;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
    }
}