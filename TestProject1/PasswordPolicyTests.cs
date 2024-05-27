using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Methods4Tests;

namespace TestProject1
{
    [TestClass]
    public class PasswordPolicyTests
    {
        [TestMethod]
        public void Test1PasswordLength()
        {
            Assert.AreEqual(false, Methods.ValidPassword("adm"));
            Assert.AreEqual(true, Methods.ValidPassword("admin"));
            Assert.AreEqual(true, Methods.ValidPassword("admin213"));
            Assert.AreEqual(true, Methods.ValidPassword("admin1234567890A"));
            Assert.AreEqual(false, Methods.ValidPassword("admin1234567890AC"));
        }
        [TestMethod]
        public void Test2PasswordRus()
        {
            Assert.AreEqual(true, Methods.ValidPassword("АБВШывф"));
        }
        [TestMethod]
        public void Test3PasswordLat()
        {
            Assert.AreEqual(true, Methods.ValidPassword("qeDDSeq"));
        }
        [TestMethod]
        public void Test4PasswordSpec()
        {
            Assert.AreEqual(false, Methods.ValidPassword("!@#@qe4eq8"));
        }
    }
}
