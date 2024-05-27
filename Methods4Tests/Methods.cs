using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using GD_Kassa;

namespace Methods4Tests
{
    public class Methods
    {
        static public NpgsqlConnection sqlConn = new NpgsqlConnection("Server=localhost;Port=5432;User ID=postgres;Password=admin123;Database=postgres");
        static public NpgsqlCommand sqlCommand = new NpgsqlCommand("", sqlConn);
        public static DataTable GetDataTable(string command)
        {
            if(sqlConn.State == ConnectionState.Closed)
                sqlConn.Open();
            DataTable dataTable = new DataTable();
            sqlCommand.CommandText = command;
            NpgsqlDataReader npgsqlDataReader = sqlCommand.ExecuteReader();
            dataTable.Load(npgsqlDataReader);
            return dataTable;
        }
        public static bool ValidPassword(string password)
        {
            if(sqlConn.State == ConnectionState.Closed)
                sqlConn.Open();
            string querystring = $"select rus, lat, spec, days, max_len, min_len from \"GD_Kassa\".password_policy where id = 1";
            bool rus = false, lat = false, spec = false;
            int days = 0, max_len = 0, min_len = 0;
            char[] specArr = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '-', '+', '=', '"', '№', ';', ':', '?', '.', ',' };
            char[] rusArr = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я',
                        'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я'};
            char[] latArr = {'А', 'В', 'С', 'D', 'Е', 'F', 'G', 'Н', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
            using (NpgsqlCommand command = new NpgsqlCommand(querystring, sqlConn))
            {
                using (NpgsqlDataReader myReader = command.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        rus = (bool)myReader["rus"];
                        lat = (bool)myReader["lat"];
                        spec = (bool)myReader["spec"];
                        days = Int32.Parse(myReader["days"].ToString());
                        max_len = (int)myReader["max_len"];
                        min_len = (int)myReader["min_len"];
                    }
                }
            }
            if (password.Length < min_len || password.Length > max_len)
            {
                return false;
            }
            for (int i = 0; i < specArr.Length; i++)
            {
                if (password.Contains(specArr[i]) && !spec)
                {
                    return false;
                }
            }
            for (int i = 0; i < rusArr.Length; i++)
            {
                if (password.Contains(rusArr[i]) && !rus)
                {
                    return false;
                }
            }
            for (int i = 0; i < latArr.Length; i++)
            {
                if (password.Contains(latArr[i]) && !lat)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool FindUser(string login, string password)
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable table = new DataTable();
            password = User.EncryptPassword(password);
            string querystring = $"select \"Login\", \"Password\", \"Password_date\" from \"GD_Kassa\".users where \"Login\" = @p1 and \"Password\" = @p2";
            using (NpgsqlCommand command = new NpgsqlCommand(querystring, sqlConn))
            {
                command.Parameters.AddWithValue("p1", login);
                command.Parameters.AddWithValue("p2", password);
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
