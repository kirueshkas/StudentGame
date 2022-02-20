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

        public User GetUser(string name, string secondName)
        {
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString(DB)))
            {
                var sql = $"SELECT * FROM Users WHERE FirstName = '{name}' AND SecondName = '{secondName}'";
                return con.QueryFirst<User>(sql);
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
                con.Execute("INSERT INTO Users (FirstName, SecondName, Password, Sex, Body, Leg) VALUES (@FirstName, @SecondName, @Password, @Sex, @Body, @Leg)", user);
            }
        }

        public void SaveUserLocal(User user)
        {
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString(DB)))
            {
                con.Execute("INSERT INTO Users (Id, FirstName, SecondName, Sex, Body, Leg) VALUES (@Id, @FirstName, @SecondName, @Sex, @Body, @Leg)", user);
            }
        }

        public void UpdateUserClothes(User user)
        {
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString(DB)))
            {
                con.Execute("UPDATE Users SET Sex = @Sex, Body = @Body, Leg = @Leg WHERE Id = @Id", user);
            }
        }

        public void RefreshUserByIdFrom(int id, string db)
        {
            this.DeleteAllUsers();
            SQLiteAcess refreshDB = new SQLiteAcess(db);
            var user = refreshDB.GetUser(id);
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString(DB)))
            {
                con.Execute("INSERT INTO Users (Id, FirstName, SecondName, Sex, Body, Leg) VALUES (@Id, @FirstName, @SecondName, @Sex, @Body, @Leg)", user);
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
