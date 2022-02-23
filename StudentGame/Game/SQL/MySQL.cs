using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;

namespace StudentGame.Game
{
    public class MySQL
    {
        public string DB { get; set; } = "serverDB";
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
            using (IDbConnection con = new MySqlConnection(LoadConnectionString(DB)))
            {
                return (int)con.QueryFirst($"SELECT Id FROM Users ORDER BY id DESC").Id;
            }
        }

        public User GetUser(string name, string secondName)
        {
            using (IDbConnection con = new MySqlConnection(LoadConnectionString(DB)))
            {
                var sql = $"SELECT * FROM Users WHERE FirstName = '{name}' AND SecondName = '{secondName}'";
                return con.QueryFirst<User>(sql);
            }
        }

        public User GetUser(int id)
        {
            using (IDbConnection con = new MySqlConnection(LoadConnectionString(DB)))
            {
                return con.QueryFirst<User>($"SELECT * FROM Users WHERE id = {id}");
            }
        }

        public void SaveUser(User user)
        {
            using (IDbConnection con = new MySqlConnection(LoadConnectionString(DB)))
            {
                con.Execute("INSERT INTO Users (FirstName, SecondName, Password, Sex, Body, Leg) VALUES (@FirstName, @SecondName, @Password, @Sex, @Body, @Leg)", user);
            }
        }

        public void UpdateUserClothes(User user)
        {
            using (IDbConnection con = new MySqlConnection(LoadConnectionString(DB)))
            {
                con.Execute("UPDATE Users SET Sex = @Sex, Body = @Body, Leg = @Leg WHERE Id = @Id", user);
            }
        }

        private string LoadConnectionString(string id)
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
