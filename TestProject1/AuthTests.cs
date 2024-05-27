using Methods4Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestClass]
    public class AuthTests
    {
        [TestMethod]
        public void ValidUser()
        {
            Assert.AreEqual(true, Methods.FindUser("admin", "admin"));
        }
        [TestMethod]
        public void InvalidLogin()
        {
            Assert.AreEqual(false, Methods.FindUser("admin421", "admin"));
        }
        [TestMethod]
        public void InvalidPassword()
        {
            Assert.AreEqual(false, Methods.FindUser("admin", "admin421"));
        }
    }
}
