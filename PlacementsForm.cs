using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace EmploymentAgency
{
    public partial class PlacementsForm : Form
    {
        private readonly string connectionString = "Data Source=employment.db;Version=3;";
        private DataTable dataTable;

        public PlacementsForm()
        {
            InitializeComponent();
            LoadJobSeekers();
            LoadVacancies();
            LoadPlacements();
        }

        private void LoadJobSeekers()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT JobSeekerID, FirstName || ' ' || LastName AS FullName FROM JobSeekers";
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        cbJobSeeker.DataSource = dt;
                        cbJobSeeker.DisplayMember = "FullName";
                        cbJobSeeker.ValueMember = "JobSeekerID";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки соискателей: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadVacancies()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT VacancyID, Title FROM Vacancies";
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        cbVacancy.DataSource = dt;
                        cbVacancy.DisplayMember = "Title";
                        cbVacancy.ValueMember = "VacancyID";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки вакансий: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPlacements()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT p.PlacementID, p.JobSeekerID, js.FirstName || ' ' || js.LastName AS JobSeekerName, " +
                                   "p.VacancyID, v.Title AS VacancyTitle, p.PlacementDate " +
                                   "FROM Placements p " +
                                   "JOIN JobSeekers js ON p.JobSeekerID = js.JobSeekerID " +
                                   "JOIN Vacancies v ON p.VacancyID = v.VacancyID";
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn))
                    {
                        dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvPlacements.DataSource = dataTable;
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

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Placements (JobSeekerID, VacancyID, PlacementDate) VALUES (@jobSeekerID, @vacancyID, @placementDate)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@jobSeekerID", cbJobSeeker.SelectedValue);
                        cmd.Parameters.AddWithValue("@vacancyID", cbVacancy.SelectedValue);
                        cmd.Parameters.AddWithValue("@placementDate", dtpPlacementDate.Value.ToString("yyyy-MM-dd"));
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Размещение добавлено успешно.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPlacements();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvPlacements.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите размещение для редактирования.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInput()) return;

            int id = Convert.ToInt32(dgvPlacements.SelectedRows[0].Cells["PlacementID"].Value);
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Placements SET JobSeekerID = @jobSeekerID, VacancyID = @vacancyID, PlacementDate = @placementDate WHERE PlacementID = @id";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@jobSeekerID", cbJobSeeker.SelectedValue);
                        cmd.Parameters.AddWithValue("@vacancyID", cbVacancy.SelectedValue);
                        cmd.Parameters.AddWithValue("@placementDate", dtpPlacementDate.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Данные размещения обновлены.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPlacements();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPlacements.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите размещение для удаления.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Вы уверены, что хотите удалить это размещение?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvPlacements.SelectedRows[0].Cells["PlacementID"].Value);
                try
                {
                    using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Placements WHERE PlacementID = @id";
                        using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Размещение удалено.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPlacements();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvPlacements_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPlacements.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvPlacements.SelectedRows[0];
                object placementDateObj = row.Cells["PlacementDate"].Value;
                if (placementDateObj != DBNull.Value && !string.IsNullOrWhiteSpace(placementDateObj.ToString()))
                {
                    try
                    {
                        dtpPlacementDate.Value = DateTime.Parse(placementDateObj.ToString());
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Неверный формат даты в выбранной строке.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dtpPlacementDate.Value = DateTime.Now; // Устанавливаем текущее время по умолчанию
                    }
                }
                else
                {
                    dtpPlacementDate.Value = DateTime.Now; // Устанавливаем текущее время по умолчанию
                }
            }
        }

        private bool ValidateInput()
        {
            if (cbJobSeeker.SelectedIndex == -1 || cbVacancy.SelectedIndex == -1)
            {
                MessageBox.Show("Поля Соискатель и Вакансия обязательны для заполнения.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ClearInputs()
        {
            cbJobSeeker.SelectedIndex = -1;
            cbVacancy.SelectedIndex = -1;
            dtpPlacementDate.Value = DateTime.Now;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}