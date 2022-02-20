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
    public class SQLiteAcess
    {
        public SQLiteAcess(string DB)
        {
            this.DB = DB;
        }

        public string DB { get; }

        public int GetLastUserId()
        {
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString(DB)))
            {
                return (int)con.QueryFirst($"SELECT Id FROM Users ORDER BY id DESC").Id;
            }
        }

        public User FindUser(User user)
        {
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString(DB)))
            {
                return con.QueryFirst<User>($"SELECT * FROM Users WHERE firstName = @FirstName AND secondName = @SecondName", user);
            }
        }

        public User GetUser(int id)
        {
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString(DB)))
            {
                return con.QueryFirst<User>($"SELECT * FROM Users WHERE id = {id}");
            }
        }

        public void SaveUser(User user)
        {
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString(DB)))
            {
                con.Execute("INSERT INTO Users (firstName, secondName, password) VALUES (@FirstName, @SecondName, @Password)", user);
            }
        }

        public void SaveUserLocal(User user)
        {
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString(DB)))
            {
                con.Execute("INSERT INTO Users (Id, FirstName, SecondName) VALUES (@Id, @FirstName, @SecondName)", user);
            }
        }

        public void DeleteAllUsers()
        {
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString(DB)))
            {
                con.Execute("DELETE FROM Users;" +
                    "UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = 'Users';");
            }
        }

        private string LoadConnectionString(string id)
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
