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
        public string DB { get; } = "localDB";
        public bool IsEmpty
        {
            get
            {
                try
                {
                    GetLastUserId();
                    return false;
                }
                catch
                {
                    return true;
                }
            }
        }

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

        public void RefreshUserByIdFromServer(int id)
        {
            this.DeleteAllUsers();
            MySQL refreshDB = new MySQL();
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

        public void DeleteUserById(int id)
        {
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString(DB)))
            {
                con.Execute($"DELETE FROM Users WHERE Id = {id};" +
                    "UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = 'Users';");
            }
        }

        private string LoadConnectionString(string id)
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
