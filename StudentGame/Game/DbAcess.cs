using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using Dapper;

namespace StudentGame.Game
{
    public class DbAcess
    {
        public User GetLastUser()
        {
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString("localDB")))
            {
                return con.QueryFirst<User>($"SELECT * FROM Users ORDER BY id DESC");
            }
        }

        public User GetUser(int id)
        {
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString("localDB")))
            {
                return con.QueryFirst<User>($"SELECT * FROM Users WHERE id = {id}");
            }
        }
        public void SaveUser(User user)
        {
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString("localDB")))
            {
                con.Execute("INSERT INTO Users (firstName, secondName, password) VALUES (@FirstName, @SecondName, @Password)", user);
            }
        }
        private string LoadConnectionString(string id)
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
