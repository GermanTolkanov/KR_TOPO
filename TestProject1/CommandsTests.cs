using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Methods4Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class CommandsTests
    {
        [TestMethod]
        public void Test1ValidSelect()
        {
            DataTable dt = Methods.GetDataTable($"select (\"Цена\") from \"GD_Kassa\".class where \"Класс\" = \'СВ\'");
            Assert.AreEqual("7000", dt.Rows[0]["Цена"].ToString());
        }
        [TestMethod]
        [ExpectedException((typeof(PostgresException)))]
        public void Test2InvlaidSelect()
        {
            DataTable dt = Methods.GetDataTable($"select (\"Цена312\") from \"GD_Kassa\".class where \"Класс\" = \'СВ\'");
            Assert.AreEqual("7000", dt.Rows[0]["Цена"].ToString());
        }
        [TestMethod]
        public void Test3ValidAdd()
        {
            NpgsqlCommand SQLcmd = new NpgsqlCommand($"insert into \"GD_Kassa\".class (\"Класс\", \"Цена\") values (@p1, @p2)", Methods.sqlConn);
            SQLcmd.Parameters.AddWithValue("p1", "newClass");
            SQLcmd.Parameters.AddWithValue("p2", "22222");
            SQLcmd.ExecuteNonQuery();
            DataTable dt = Methods.GetDataTable($"select (\"Цена\") from \"GD_Kassa\".class where \"Класс\" = \'newClass\'");
            Assert.AreEqual("22222", dt.Rows[0]["Цена"].ToString());
        }
        [TestMethod]
        [ExpectedException((typeof(PostgresException)))]
        public void Test4InvalidAdd()
        {
            NpgsqlCommand SQLcmd = new NpgsqlCommand($"insert into \"GD_Kassa\".class421 (\"Класс\", \"Цена\") values (@p1, @p2)", Methods.sqlConn);
            SQLcmd.Parameters.AddWithValue("p1", "newClass");
            SQLcmd.Parameters.AddWithValue("p2", "22222");
            SQLcmd.ExecuteNonQuery();
            DataTable dt = Methods.GetDataTable($"select (\"Цена\") from \"GD_Kassa\".class where \"Класс\" = \'newClass\'");
            Assert.AreEqual("22222", dt.Rows[0]["Цена"].ToString());
        }
        [TestMethod]
        public void Test5ValidUpdate()
        {
            NpgsqlCommand SQLcmd = new NpgsqlCommand($"update \"GD_Kassa\".class SET \"Цена\" = @p1 where \"Класс\" = @p2", Methods.sqlConn);
            SQLcmd.Parameters.AddWithValue("p1", "33333");
            SQLcmd.Parameters.AddWithValue("p2", "newClass");
            SQLcmd.ExecuteNonQuery();
            DataTable dt = Methods.GetDataTable($"select (\"Цена\") from \"GD_Kassa\".class where \"Класс\" = \'newClass\'");
            Assert.AreEqual("33333", dt.Rows[0]["Цена"].ToString());
        }
        [TestMethod]
        [ExpectedException((typeof(PostgresException)))]
        public void Test6InvalidUpdate()
        {
            NpgsqlCommand SQLcmd = new NpgsqlCommand($"update \"GD_Kassa\".class SET \"Цена\" = @p1svz wherezzz \"Класс\" = @p2", Methods.sqlConn);
            SQLcmd.Parameters.AddWithValue("p1", "33333");
            SQLcmd.Parameters.AddWithValue("p2", "newClass");
            SQLcmd.ExecuteNonQuery();
            DataTable dt = Methods.GetDataTable($"select (\"Цена\") from \"GD_Kassa\".class where \"Класс\" = \'newClass\'");
            Assert.AreEqual("33333", dt.Rows[0]["Цена"].ToString());
        }
        [TestMethod]
        public void Test7ValidDelete()
        {
            NpgsqlCommand SQLcmd = new NpgsqlCommand($"delete from \"GD_Kassa\".class where \"Класс\" = @p1", Methods.sqlConn);
            SQLcmd.Parameters.AddWithValue("p1", "newClass");
            SQLcmd.ExecuteNonQuery();
            DataTable dt = Methods.GetDataTable($"select (\"Цена\") from \"GD_Kassa\".class where \"Класс\" = \'newClass\'");
            Assert.AreEqual(0, dt.Rows.Count);
        }
        [TestMethod]
        [ExpectedException((typeof(PostgresException)))]
        public void Test8InvalidDelete()
        {
            NpgsqlCommand SQLcmd = new NpgsqlCommand($"delete from \"GD_Kassa\".class where \"Класс312\" = @p1", Methods.sqlConn);
            SQLcmd.Parameters.AddWithValue("p1", "newClass");
            SQLcmd.ExecuteNonQuery();
            DataTable dt = Methods.GetDataTable($"select (\"Цена\") from \"GD_Kassa\".class where \"Класс\" = \'newClass\'");
            Assert.AreEqual(0, dt.Rows.Count);
        }
    }
}
