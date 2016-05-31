using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace study.Menu.Infrastructure.Repository
{
    public static class DataBase
    {
        private static readonly string ConnectString = ConfigurationManager.ConnectionStrings["database"].ConnectionString;

        public static IDbConnection Open()
        {
            var db = new MySqlConnection(ConnectString);
            db.Open();
            return db;
        }
    }
}
