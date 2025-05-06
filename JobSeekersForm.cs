using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace EmploymentAgency
{
    public partial class JobSeekersForm : Form
    {
        private readonly string connectionString = "Data Source=employment.db;Version=3;";
        private DataTable dataTable;

        public JobSeekersForm()
        {
            InitializeComponent();
            LoadJobSeekers();
        }

        private void LoadJobSeekers()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM JobSeekers";
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn))
                    {
                        dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvJobSeekers.DataSource = dataTable;
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
                    string query = "INSERT INTO JobSeekers (FirstName, LastName, Email, Phone, Resume) VALUES (@firstName, @lastName, @email, @phone, @resume)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text.Trim());
                        cmd.Parameters.AddWithValue("@lastName", txtLastName.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("@resume", txtResume.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Соискатель добавлен успешно.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadJobSeekers();
                ClearInputs();
            }
            catch (SQLiteException ex)
            {
                if (ex.Message.Contains("UNIQUE constraint failed"))
                    MessageBox.Show("Соискатель с таким email уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvJobSeekers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите соискателя для редактирования.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInput()) return;

            int id = Convert.ToInt32(dgvJobSeekers.SelectedRows[0].Cells["JobSeekerID"].Value);
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE JobSeekers SET FirstName = @firstName, LastName = @lastName, Email = @email, Phone = @phone, Resume = @resume WHERE JobSeekerID = @id";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text.Trim());
                        cmd.Parameters.AddWithValue("@lastName", txtLastName.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("@resume", txtResume.Text.Trim());
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Данные соискателя обновлены.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadJobSeekers();
                ClearInputs();
            }
            catch (SQLiteException ex)
            {
                if (ex.Message.Contains("UNIQUE constraint failed"))
                    MessageBox.Show("Соискатель с таким email уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvJobSeekers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите соискателя для удаления.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Вы уверены, что хотите удалить этого соискателя?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvJobSeekers.SelectedRows[0].Cells["JobSeekerID"].Value);
                try
                {
                    using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM JobSeekers WHERE JobSeekerID = @id";
                        using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Соискатель удален.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadJobSeekers();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvJobSeekers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvJobSeekers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvJobSeekers.SelectedRows[0];
                txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
                txtLastName.Text = row.Cells["LastName"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? "";
                txtResume.Text = row.Cells["Resume"].Value?.ToString() ?? "";
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Поля Имя, Фамилия и Email обязательны для заполнения.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ClearInputs()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtResume.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}