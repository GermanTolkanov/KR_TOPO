using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GD_Kassa
{
    public class User
    {
        public static string Login { get; private set; }
        public static string Password { get; private set; }
        public static string Name { get; private set; }
        public static string Surname { get; private set; }
        public static string PostID { get; private set; }
        public static int Property { get; private set; }
        public static string DepotID { get; private set; }
        public static DateTime Password_date { get; private set; }
        private static User current;
        protected User(string login)
        {
            string querystring = $"select \"Login\", \"Password\", \"PostID\", \"DepotID\", \"Name\", \"Surname\", \"Property\", \"Password_date\" from \"GD_Kassa\".users where \"Login\" = '{login}'";
            using (NpgsqlCommand command = new NpgsqlCommand(querystring, log_in.sqlConn))
            {
                using (NpgsqlDataReader myReader = command.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        Login = myReader["Login"].ToString();
                        PostID = myReader["PostID"].ToString();
                        DepotID = myReader["PostID"].ToString();
                        Name = myReader["Name"].ToString();
                        Surname = myReader["Surname"].ToString();
                        Password = myReader["Password"].ToString();
                        Property = (int)myReader["Property"];
                        Password_date = (DateTime)myReader["Password_date"];
                    }
                }
            }
        }
        public static User GetCurrentUser(string login)
        {
            if (current == null)
                current = new User(login);
            return current;
        }
        public static string EncryptPassword(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                    //добавляет каждый байт из массива хэша в виде строки в объект StringBuilder,
                    //используя формат "x2" для представления каждого байта как двузначного шестнадцатеричного числа.
                }

                return sb.ToString();
            }
        }
        public static bool ValidPassword(string password)
        {
            string querystring = $"select rus, lat, spec, days, max_len, min_len from \"GD_Kassa\".password_policy where id = 1";
            bool rus = false, lat = false, spec = false;
            int days = 0, max_len= 0, min_len = 0;
            char[] specArr = {'!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '-', '+', '=', '"', '№', ';', ':', '?', '.', ',' };
            char[] rusArr = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я',
                        'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я'};
            char[] latArr = {'А', 'В', 'С', 'D', 'Е', 'F', 'G', 'Н', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
            using (NpgsqlCommand command = new NpgsqlCommand(querystring, log_in.sqlConn))
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
                return false;
            for (int i = 0; i < specArr.Length; i++)
            {
                if (password.Contains(specArr[i]) && !spec)
                    return false;
            }
            for (int i = 0; i < rusArr.Length; i++)
            {
                if (password.Contains(rusArr[i]) && !rus)
                    return false;
            }
            for (int i = 0; i < latArr.Length; i++)
            {
                if (password.Contains(latArr[i]) && !lat)
                    return false;
            }
            return true;
        }
        public static bool ValidDate(DateTime regTime)
        {
            DataTable dt = MainForm.GetDataTable("select days From \"GD_Kassa\".password_policy");
            int days = Int32.Parse(dt.Rows[0][0].ToString());
            if (DateTime.Now >= regTime.AddDays(days))
                return false;
            return true;
        }
        public static void DeleteCurrentUser() => current = null;
    }
}
