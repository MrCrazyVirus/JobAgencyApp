using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace EmploymentAgency
{
    public partial class EmployersForm : Form
    {
        private readonly string connectionString = "Data Source=employment.db;Version=3;";
        private DataTable dataTable;

        public EmployersForm()
        {
            InitializeComponent();
            LoadEmployers();
        }

        private void LoadEmployers()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Employers";
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn))
                    {
                        dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvEmployers.DataSource = dataTable;
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
                    string query = "INSERT INTO Employers (CompanyName, ContactName, Email, Phone) VALUES (@companyName, @contactName, @email, @phone)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@companyName", txtCompanyName.Text.Trim());
                        cmd.Parameters.AddWithValue("@contactName", txtContactName.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Работодатель добавлен успешно.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadEmployers();
                ClearInputs();
            }
            catch (SQLiteException ex)
            {
                if (ex.Message.Contains("UNIQUE constraint failed"))
                    MessageBox.Show("Работодатель с таким email уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvEmployers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите работодателя для редактирования.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInput()) return;

            int id = Convert.ToInt32(dgvEmployers.SelectedRows[0].Cells["EmployerID"].Value);
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Employers SET CompanyName = @companyName, ContactName = @contactName, Email = @email, Phone = @phone WHERE EmployerID = @id";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@companyName", txtCompanyName.Text.Trim());
                        cmd.Parameters.AddWithValue("@contactName", txtContactName.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Данные работодателя обновлены.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadEmployers();
                ClearInputs();
            }
            catch (SQLiteException ex)
            {
                if (ex.Message.Contains("UNIQUE constraint failed"))
                    MessageBox.Show("Работодатель с таким email уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите работодателя для удаления.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Вы уверены, что хотите удалить этого работодателя?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvEmployers.SelectedRows[0].Cells["EmployerID"].Value);
                try
                {
                    using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Employers WHERE EmployerID = @id";
                        using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Работодатель удален.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEmployers();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvEmployers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmployers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvEmployers.SelectedRows[0];
                txtCompanyName.Text = row.Cells["CompanyName"].Value.ToString();
                txtContactName.Text = row.Cells["ContactName"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? "";
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtCompanyName.Text) || string.IsNullOrWhiteSpace(txtContactName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Поля Название компании, Контактное лицо и Email обязательны для заполнения.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ClearInputs()
        {
            txtCompanyName.Clear();
            txtContactName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}