using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace GD_Kassa
{
    public partial class log_in : Form
    {
        static public NpgsqlConnection sqlConn = new NpgsqlConnection("Server=localhost;Port=5432;User ID=postgres;Password=admin123;Database=postgres");
        public log_in()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            sqlConn.Open();
        }

        private void pB_Clear_Click(object sender, EventArgs e)
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    x.Text = "";
                }
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                var login = tB_login.Text;
                var password = User.EncryptPassword(tB_password.Text);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
                DataTable table = new DataTable();
                string querystring = $"select \"Login\", \"Password\", \"Password_date\" from \"GD_Kassa\".users where \"Login\" = '{login}' and \"Password\" = '{password}'";
                using (NpgsqlCommand command = new NpgsqlCommand(querystring, sqlConn))
                {
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    if (table.Rows.Count == 1)
                    {
                        User.GetCurrentUser(login);
                        MessageBox.Show("Добро пожаловать!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MainForm tForm = new MainForm();
                        UserLog(sender);
                        this.Hide();
                        tForm.ShowDialog();
                        this.Show();
                    }
                    else
                        MessageBox.Show("Пользователь не найден!", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    pB_Clear_Click(pB_Clear, e = new EventArgs());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void UserLog(object obj)//Логирование
        {
            string log = $"{DateTime.Now} {User.Surname} {User.Name} Логин: {User.Login} | ";
            if (obj is string)
            {
                log += obj;
            }
            else
            {
                var sender = obj as Control;
                string tableName = "";
                foreach (Control x in Controls)
                {
                    if (x is GroupBox && x.Visible)
                    {
                        tableName = x.Name.Split('_')[1];
                    }
                }
                if (sender.Name == "l_Add")
                {
                    log += $"Добавлена запись в таблице {tableName}";
                }
                else if (sender.Name == "l_Update")
                {
                    log += $"Изменена запись в таблице {tableName}";
                }
                else if (sender.Name == "l_Delete")
                {
                    log += $"Удалена запись в таблице {tableName}";
                }
                else if (sender.Name == "lOtchet")
                {
                    log += $"Создан отчёт для таблицы {tableName}";
                }
            }
            if (log != $"{DateTime.Now} {User.Surname} {User.Name} Логин: {User.Login} | ")
                using (StreamWriter filestream = new StreamWriter("logs.txt", true, Encoding.UTF8))
                {
                    filestream.WriteLine(log);
                    filestream.Close();
                }
        }
    }
}
