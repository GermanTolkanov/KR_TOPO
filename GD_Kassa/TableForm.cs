using Npgsql;
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

namespace GD_Kassa
{
    public partial class TableForm : Form
    {
        public TableForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void dataGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (Control gB in this.Controls)
                {
                    if (gB.Visible && gB is GroupBox)
                    {
                        int i = 0;
                        DataGridViewRow row = dataGV.Rows[e.RowIndex];
                        foreach (Control item in gB.Controls)
                        {
                            if (item is TextBox || item is ComboBox || item is MaskedTextBox)
                            {
                                item.Text = row.Cells[i].Value.ToString();
                                i++;
                            }
                            else if (item is CheckBox) 
                            {
                                ((CheckBox)item).Checked = (bool)row.Cells[i].Value;
                                i++;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        private void l_Back_Click(object sender, EventArgs e)
        {
        foreach (Control item in this.Controls)
        {
            if (item is GroupBox)
                item.Visible = false;
            else if (item is Label)
            {
                if (item.Text == "Отчёт" || item.Text.Contains(':') || item.Text == "Выборка")
                {
                    item.Visible = false;
                }
            }
            else if (item is ComboBox || item is TextBox)
                item.Visible = false;
        }
        dataGV.DataSource = null;
        this.Close();
        }


        private void Fill_cBUsers()
        {

            DataTable dataTable1 = MainForm.GetDataTable("Select * from \"GD_Kassa\".depot");
            dataTable1.Columns.Add("ID Город Улица Дом", typeof(string), "ID + ' ' +  Город + ' ' + Улица + ' ' + Дом");
            Users_cB_Depot.DisplayMember = "ID Город Улица Дом";
            Users_cB_Depot.DataSource = dataTable1;
            DataTable dataTable2 = MainForm.GetDataTable("Select * from \"GD_Kassa\".post");
            dataTable2.Columns.Add("ID Должность", typeof(string), "ID + ' ' + Должность");
            Users_cB_Post.DisplayMember = "ID Должность";
            Users_cB_Post.DataSource = dataTable2;
        }


        private void Fill_cBCashbox()
        {
            DataTable dataTable1 = MainForm.GetDataTable("Select * from \"GD_Kassa\".depot");
            dataTable1.Columns.Add("ID Город Улица Дом", typeof(string), "ID + ' ' +  Город + ' ' + Улица + ' ' + Дом");
            Cashbox_cB_Depot.DisplayMember = "ID Город Улица Дом";
            Cashbox_cB_Depot.DataSource = dataTable1;
        }

        private void Fill_cBTicket()
        {
            DataTable dtPass = MainForm.GetDataTable("Select * from \"GD_Kassa\".passage");
            DataTable dtSt = MainForm.GetDataTable("Select * from \"GD_Kassa\".station");
            dtPass.Columns.Add("Начальная", typeof(string));
            dtPass.Columns.Add("Конечная", typeof(string));
            foreach (DataRow dr in dtPass.Rows)
            {
                DataRow[] matchingRows1 = dtSt.Select("ID = " + dr["НачальнаяID"]);
                DataRow[] matchingRows2 = dtSt.Select("ID = " + dr["КонечнаяID"]);
                if (matchingRows1.Length > 0)
                    dr["Начальная"] = matchingRows1[0]["Название"];
                if (matchingRows2.Length > 0)
                    dr["Конечная"] = matchingRows2[0]["Название"];
            }
            dtPass.Columns.Add("ID Начальная Конечная Время_отпр", typeof(string), "ID + ' ' + Начальная + ' ' + Конечная + ' ' + Время_отпр");
            Ticket_cB_PassageID.DisplayMember = "ID Начальная Конечная Время_отпр";
            Ticket_cB_PassageID.DataSource = dtPass;
            DataTable dtCash = MainForm.GetDataTable("Select * from \"GD_Kassa\".cashbox");
            DataTable dtDepot = MainForm.GetDataTable("Select * from \"GD_Kassa\".depot");
            dtCash.Columns.Add("Адрес", typeof(string));
            foreach (DataRow dr in dtCash.Rows)
            {
                DataRow[] matchingRows1 = dtDepot.Select("ID = " + dr["ID_Вокзала"]);
                if (matchingRows1.Length > 0)
                    dr["Адрес"] = matchingRows1[0]["Город"].ToString() + " " + matchingRows1[0]["Улица"].ToString() + " " + matchingRows1[0]["Дом"].ToString();
            }
            dtCash.Columns.Add("ID Адрес", typeof(string), "ID + ' ' + Адрес");
            Ticket_cB_CashboxID.DisplayMember = "ID Адрес";
            Ticket_cB_CashboxID.DataSource = dtCash;
            DataTable dtPayment = MainForm.GetDataTable("Select * from \"GD_Kassa\".payment");
            dtPayment.Columns.Add("ID Дата", typeof(string), "ID + ' ' + Дата");
            Ticket_cB_PaymentID.DisplayMember = "ID Дата";
            Ticket_cB_PaymentID.DataSource = dtPayment;
            DataTable dtPassanger = MainForm.GetDataTable("Select * from \"GD_Kassa\".passanger");
            dtPassanger.Columns.Add("ID Серия Номер", typeof(string), "ID + ' ' + Серия_паспорта + ' ' + Номер_паспорта");
            Ticket_cB_PassangerID.DisplayMember = "ID Серия Номер";
            Ticket_cB_PassangerID.DataSource = dtPassanger;
            DataTable dtClass = MainForm.GetDataTable("Select * from \"GD_Kassa\".class");
            dtClass.Columns.Add("ID Класс", typeof(string), "ID + ' ' + Класс");
            Ticket_cB_ClassID.DisplayMember = "ID Класс";
            Ticket_cB_ClassID.DataSource = dtClass;
        }

        private void Fill_cBPassage()
        {
            DataTable dtSt1 = MainForm.GetDataTable("Select * from \"GD_Kassa\".station");
            dtSt1.Columns.Add("ID Название Адрес", typeof(string), "ID + ' ' +  Название + ' ' + Адрес");
            Passage_cB_StartID.DataSource = dtSt1;
            Passage_cB_StartID.DisplayMember = "ID Название Адрес";
            DataTable dtSt2 = MainForm.GetDataTable("Select * from \"GD_Kassa\".station");
            dtSt2.Columns.Add("ID Название Адрес", typeof(string), "ID + ' ' +  Название + ' ' + Адрес");
            Passage_cB_EndID.DisplayMember = "ID Название Адрес";
            Passage_cB_EndID.DataSource = dtSt2;
            DataTable dtTrain = MainForm.GetDataTable("Select * from \"GD_Kassa\".train");
            dtTrain.Columns.Add("ID Статус", typeof(string), "ID + ' ' + Статус");
            Passage_cB_TrainID.DisplayMember = "ID Статус";
            Passage_cB_TrainID.DataSource = dtTrain;
            DataTable dtTrain2 = MainForm.GetDataTable("Select * from \"GD_Kassa\".train");
            dtTrain2.Columns.Add("ID Статус", typeof(string), "ID + ' ' + Статус");
            Passage_cB_TrainID2.DisplayMember = "ID Статус";
            Passage_cB_TrainID2.DataSource = dtTrain2;
        }


        private void Fill_cBPassDisc()
        {
            DataTable dtPass = MainForm.GetDataTable("Select * from \"GD_Kassa\".passage");
            DataTable dtSt = MainForm.GetDataTable("Select * from \"GD_Kassa\".station");
            dtPass.Columns.Add("Начальная", typeof(string));
            dtPass.Columns.Add("Конечная", typeof(string));
            foreach (DataRow dr in dtPass.Rows)
            {
                DataRow[] matchingRows1 = dtSt.Select("ID = " + dr["НачальнаяID"]);
                DataRow[] matchingRows2 = dtSt.Select("ID = " + dr["КонечнаяID"]);
                if (matchingRows1.Length > 0)
                    dr["Начальная"] = matchingRows1[0]["Название"];
                if (matchingRows2.Length > 0)
                    dr["Конечная"] = matchingRows2[0]["Название"];
            }
            dtPass.Columns.Add("ID Начальная Конечная Время_отпр", typeof(string), "ID + ' ' + Начальная + ' ' + Конечная + ' ' + Время_отпр");
            PassDisc_cB_PassageID.DisplayMember = "ID Начальная Конечная Время_отпр";
            PassDisc_cB_PassageID.DataSource = dtPass;
            DataTable dtDisk = MainForm.GetDataTable("Select *from \"GD_Kassa\".discount");
            dtDisk.Columns.Add("ID Тип", typeof(string), "ID + ' ' + Тип");
            PassDisc_cB_DiscID.DisplayMember = "ID Тип";
            PassDisc_cB_DiscID.DataSource = dtDisk;
        }
        private void label55_Click(object sender, EventArgs e)
        {

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
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            string tableName = "";
            foreach (Control x in Controls)
            {
                if (x is GroupBox && x.Visible)
                {
                    tableName = x.Name.Split('_')[1];
                }
            }
            UserLog($"Таблица {tableName} закрыта");
        }
        internal void Table_b_Depot_Open()
        {
            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".depot");
            gB_Depot.Visible = true;
            UserLog("Вход в таблицу Depot");
        }
        internal void Table_b_Users_Open()
        {
            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".users");
            gB_Users.Visible = true;
            Fill_cBUsers();
            UserLog("Вход в таблицу Users");
        }
        internal void Table_b_cashBox_Open()
        {
            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".cashbox");
            gB_CashBox.Visible = true;
            Fill_cBCashbox();
            UserLog("Вход в таблицу Cashbox");
        }
        internal void Table_b_Train_Open()
        {
            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".train");
            gB_Train.Visible = true;
            label57.Visible = true;
            b_Vibor.Visible = true;
            Train_cBStatus2.Visible = true;
            UserLog("Вход в таблицу Train");
        }
        internal void Table_b_Ticket_Open()
        {
            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".ticket");
            gB_Ticket.Visible = true;
            Fill_cBTicket();
            UserLog("Вход в таблицу Ticket");
        }
        internal void Table_b_Passage_Open()
        {
            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".passage");
            gB_Passage.Visible = true;
            Fill_cBPassage();
            Passage_cB_TrainID2.Visible = true;
            label58.Visible = true;
            b_Vibor.Visible = true;
            UserLog("Вход в таблицу Passage");
        }
        internal void Table_b_Passage_Discount_Open()
        {
            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".passage_discount");
            gB_PassDisc.Visible = true;
            Fill_cBPassDisc();
            UserLog("Вход в таблицу Passage_Discount");
        }
        internal void Table_b_Passanger_Open()
        {
            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".passanger");
            gB_Passanger.Visible = true;
            UserLog("Вход в таблицу Passanger");
        }
        internal void Table_b_Class_Open()
        {
            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".class");
            gB_Class.Visible = true;
            UserLog("Вход в таблицу Class");
        }
        internal void Table_b_Station_Open()
        {
            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".station");
            gB_Station.Visible = true;


            UserLog("Вход в таблицу Station");
        }
        internal void Table_b_Payment_Open()
        {
            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".payment");
            gB_Payment.Visible = true;
            Payment_cBType.Visible = true;
            label56.Visible = true;
            b_Vibor.Visible = true;
            UserLog("Вход в таблицу Payment");
        }
        internal void Table_b_Discount_Open()
        {
            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".discount");
            gB_Discount.Visible = true;
            UserLog("Вход в таблицу Discount");
        }
        internal void Table_b_Post_Open()
        {
            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".post");
            gB_Post.Visible = true;
            UserLog("Вход в таблицу Post");
        }
        internal void Table_b_policy_Open()
        {
            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".password_policy");
            gB_policy.Visible = true;
            UserLog("Вход в таблицу policy");
            b_Add.Enabled = false;
            b_Delete.Enabled = false;
        }
        private void b_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (gB_Users.Visible)
                {
                    if (tB_login.Text == "" || tB_password.Text == "" || tB_Name.Text == "" || tB_Surname.Text == "" || Users_cB_Post.Text == "" || Users_cB_Depot.Text == "")
                    {
                        MessageBox.Show("Недостаточно данных!", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string encryptedpassword = "";
                        if (User.ValidPassword(tB_password.Text))
                            encryptedpassword = User.EncryptPassword(tB_password.Text);
                        else
                            throw new Exception("Пароль не прошёл валидацию");
                        using (var command = new NpgsqlCommand())
                        {
                            command.CommandText = $"select \"Login\" from \"GD_Kassa\".users where \"Login\" = '{tB_login.Text}'";
                            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
                            DataTable table = new DataTable();
                            adapter.SelectCommand = command;
                            adapter.Fill(table);
                            if (table.Rows.Count != 0)
                            {
                                MessageBox.Show("Логин занят!", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {

                                command.CommandText = $"Insert into \"GD_Kassa\".users (\"Login\", \"Password\", \"Name\",\"Surname\",\"PostID\",\"DepotID\",\"Property\",\"Password_date\")" +
                                    $"Values (@login, @password, @name,@surname,@postID,@depotID,@prop,@date);";
                                string postID = "";
                                foreach (var item in Users_cB_Post.Text)
                                {
                                    if (item != ' ')
                                        postID += item;
                                    else
                                        break;
                                }
                                string depotID = "";
                                foreach (var item in Users_cB_Depot.Text)
                                {
                                    if (item != ' ')
                                        depotID += item;
                                    else
                                        break;
                                }
                                command.Parameters.AddWithValue("@depotID", Int32.Parse(depotID));
                                command.Parameters.AddWithValue("@login", tB_login.Text);
                                command.Parameters.AddWithValue("@password", encryptedpassword);
                                command.Parameters.AddWithValue("@name", tB_Name.Text);
                                command.Parameters.AddWithValue("@surname", tB_Surname.Text);
                                command.Parameters.AddWithValue("@postID", Int32.Parse(postID));
                                command.Parameters.AddWithValue("@prop", Int32.Parse(cB_Property.Text));
                                command.Parameters.AddWithValue("@date", DateTime.Now);
                                command.ExecuteNonQuery();
                                pB_Clear_Click(pB_Clear, e = new EventArgs());
                                dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".users");
                            }
                        }
                    }
                }
                else if (gB_CashBox.Visible)
                {
                    if (Cashbox_cB_Depot.Text == "")
                    {
                        MessageBox.Show("Недостаточно данных!", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        using (var command = new NpgsqlCommand())
                        {
                            command.Connection = log_in.sqlConn;
                            command.CommandText = $"Insert into \"GD_Kassa\".cashbox (\"ID_Вокзала\", \"Телефон\")" +
                                $"Values (@depotID, @phone);";
                            string depotID = "";
                            foreach (var item in Cashbox_cB_Depot.Text)
                            {
                                if (item != ' ')
                                    depotID += item;
                                else
                                    break;
                            }
                            command.Parameters.AddWithValue("@depotID", Int32.Parse(depotID));
                            command.Parameters.AddWithValue("@phone", Cashbox_mTB_Phone.Text);
                            command.ExecuteNonQuery();
                            pB_Clear_Click(pB_Clear, e = new EventArgs());
                            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".cashbox");
                        }
                    }
                }
                else if (gB_Class.Visible)
                {
                    if (Class_tB_Class.Text == "" || Class_tB_Cost.Text == "")
                    {
                        MessageBox.Show("Недостаточно данных!", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        using (var command = new NpgsqlCommand())
                        {
                            command.Connection = log_in.sqlConn;
                            command.CommandText = $"Insert into \"GD_Kassa\".class (\"Класс\", \"Цена\")" +
                                $"Values (@class, @cost);";
                            command.Parameters.AddWithValue("@class", Class_tB_Class.Text);
                            command.Parameters.AddWithValue("@cost", Class_tB_Cost.Text);
                            command.ExecuteNonQuery();
                            pB_Clear_Click(pB_Clear, e = new EventArgs());
                             
                            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".class");
                        }
                    }
                }
                else if (gB_Depot.Visible)
                {
                    if (Depot_tB_City.Text == "" || Depot_tB_House.Text == "" || Depot_tB_Street.Text == "")
                    {
                        MessageBox.Show("Недостаточно данных!", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        using (var command = new NpgsqlCommand())
                        {
                            command.Connection = log_in.sqlConn;
                            command.CommandText = $"Insert into \"GD_Kassa\".depot (\"Город\", \"Улица\", \"Дом\")" +
                                $"Values (@city, @street, @house);";
                            command.Parameters.AddWithValue("@city", Depot_tB_City.Text);
                            command.Parameters.AddWithValue("@street", Depot_tB_Street.Text);
                            command.Parameters.AddWithValue("@house", Int32.Parse(Depot_tB_House.Text));
                            command.ExecuteNonQuery();
                            pB_Clear_Click(pB_Clear, e = new EventArgs());
                             
                            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".depot");
                        }
                    }
                }
                else if (gB_Discount.Visible)
                {
                    if (Discount_tB_Type.Text == "" || Discount_tB_Persent.Text == "" || Discount_tB_Document.Text == "")
                    {
                        MessageBox.Show("Недостаточно данных!", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        using (var command = new NpgsqlCommand())
                        {
                            command.Connection = log_in.sqlConn;
                            command.CommandText = $"Insert into \"GD_Kassa\".discount (\"Тип\", \"Процент\", \"Документ\")" +
                                $"Values (@type, @percent, @doc);";
                            command.Parameters.AddWithValue("@type", Discount_tB_Type.Text);
                            command.Parameters.AddWithValue("@percent", Int32.Parse(Discount_tB_Persent.Text));
                            command.Parameters.AddWithValue("@doc", Discount_tB_Document.Text);
                            command.ExecuteNonQuery();
                            pB_Clear_Click(pB_Clear, e = new EventArgs());
                             
                            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".discount");
                        }
                    }
                }
                else if (gB_Passage.Visible)
                {
                    if (Passage_cB_EndID.Text == "" || Passage_cB_StartID.Text == "" || Passage_cB_TrainID.Text == "")
                    {
                        MessageBox.Show("Недостаточно данных!", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        using (var command = new NpgsqlCommand())
                        {
                            command.Connection = log_in.sqlConn;
                            command.CommandText = $"Insert into \"GD_Kassa\".passage (\"НачальнаяID\", \"КонечнаяID\", \"Время_отпр\", \"Время_приб\", \"ID_Поезда\")" +
                                $"Values (@startID, @endID, @stTime, @endTime, @trainID);";
                            string startID = "";
                            foreach (var item in Passage_cB_StartID.Text)
                            {
                                if (item != ' ')
                                    startID += item;
                                else
                                    break;
                            }
                            string endID = "";
                            foreach (var item in Passage_cB_EndID.Text)
                            {
                                if (item != ' ')
                                    endID += item;
                                else
                                    break;
                            }
                            string trainID = "";
                            foreach (var item in Passage_cB_TrainID.Text)
                            {
                                if (item != ' ')
                                    trainID += item;
                                else
                                    break;
                            }
                            command.Parameters.AddWithValue("@startID", Int32.Parse(startID));
                            command.Parameters.AddWithValue("@endID", Int32.Parse(endID));
                            command.Parameters.AddWithValue("@stTime", Passage_tB_StartTime.Text);
                            command.Parameters.AddWithValue("@endTime", Passage_tB_EndTime.Text);
                            command.Parameters.AddWithValue("@trainID", Int32.Parse(trainID));
                            command.ExecuteNonQuery();
                            pB_Clear_Click(pB_Clear, e = new EventArgs());
                             
                            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".passage");
                        }
                    }
                }
                else if (gB_Passanger.Visible)
                {
                    if (Passanger_tB_FIO.Text == "" || Passanger_tB_PassSer.Text == "" || Passanger_tB_PassNum.Text == "")
                    {
                        MessageBox.Show("Недостаточно данных!", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        using (var command = new NpgsqlCommand())
                        {
                            command.Connection = log_in.sqlConn;
                            command.CommandText = $"Insert into \"GD_Kassa\".passanger (\"ФИО\", \"Дата рождения\", \"Телефон\", \"Серия_паспорта\", \"Номер_паспорта\")" +
                                $"Values (@fio, @birth, @phone, @passS, @passN);";
                            command.Parameters.AddWithValue("@fio", Passanger_tB_FIO.Text);
                            command.Parameters.AddWithValue("@birth", Passanger_tB_Birth.Text);
                            command.Parameters.AddWithValue("@phone", Passanger_tB_Phone.Text);
                            command.Parameters.AddWithValue("@passS", Int32.Parse(Passanger_tB_PassSer.Text));
                            command.Parameters.AddWithValue("@passN", Int32.Parse(Passanger_tB_PassNum.Text));
                            command.ExecuteNonQuery();
                            pB_Clear_Click(pB_Clear, e = new EventArgs());
                             
                            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".passanger");
                        }
                    }
                }
                else if (gB_PassDisc.Visible)
                {
                    if (PassDisc_cB_DiscID.Text == "" || PassDisc_cB_PassageID.Text == "")
                    {
                        MessageBox.Show("Недостаточно данных!", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        using (var command = new NpgsqlCommand())
                        {
                            command.Connection = log_in.sqlConn;
                            command.CommandText = $"Insert into \"GD_Kassa\".passage_discount (\"ID_passage\", \"ID_discount\")" +
                                $"Values (@passID, @discID);";
                            string passID = "";
                            foreach (var item in PassDisc_cB_PassageID.Text)
                            {
                                if (item != ' ')
                                    passID += item;
                                else
                                    break;
                            }
                            string discID = "";
                            foreach (var item in PassDisc_cB_DiscID.Text)
                            {
                                if (item != ' ')
                                    discID += item;
                                else
                                    break;
                            }
                            command.Parameters.AddWithValue("@passID", Int32.Parse(passID));
                            command.Parameters.AddWithValue("@discID", Int32.Parse(discID));
                            command.ExecuteNonQuery();
                            pB_Clear_Click(pB_Clear, e = new EventArgs());
                             
                            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".passage_discount");
                        }
                    }
                }
                else if (gB_Payment.Visible)
                {
                    if (Payment_tB_Type.Text == "" || Payment_tB_Amount.Text == "" || Payment_tB_Time.Text == "")
                    {
                        MessageBox.Show("Недостаточно данных!", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        using (var command = new NpgsqlCommand())
                        {
                            command.Connection = log_in.sqlConn;
                            command.CommandText = $"Insert into \"GD_Kassa\".payment (\"Способ\", \"Сумма\", \"Дата\")" +
                                $"Values (@type, @amount, @date);";
                            command.Parameters.AddWithValue("@type", Payment_tB_Type.Text);
                            command.Parameters.AddWithValue("@amount", Payment_tB_Amount.Text);
                            command.Parameters.AddWithValue("@date", Payment_tB_Time.Text);
                            command.ExecuteNonQuery();
                            pB_Clear_Click(pB_Clear, e = new EventArgs());
                             
                            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".payment");
                        }
                    }
                }
                else if (gB_Post.Visible)
                {
                    if (Post_tB_Post.Text == "")
                    {
                        MessageBox.Show("Недостаточно данных!", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        using (var command = new NpgsqlCommand())
                        {
                            command.Connection = log_in.sqlConn;
                            command.CommandText = $"Insert into \"GD_Kassa\".post (\"Должность\")" +
                                $"Values (@name);";
                            command.Parameters.AddWithValue("@name", Post_tB_Post.Text);
                            command.ExecuteNonQuery();
                            pB_Clear_Click(pB_Clear, e = new EventArgs());
                             
                            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".post");
                        }
                    }
                }
                else if (gB_Station.Visible)
                {
                    if (Station_tB_Name.Text == "" || Station_tB_Address.Text == "")
                    {
                        MessageBox.Show("Недостаточно данных!", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        using (var command = new NpgsqlCommand())
                        {
                            command.Connection = log_in.sqlConn;
                            command.CommandText = $"Insert into \"GD_Kassa\".station (\"Название\", \"Адрес\")" +
                                $"Values (@name, @address);";
                            command.Parameters.AddWithValue("@name", Station_tB_Name.Text);
                            command.Parameters.AddWithValue("@address", Station_tB_Address.Text);
                            command.ExecuteNonQuery();
                            pB_Clear_Click(pB_Clear, e = new EventArgs());
                             
                            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".station");
                        }
                    }
                }
                else if (gB_Ticket.Visible)
                {
                    if (Ticket_cB_CashboxID.Text == "")
                    {
                        MessageBox.Show("Недостаточно данных!", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        using (var command = new NpgsqlCommand())
                        {
                            command.Connection = log_in.sqlConn;
                            command.CommandText = $"Insert into \"GD_Kassa\".ticket (\"ID_Рейса\", \"Вагон\", \"Место\", \"ID_Кассы\", \"ID_Платежа\", \"ID_Пассажира\", \"ID_Класса\")" +
                                $"Values (@passageID, @wagon, @place, @cashID, @payID, @passID, @classID);";
                            string passageID = "";
                            foreach (var item in Ticket_cB_PassageID.Text)
                            {
                                if (item != ' ')
                                    passageID += item;
                                else
                                    break;
                            }
                            string cashID = "";
                            foreach (var item in Ticket_cB_CashboxID.Text)
                            {
                                if (item != ' ')
                                    cashID += item;
                                else
                                    break;
                            }
                            string payID = "";
                            foreach (var item in Ticket_cB_PaymentID.Text)
                            {
                                if (item != ' ')
                                    payID += item;
                                else
                                    break;
                            }
                            string passID = "";
                            foreach (var item in Ticket_cB_PassangerID.Text)
                            {
                                if (item != ' ')
                                    passID += item;
                                else
                                    break;
                            }
                            string classID = "";
                            foreach (var item in Ticket_cB_ClassID.Text)
                            {
                                if (item != ' ')
                                    classID += item;
                                else
                                    break;
                            }
                            command.Parameters.AddWithValue("@passageID", Int32.Parse(passageID));
                            command.Parameters.AddWithValue("@wagon", Int32.Parse(Ticket_tB_Wagon.Text));
                            command.Parameters.AddWithValue("@place", Int32.Parse(Ticket_tB_Place.Text));
                            command.Parameters.AddWithValue("@cashID", Int32.Parse(cashID));
                            command.Parameters.AddWithValue("@payID", Int32.Parse(payID));
                            command.Parameters.AddWithValue("@passID", Int32.Parse(passID));
                            command.Parameters.AddWithValue("@classID", Int32.Parse(classID));
                            command.ExecuteNonQuery();
                            pB_Clear_Click(pB_Clear, e = new EventArgs());
                             
                            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".ticket");
                        }
                    }
                }
                else if (gB_Train.Visible)
                {
                    if (Train_cB_Status.Text == "" || Train_tB_Wagons.Text == "" || Train_tB_Places.Text == "")
                    {
                        MessageBox.Show("Недостаточно данных!", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        using (var command = new NpgsqlCommand())
                        {
                            command.Connection = log_in.sqlConn;
                            command.CommandText = $"Insert into \"GD_Kassa\".train (\"Статус\", \"Количество_вагонов\", \"Количество_мест\")" +
                                $"Values (@passID, @wagons, @places);";
                            command.Parameters.AddWithValue("@passID", Train_cB_Status.Text);
                            command.Parameters.AddWithValue("@wagons", Int32.Parse(Train_tB_Wagons.Text));
                            command.Parameters.AddWithValue("@places", Int32.Parse(Train_tB_Places.Text));
                            command.ExecuteNonQuery();
                            pB_Clear_Click(pB_Clear, e = new EventArgs());
                             
                            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".train");
                        }
                    }
                }
                UserLog(sender);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public bool Pswd_is_new(string new_password)
        {
            string old_password = "", encr = User.EncryptPassword(new_password);
            using (NpgsqlCommand command = new NpgsqlCommand($"select \"Password\" from \"GD_Kassa\".users where \"UserID\" = {Int32.Parse(Users_tB_ID.Text)}", log_in.sqlConn))
            {
                using (NpgsqlDataReader myReader = command.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        old_password = myReader["Password"].ToString();
                    }
                    if (old_password != encr)
                        return true;
                }
            }
            return false;
        }
        private void b_Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (gB_Users.Visible)
                {
                    if (tB_login.Text == "" || tB_password.Text == "" || tB_Name.Text == "" || tB_Surname.Text == "" || Users_cB_Post.Text == "" || Users_cB_Depot.Text == "")
                    {
                        MessageBox.Show("Недостаточно данных!", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        NpgsqlCommand command = new NpgsqlCommand("", log_in.sqlConn);
                        string encryptedpassword = "";
                        encryptedpassword = User.EncryptPassword(tB_password.Text);
                        if (!Pswd_is_new(tB_password.Text))
                        {
                            command.CommandText = "update \"GD_Kassa\".users set \"Login\" = @login, \"Password\" = @password, \"Name\" = @name, \"Surname\" = @surname, \"DepotID\" = @depotID, \"PostID\" = @postID, \"Property\" = @prop where \"UserID\" = @id";
                        }
                        else if (Pswd_is_new(tB_password.Text) && User.ValidPassword(tB_password.Text))
                        {
                            command.CommandText = "update \"GD_Kassa\".users set \"Login\" = @login, \"Password\" = @password, \"Name\" = @name, \"Surname\" = @surname, \"DepotID\" = @depotID, \"PostID\" = @postID, \"Property\" = @prop, \"Password_date\" = @pd where \"UserID\" = @id";
                            command.Parameters.AddWithValue("@pd", DateTime.Now);
                        }
                        else
                            throw new Exception("Пароль не прошёл валидацию");
                        string postID = "";
                        foreach (var item in Users_cB_Post.Text)
                        {
                            if (item != ' ')
                                postID += item;
                            else
                                break;
                        }
                        string depotID = "";
                        foreach (var item in Users_cB_Depot.Text)
                        {
                            if (item != ' ')
                                depotID += item;
                            else
                                break;
                        }
                        command.Parameters.AddWithValue("@login", tB_login.Text);
                        command.Parameters.AddWithValue("@password", encryptedpassword);
                        command.Parameters.AddWithValue("@name", tB_Name.Text);
                        command.Parameters.AddWithValue("@surname", tB_Surname.Text);
                        command.Parameters.AddWithValue("@id", Int32.Parse(Users_tB_ID.Text));
                        command.Parameters.AddWithValue("@postID", Int32.Parse(postID));
                        command.Parameters.AddWithValue("@depotID", Int32.Parse(depotID));
                        command.Parameters.AddWithValue("@prop", Int32.Parse(cB_Property.Text));
                        command.ExecuteNonQuery();

                        dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".users");
                    }
                }
                else if (gB_CashBox.Visible)
                {
                    if (Cashbox_cB_Depot.Text == "")
                    {
                        MessageBox.Show("Недостаточно данных!", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        using (var command = new NpgsqlCommand())
                        {
                            command.Connection = log_in.sqlConn;
                            command.CommandText = $"update \"GD_Kassa\".cashbox set \"ID_Вокзала\" = @depotID, \"Телефон\" = @phone where \"ID\" = @id";
                            string depotID = "";
                            foreach (var item in Cashbox_cB_Depot.Text)
                            {
                                if (item != ' ')
                                    depotID += item;
                                else
                                    break;
                            }
                            command.Parameters.AddWithValue("@depotID", Int32.Parse(depotID));
                            command.Parameters.AddWithValue("@phone", Cashbox_mTB_Phone.Text);
                            command.Parameters.AddWithValue("@id", Int32.Parse(Cashbox_tB_ID.Text));
                            command.ExecuteNonQuery();

                            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".cashbox");
                        }
                    }
                }
                else if (gB_Class.Visible)
                {
                    if (Class_tB_Class.Text == "" || Class_tB_Cost.Text == "")
                    {
                        MessageBox.Show("Недостаточно данных!", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        using (var command = new NpgsqlCommand())
                        {
                            command.Connection = log_in.sqlConn;
                            command.CommandText = $"update \"GD_Kassa\".class set \"Класс\" = @class, \"Цена\" = @cost where \"ID\" = @id";
                            command.Parameters.AddWithValue("@class", Class_tB_Class.Text);
                            command.Parameters.AddWithValue("@cost", Class_tB_Cost.Text);
                            command.Parameters.AddWithValue("@id", Int32.Parse(Class_tB_ID.Text));
                            command.ExecuteNonQuery();

                            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".class");
                        }
                    }
                }
                else if (gB_Depot.Visible)
                {
                    if (Depot_tB_City.Text == "" || Depot_tB_House.Text == "" || Depot_tB_Street.Text == "")
                    {
                        MessageBox.Show("Недостаточно данных!", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        using (var command = new NpgsqlCommand())
                        {
                            command.Connection = log_in.sqlConn;
                            command.CommandText = $"update \"GD_Kassa\".depot set \"Город\" = @city, \"Улица\" = @street, \"Дом\"=@house where \"ID\" = @id";
                            command.Parameters.AddWithValue("@city", Depot_tB_City.Text);
                            command.Parameters.AddWithValue("@street", Depot_tB_Street.Text);
                            command.Parameters.AddWithValue("@house", Int32.Parse(Depot_tB_House.Text));
                            command.Parameters.AddWithValue("@id", Int32.Parse(Depot_tB_ID.Text));
                            command.ExecuteNonQuery();

                            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".depot");
                        }
                    }
                }
                else if (gB_Discount.Visible)
                {
                    if (Discount_tB_Type.Text == "" || Discount_tB_Persent.Text == "" || Discount_tB_Document.Text == "")
                    {
                        MessageBox.Show("Недостаточно данных!", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        using (var command = new NpgsqlCommand())
                        {
                            command.Connection = log_in.sqlConn;
                            command.CommandText = $"update \"GD_Kassa\".discount set \"Тип\" = @type, \"Процент\" = @percent, \"Документ\"= @doc where \"ID\" = @id";
                            command.Parameters.AddWithValue("@type", Discount_tB_Type.Text);
                            command.Parameters.AddWithValue("@percent", Int32.Parse(Discount_tB_Persent.Text));
                            command.Parameters.AddWithValue("@doc", Discount_tB_Document.Text);
                            command.Parameters.AddWithValue("@id", Int32.Parse(Discount_tB_ID.Text));
                            command.ExecuteNonQuery();

                            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".discount");
                        }
                    }
                }
                else if (gB_Passage.Visible)
                {
                    if (Passage_cB_EndID.Text == "" || Passage_cB_StartID.Text == "" || Passage_cB_TrainID.Text == "")
                    {
                        MessageBox.Show("Недостаточно данных!", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        using (var command = new NpgsqlCommand())
                        {
                            command.Connection = log_in.sqlConn;
                            command.CommandText = $"update \"GD_Kassa\".passage set \"НачальнаяID\"= @startID, \"КонечнаяID\" = @endID, \"Время_отпр\" = @stTime, \"Время_приб\" = @endTime, \"ID_Поезда\"= @trainID where \"ID\" = @id";
                            string startID = "";
                            foreach (var item in Passage_cB_StartID.Text)
                            {
                                if (item != ' ')
                                    startID += item;
                                else
                                    break;
                            }
                            string endID = "";
                            foreach (var item in Passage_cB_EndID.Text)
                            {
                                if (item != ' ')
                                    endID += item;
                                else
                                    break;
                            }
                            string trainID = "";
                            foreach (var item in Passage_cB_TrainID.Text)
                            {
                                if (item != ' ')
                                    trainID += item;
                                else
                                    break;
                            }
                            command.Parameters.AddWithValue("@startID", Int32.Parse(startID));
                            command.Parameters.AddWithValue("@endID", Int32.Parse(endID));
                            command.Parameters.AddWithValue("@stTime", Passage_tB_StartTime.Text);
                            command.Parameters.AddWithValue("@endTime", Passage_tB_EndTime.Text);
                            command.Parameters.AddWithValue("@trainID", Int32.Parse(trainID));
                            command.Parameters.AddWithValue("@id", Int32.Parse(Passage_tB_ID.Text));
                            command.ExecuteNonQuery();

                            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".passage");
                        }
                    }
                }
                else if (gB_Passanger.Visible)
                {
                    if (Passanger_tB_FIO.Text == "" || Passanger_tB_PassSer.Text == "" || Passanger_tB_PassNum.Text == "")
                    {
                        MessageBox.Show("Недостаточно данных!", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        using (var command = new NpgsqlCommand())
                        {
                            command.Connection = log_in.sqlConn;
                            command.CommandText = $"update \"GD_Kassa\".passanger set \"ФИО\"=@fio, \"Дата рождения\"=@birth, \"Телефон\"=@phone, \"Серия_паспорта\"=@passS, \"Номер_паспорта\"=@passN where \"ID\" = @id";
                            command.Parameters.AddWithValue("@fio", Passanger_tB_FIO.Text);
                            command.Parameters.AddWithValue("@birth", Passanger_tB_Birth.Text);
                            command.Parameters.AddWithValue("@phone", Passanger_tB_Phone.Text);
                            command.Parameters.AddWithValue("@passS", Int32.Parse(Passanger_tB_PassSer.Text));
                            command.Parameters.AddWithValue("@passN", Int32.Parse(Passanger_tB_PassNum.Text));
                            command.Parameters.AddWithValue("@id", Int32.Parse(Passanger_tB_ID.Text));
                            command.ExecuteNonQuery();

                            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".passanger");
                        }
                    }
                }
                else if (gB_PassDisc.Visible)
                {
                    if (PassDisc_cB_DiscID.Text == "" || PassDisc_cB_PassageID.Text == "")
                    {
                        MessageBox.Show("Недостаточно данных!", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        using (var command = new NpgsqlCommand())
                        {
                            command.Connection = log_in.sqlConn;
                            command.CommandText = $"update \"GD_Kassa\".passage_discount set \"ID_passage\"=@passID, \"ID_discount\"=@discID where \"ID_passage\" = @passID or \"ID_discount\"=@discID";
                            string passID = "";
                            foreach (var item in PassDisc_cB_PassageID.Text)
                            {
                                if (item != ' ')
                                    passID += item;
                                else
                                    break;
                            }
                            string discID = "";
                            foreach (var item in PassDisc_cB_DiscID.Text)
                            {
                                if (item != ' ')
                                    discID += item;
                                else
                                    break;
                            }
                            command.Parameters.AddWithValue("@passID", Int32.Parse(passID));
                            command.Parameters.AddWithValue("@discID", Int32.Parse(discID));
                            command.ExecuteNonQuery();

                            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".passage_discount");
                        }
                    }
                }
                else if (gB_Payment.Visible)
                {
                    if (Payment_tB_Type.Text == "" || Payment_tB_Amount.Text == "" || Payment_tB_Time.Text == "")
                    {
                        MessageBox.Show("Недостаточно данных!", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        using (var command = new NpgsqlCommand())
                        {
                            command.Connection = log_in.sqlConn;
                            command.CommandText = $"update \"GD_Kassa\".payment set \"Способ\" = @type, \"Сумма\" = @amount, \"Дата\" = @date where \"ID\" = @id";
                            command.Parameters.AddWithValue("@type", Payment_tB_Type.Text);
                            command.Parameters.AddWithValue("@amount", Payment_tB_Amount.Text);
                            command.Parameters.AddWithValue("@date", Payment_tB_Time.Text);
                            command.Parameters.AddWithValue("@id", Int32.Parse(Payment_tB_ID.Text));
                            command.ExecuteNonQuery();

                            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".payment");
                        }
                    }
                }
                else if (gB_Post.Visible)
                {
                    if (Post_tB_Post.Text == "")
                    {
                        MessageBox.Show("Недостаточно данных!", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        using (var command = new NpgsqlCommand())
                        {
                            command.Connection = log_in.sqlConn;
                            command.CommandText = $"update \"GD_Kassa\".post set \"Должность\" = @name  where \"ID\" = @id";
                            command.Parameters.AddWithValue("@name", Post_tB_Post.Text);
                            command.Parameters.AddWithValue("@id", Int32.Parse(Post_tB_ID.Text));
                            command.ExecuteNonQuery();

                            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".post");
                        }
                    }
                }
                else if (gB_Station.Visible)
                {
                    if (Station_tB_Name.Text == "" || Station_tB_Address.Text == "")
                    {
                        MessageBox.Show("Недостаточно данных!", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        using (var command = new NpgsqlCommand())
                        {
                            command.Connection = log_in.sqlConn;
                            command.CommandText = $"update \"GD_Kassa\".station set \"Название\" = @name, \"Адрес\" = @address where \"ID\" = @id";
                            command.Parameters.AddWithValue("@name", Station_tB_Name.Text);
                            command.Parameters.AddWithValue("@address", Station_tB_Address.Text);
                            command.Parameters.AddWithValue("@id", Int32.Parse(Station_tB_ID.Text));
                            command.ExecuteNonQuery();

                            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".station");
                        }
                    }
                }
                else if (gB_Ticket.Visible)
                {
                    if (Ticket_cB_CashboxID.Text == "")
                    {
                        MessageBox.Show("Недостаточно данных!", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        using (var command = new NpgsqlCommand())
                        {
                            command.Connection = log_in.sqlConn;
                            command.CommandText = $"update \"GD_Kassa\".ticket set \"ID_Рейса\" = @passageID, \"Вагон\" = @wagon, \"Место\" = @place, \"ID_Кассы\" = @cashID, \"ID_Платежа\" = @payID, \"ID_Пассажира\" = @passID, \"ID_Класса\" = @classID where \"ID\" = @id";
                            string passageID = "";
                            foreach (var item in Ticket_cB_PassageID.Text)
                            {
                                if (item != ' ')
                                    passageID += item;
                                else
                                    break;
                            }
                            string cashID = "";
                            foreach (var item in Ticket_cB_CashboxID.Text)
                            {
                                if (item != ' ')
                                    cashID += item;
                                else
                                    break;
                            }
                            string payID = "";
                            foreach (var item in Ticket_cB_PaymentID.Text)
                            {
                                if (item != ' ')
                                    payID += item;
                                else
                                    break;
                            }
                            string passID = "";
                            foreach (var item in Ticket_cB_PassangerID.Text)
                            {
                                if (item != ' ')
                                    passID += item;
                                else
                                    break;
                            }
                            string classID = "";
                            foreach (var item in Ticket_cB_ClassID.Text)
                            {
                                if (item != ' ')
                                    classID += item;
                                else
                                    break;
                            }
                            command.Parameters.AddWithValue("@passageID", Int32.Parse(passageID));
                            command.Parameters.AddWithValue("@wagon", Int32.Parse(Ticket_tB_Wagon.Text));
                            command.Parameters.AddWithValue("@place", Int32.Parse(Ticket_tB_Place.Text));
                            command.Parameters.AddWithValue("@cashID", Int32.Parse(cashID));
                            command.Parameters.AddWithValue("@payID", Int32.Parse(payID));
                            command.Parameters.AddWithValue("@passID", Int32.Parse(passID));
                            command.Parameters.AddWithValue("@classID", Int32.Parse(classID));
                            command.Parameters.AddWithValue("@id", Int32.Parse(Ticket_tB_ID.Text));
                            command.ExecuteNonQuery();

                            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".ticket");
                        }
                    }
                }
                else if (gB_Train.Visible)
                {
                    if (Train_cB_Status.Text == "" || Train_tB_Wagons.Text == "" || Train_tB_Places.Text == "")
                    {
                        MessageBox.Show("Недостаточно данных!", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        using (var command = new NpgsqlCommand())
                        {
                            command.Connection = log_in.sqlConn;
                            command.CommandText = $"update \"GD_Kassa\".train set \"Статус\" = @passID, \"Количество_вагонов\" = @wagons, \"Количество_мест\" = @places where \"ID\" = @id";
                            command.Parameters.AddWithValue("@passID", Train_cB_Status.Text);
                            command.Parameters.AddWithValue("@wagons", Int32.Parse(Train_tB_Wagons.Text));
                            command.Parameters.AddWithValue("@places", Int32.Parse(Train_tB_Places.Text));
                            command.Parameters.AddWithValue("@id", Int32.Parse(Train_tB_ID.Text));
                            command.ExecuteNonQuery();

                            dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".train");
                        }
                    }
                }
                else if (gB_policy.Visible)
                {
                    using (var command = new NpgsqlCommand())
                    {
                        command.Connection = log_in.sqlConn;
                        command.CommandText = $"update \"GD_Kassa\".password_policy set rus = @p1, lat = @p2, spec = @p3, days = @p4, min_len = @p5, max_len = @p6 where id = @id";
                        command.Parameters.AddWithValue("@p1", chB_rus.Checked);
                        command.Parameters.AddWithValue("@p2", chB_eng.Checked);
                        command.Parameters.AddWithValue("@p3", chB_spec.Checked);
                        command.Parameters.AddWithValue("@p4", tB_days.Text);
                        command.Parameters.AddWithValue("@p5", Int32.Parse(tB_min_len.Text));
                        command.Parameters.AddWithValue("@p6", Int32.Parse(tB_max_len.Text));
                        command.Parameters.AddWithValue("@id", Int32.Parse(policy_tB_id.Text));
                        command.ExecuteNonQuery();

                        dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".password_policy");
                    }
                }
                pB_Clear_Click(pB_Clear, e = new EventArgs());
                UserLog(sender);
            }
            catch (Exception ex) { MessageBox.Show($"{ex.Message}", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        private void b_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string queryDelete = "";
                if (gB_Users.Visible)
                {
                    queryDelete = "Delete from \"GD_Kassa\".users where \"UserID\" = @id";
                    NpgsqlCommand command = new NpgsqlCommand(queryDelete, log_in.sqlConn);
                    command.Parameters.AddWithValue("@id", Int32.Parse(Users_tB_ID.Text));
                    command.ExecuteNonQuery();
                    dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".users");
                }
                if (gB_CashBox.Visible)
                {
                    queryDelete = "Delete from \"GD_Kassa\".cashbox where \"ID\" = @id";
                    NpgsqlCommand command = new NpgsqlCommand(queryDelete, log_in.sqlConn);
                    command.Parameters.AddWithValue("@id", Int32.Parse(Cashbox_tB_ID.Text));
                    command.ExecuteNonQuery();
                    dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".cashbox");
                }
                if (gB_Class.Visible)
                {
                    queryDelete = "Delete from \"GD_Kassa\".class where \"ID\" = @id";
                    NpgsqlCommand command = new NpgsqlCommand(queryDelete, log_in.sqlConn);
                    command.Parameters.AddWithValue("@id", Int32.Parse(Class_tB_ID.Text));
                    command.ExecuteNonQuery();
                    dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".class");
                }
                if (gB_Depot.Visible)
                {
                    queryDelete = "Delete from \"GD_Kassa\".depot where \"ID\" = @id";
                    NpgsqlCommand command = new NpgsqlCommand(queryDelete, log_in.sqlConn);
                    command.Parameters.AddWithValue("@id", Int32.Parse(Depot_tB_ID.Text));
                    command.ExecuteNonQuery();
                    dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".depot");
                }
                if (gB_Discount.Visible)
                {
                    queryDelete = "Delete from \"GD_Kassa\".discount where \"ID\" = @id";
                    NpgsqlCommand command = new NpgsqlCommand(queryDelete, log_in.sqlConn);
                    command.Parameters.AddWithValue("@id", Int32.Parse(Discount_tB_ID.Text));
                    command.ExecuteNonQuery();
                    dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".discount");
                }
                if (gB_Passage.Visible)
                {
                    queryDelete = "Delete from \"GD_Kassa\".passage  where \"ID\" = @id";
                    NpgsqlCommand command = new NpgsqlCommand(queryDelete, log_in.sqlConn);
                    command.Parameters.AddWithValue("@id", Int32.Parse(Passage_tB_ID.Text));
                    command.ExecuteNonQuery();
                    dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".passage");
                }
                if (gB_Passanger.Visible)
                {
                    queryDelete = "Delete from \"GD_Kassa\".passanger  where \"ID\" = @id";
                    NpgsqlCommand command = new NpgsqlCommand(queryDelete, log_in.sqlConn);
                    command.Parameters.AddWithValue("@id", Int32.Parse(Passanger_tB_ID.Text));
                    command.ExecuteNonQuery();
                    dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".passanger ");
                }
                if (gB_PassDisc.Visible)
                {
                    queryDelete = "Delete from \"GD_Kassa\".passage_discount where \"ID_passage\" = @id_pass AND \"ID_discount\" = @id_dis";
                    NpgsqlCommand command = new NpgsqlCommand(queryDelete, log_in.sqlConn);
                    command.Parameters.AddWithValue("@id_pass", Int32.Parse(PassDisc_cB_PassageID.Text));
                    command.Parameters.AddWithValue("@id_dis", Int32.Parse(PassDisc_cB_DiscID.Text));
                    command.ExecuteNonQuery();
                    dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".passage_discount");
                }
                if (gB_Payment.Visible)
                {
                    queryDelete = "Delete from \"GD_Kassa\".payment where \"ID\" = @id";
                    NpgsqlCommand command = new NpgsqlCommand(queryDelete, log_in.sqlConn);
                    command.Parameters.AddWithValue("@id", Int32.Parse(Payment_tB_ID.Text));
                    command.ExecuteNonQuery();
                    dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".payment ");
                }
                if (gB_Post.Visible)
                {
                    queryDelete = "Delete from \"GD_Kassa\".post where \"ID\" = @id";
                    NpgsqlCommand command = new NpgsqlCommand(queryDelete, log_in.sqlConn);
                    command.Parameters.AddWithValue("@id", Int32.Parse(Post_tB_ID.Text));
                    command.ExecuteNonQuery();
                    dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".post ");
                }
                if (gB_Station.Visible)
                {
                    queryDelete = "Delete from \"GD_Kassa\".station where \"ID\" = @id";
                    NpgsqlCommand command = new NpgsqlCommand(queryDelete, log_in.sqlConn);
                    command.Parameters.AddWithValue("@id", Int32.Parse(Station_tB_ID.Text));
                    command.ExecuteNonQuery();
                    dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".station");
                }
                if (gB_Ticket.Visible)
                {
                    queryDelete = "Delete from \"GD_Kassa\".ticket where \"ID\" = @id";
                    NpgsqlCommand command = new NpgsqlCommand(queryDelete, log_in.sqlConn);
                    command.Parameters.AddWithValue("@id", Int32.Parse(Ticket_tB_ID.Text));
                    command.ExecuteNonQuery();
                    dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".ticket ");
                }
                if (gB_Train.Visible)
                {
                    queryDelete = "Delete from \"GD_Kassa\".train where \"ID\" = @id";
                    NpgsqlCommand command = new NpgsqlCommand(queryDelete, log_in.sqlConn);
                    command.Parameters.AddWithValue("@id", Int32.Parse(Train_tB_ID.Text));
                    command.ExecuteNonQuery();
                    dataGV.DataSource = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".train");
                }
                pB_Clear_Click(pB_Clear, e = new EventArgs());
                UserLog(sender);

                }
                catch (Exception ex) { MessageBox.Show($"{ex.Message}", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        private void pB_Clear_Click(object sender, EventArgs e)
        {
            foreach (Control x in this.Controls)
            {
                if (x is GroupBox && x.Visible)
                {
                    foreach (Control x2 in x.Controls)
                    {
                        if (x2 is TextBox)
                        {
                            x2.Text = "";
                        }
                        if (x2 is ComboBox)
                        {
                            x2.Text = "";
                        }
                    }
                }
            }
        }
        private void b_Vibor_Click(object sender, EventArgs e)
        {
            try
            {
                if (gB_Payment.Visible)
                {
                    DataTable dataTable = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".payment");
                    DataView dv = new DataView(dataTable);
                    string type = Payment_cBType.Text;
                    dv.RowFilter = $"Способ = '{type}'";
                    dataTable = dv.ToTable();
                    dataGV.DataSource = dataTable;
                }
                if (gB_Train.Visible)
                {
                    DataTable dataTable = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".train");
                    DataView dv = new DataView(dataTable);
                    string type = Train_cBStatus2.Text;
                    dv.RowFilter = $"Статус = '{type}'";
                    dataTable = dv.ToTable();
                    dataGV.DataSource = dataTable;
                }
                if (gB_Passage.Visible)
                {
                    DataTable dataTable = MainForm.GetDataTable("SELECT *from \"GD_Kassa\".passage");
                    DataView dv = new DataView(dataTable);
                    string trainID = "";
                    foreach (var item in Passage_cB_TrainID2.Text)
                    {
                        if (item == ' ')
                        {
                            break;
                        }
                        trainID += item;
                    }
                    dv.RowFilter = $"ID_Поезда = '{trainID}'";
                    dataTable = dv.ToTable();
                    dataGV.DataSource = dataTable;
                }
            }
            catch (Exception ex) { MessageBox.Show($"{ex.Message}", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void TableForm_Load(object sender, EventArgs e)
        {
            if (User.Property!=1)
            {
                b_Add.Enabled = false;
                b_Update.Enabled = false;
                b_Delete.Enabled = false;
            }
        }
    }
}

