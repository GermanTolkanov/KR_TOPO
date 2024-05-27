using Npgsql;

namespace TestProject1
{
    [TestClass]
    public class ConnectionTests
    {
        [TestMethod]
        public void ValidConnection()
        {
            NpgsqlConnection npgsql = new NpgsqlConnection("Server=localhost;Port=5432;User ID=postgres;Password=admin123;Database=postgres");
            npgsql.Open();
        }
        [TestMethod]
        [ExpectedException((typeof(PostgresException)))]
        public void InvalidConnection()
        {
            NpgsqlConnection npgsql = new NpgsqlConnection("Server=localhost;Port=5432;User ID=postgres;Password=postgres;Database=postgres");
            npgsql.Open();
        }
    }
}