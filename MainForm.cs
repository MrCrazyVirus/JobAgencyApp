using System;
using System.Windows.Forms;

namespace EmploymentAgency
{
    public partial class MainForm : Form
    {
        private readonly string userRole;

        public MainForm(string role)
        {
            InitializeComponent();
            userRole = role;
            ConfigureMenu();
        }

        private void ConfigureMenu()
        {
            if (userRole != "admin")
            {
                mnuUsers.Visible = false;
            }
        }

        private void mnuJobSeekers_Click(object sender, EventArgs e)
        {
            JobSeekersForm form = new JobSeekersForm();
            form.ShowDialog();
        }

        private void mnuEmployers_Click(object sender, EventArgs e)
        {
            EmployersForm form = new EmployersForm();
            form.ShowDialog();
        }

        private void mnuVacancies_Click(object sender, EventArgs e)
        {
            VacanciesForm form = new VacanciesForm();
            form.ShowDialog();
        }

        private void mnuPlacements_Click(object sender, EventArgs e)
        {
            PlacementsForm form = new PlacementsForm();
            form.ShowDialog();
        }

        private void mnuUsers_Click(object sender, EventArgs e)
        {
            if (userRole == "admin")
            {
                UserManagementForm form = new UserManagementForm();
                form.ShowDialog();
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}