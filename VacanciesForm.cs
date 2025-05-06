using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace EmploymentAgency
{
    public partial class VacanciesForm : Form
    {
        private readonly string connectionString = "Data Source=employment.db;Version=3;";
        private DataTable dataTable;

        public VacanciesForm()
        {
            InitializeComponent();
            LoadEmployers();
            LoadVacancies();
        }

        private void LoadEmployers()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT EmployerID, CompanyName FROM Employers";
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        cbEmployer.DataSource = dt;
                        cbEmployer.DisplayMember = "CompanyName";
                        cbEmployer.ValueMember = "EmployerID";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки работодателей: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadVacancies()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT v.VacancyID, v.EmployerID, e.CompanyName, v.Title, v.Description, v.Salary, v.IsFilled " +
                                   "FROM Vacancies v LEFT JOIN Employers e ON v.EmployerID = e.EmployerID";
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn))
                    {
                        dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvVacancies.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            double salary;
            if (!double.TryParse(txtSalary.Text.Trim(), out salary) && !string.IsNullOrEmpty(txtSalary.Text.Trim()))
            {
                MessageBox.Show("Зарплата должна быть числом.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Vacancies (EmployerID, Title, Description, Salary, IsFilled) VALUES (@employerID, @title, @description, @salary, @isFilled)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@employerID", cbEmployer.SelectedValue);
                        cmd.Parameters.AddWithValue("@title", txtTitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@description", txtDescription.Text.Trim());
                        cmd.Parameters.AddWithValue("@salary", string.IsNullOrEmpty(txtSalary.Text) ? (object)DBNull.Value : salary);
                        cmd.Parameters.AddWithValue("@isFilled", chkIsFilled.Checked ? 1 : 0);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Вакансия добавлена успешно.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadVacancies();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvVacancies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите вакансию для редактирования.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInput()) return;

            double salary;
            if (!double.TryParse(txtSalary.Text.Trim(), out salary) && !string.IsNullOrEmpty(txtSalary.Text.Trim()))
            {
                MessageBox.Show("Зарплата должна быть числом.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvVacancies.SelectedRows[0].Cells["VacancyID"].Value);
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Vacancies SET EmployerID = @employerID, Title = @title, Description = @description, Salary = @salary, IsFilled = @isFilled WHERE VacancyID = @id";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@employerID", cbEmployer.SelectedValue);
                        cmd.Parameters.AddWithValue("@title", txtTitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@description", txtDescription.Text.Trim());
                        cmd.Parameters.AddWithValue("@salary", string.IsNullOrEmpty(txtSalary.Text) ? (object)DBNull.Value : salary);
                        cmd.Parameters.AddWithValue("@isFilled", chkIsFilled.Checked ? 1 : 0);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Данные вакансии обновлены.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadVacancies();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvVacancies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите вакансию для удаления.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Вы уверены, что хотите удалить эту вакансию?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvVacancies.SelectedRows[0].Cells["VacancyID"].Value);
                try
                {
                    using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Vacancies WHERE VacancyID = @id";
                        using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Вакансия удалена.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadVacancies();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvVacancies_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVacancies.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvVacancies.SelectedRows[0];
                object employerId = row.Cells["EmployerID"].Value;
                if (employerId != DBNull.Value)
                {
                    cbEmployer.SelectedValue = employerId;
                }
                else
                {
                    cbEmployer.SelectedIndex = -1; // Сбрасываем выбор, если работодатель не указан
                }
            }
        }

        private bool ValidateInput()
        {
            if (cbEmployer.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Поля Работодатель и Название вакансии обязательны для заполнения.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ClearInputs()
        {
            cbEmployer.SelectedIndex = -1;
            txtTitle.Clear();
            txtDescription.Clear();
            txtSalary.Clear();
            chkIsFilled.Checked = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}