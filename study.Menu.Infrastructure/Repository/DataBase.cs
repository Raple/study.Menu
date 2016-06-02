using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace study.Menu.Infrastructure.Repository
{
    public static class DataBase
    {
        //private static readonly string ConnectString = ConfigurationManager.ConnectionStrings["database"].ConnectionString;

        public static IDbConnection Open()
        {
            var db = new MySqlConnection("Server=127.0.0.1;Port=3306;Uid=etao;Pwd=etao123;Database=etao_menu;Charset=utf8");
            db.Open();
            return db;
        }
    }
}
