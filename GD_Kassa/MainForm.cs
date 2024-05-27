using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GD_Kassa
{
    public partial class MainForm : Form
    {
        List<TableForm> TForms = new List<TableForm>();
        public static NpgsqlCommand sqlCommand = new NpgsqlCommand("",log_in.sqlConn);
        public MainForm()
        {
            InitializeComponent();
            if (!User.ValidDate(User.Password_date))
                l_chngPswd.Visible = true;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (User.Property == 1)
            {
                Table_b_Users.Visible = true;
                Table_b_Users.Enabled = true;
                Table_b_policy.Enabled = true;
                Table_b_policy.Visible = true;
            }
        }
        private void Table_b_Depot_Click(object sender, EventArgs e)
        {
            TableForm form = new TableForm();
            TForms.Add(form);
            form.Show();
            form.Table_b_Depot_Open();
        }

        private void Table_b_Users_Click(object sender, EventArgs e)
        {
            TableForm form = new TableForm();
            TForms.Add(form);
            form.Show();
            form.Table_b_Users_Open();
        }
        private void Table_b_cashBox_Click(object sender, EventArgs e)
        {
            TableForm form = new TableForm();
            TForms.Add(form);
            form.Show();
            form.Table_b_cashBox_Open();
        }
        private void Table_b_Train_Click(object sender, EventArgs e)
        {
            TableForm form = new TableForm();
            TForms.Add(form);
            form.Show();
            form.Table_b_Train_Open();
        }
        private void Table_b_Ticket_Click(object sender, EventArgs e)
        {
            TableForm form = new TableForm();
            TForms.Add(form);
            form.Show();
            form.Table_b_Ticket_Open();
        }
        private void Table_b_Passage_Click(object sender, EventArgs e)
        {
            TableForm form = new TableForm();
            TForms.Add(form);
            form.Show();
            form.Table_b_Passage_Open();
        }
        private void Table_b_Passage_Discount_Click(object sender, EventArgs e)
        {
            TableForm form = new TableForm();
            TForms.Add(form);
            form.Show();
            form.Table_b_Passage_Discount_Open();
        }
        private void Table_b_Passanger_Click(object sender, EventArgs e)
        {
            TableForm form = new TableForm();
            TForms.Add(form);
            form.Show();
            form.Table_b_Passanger_Open();
        }
        private void Table_b_Class_Click(object sender, EventArgs e)
        {
            TableForm form = new TableForm();
            TForms.Add(form);
            form.Show();
            form.Table_b_Class_Open();
        }
        private void Table_b_Station_Click(object sender, EventArgs e)
        {
            TableForm form = new TableForm();
            TForms.Add(form);
            form.Show();
            form.Table_b_Station_Open();
        }
        private void Table_b_Payment_Click(object sender, EventArgs e)
        {
            TableForm form = new TableForm();
            TForms.Add(form);
            form.Show();
            form.Table_b_Payment_Open();
        }
        private void Table_b_Discount_Click(object sender, EventArgs e)
        {
            TableForm form = new TableForm();
            TForms.Add(form);
            form.Show();
            form.Table_b_Discount_Open();
        }
        private void Table_b_Post_Click(object sender, EventArgs e)
        {
            TableForm form = new TableForm();
            TForms.Add(form);
            form.Show();
            form.Table_b_Post_Open();
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
                if (sender.Name == "btnEnter")
                {
                    log += $"Успешный вход";
                }
                else if (sender.Name == "MainForm")
                {
                    log += $"Выход из программы";
                }
            }
            if (log != $"{DateTime.Now} {User.Surname} {User.Name} Логин: {User.Login} | ")
                using (StreamWriter filestream = new StreamWriter("logs.txt", true, Encoding.UTF8))
                {
                    filestream.WriteLine(log);
                    filestream.Close();
                }
        }
        public static DataTable GetDataTable(string command)
        {
            DataTable dataTable = new DataTable();
            sqlCommand.CommandText = command;
            NpgsqlDataReader npgsqlDataReader = sqlCommand.ExecuteReader();
            dataTable.Load(npgsqlDataReader);
            return dataTable;
        }

        private void Table_b_policy_Click(object sender, EventArgs e)
        {
            TableForm form = new TableForm();
            TForms.Add(form);
            form.Show();
            form.Table_b_policy_Open();
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach(TableForm tf in TForms)
            {
                tf.Close();
            }
            UserLog(sender);
            User.DeleteCurrentUser();
        }
    }
}
