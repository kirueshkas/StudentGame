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
                    GetUser(1);
                    return false;
                }
                catch
                {
                    return true;
                }
            }
        }

        public User GetUser(int NoteId)
        {
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString(DB)))
            {
                return con.QueryFirst<User>($"SELECT * FROM Users WHERE NoteId = {NoteId}");
            }
        }

        public void SaveUser(User user)
        {
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString(DB)))
            {
                con.Execute("UPDATE Users SET Id = @Id, FirstName = @FirstName, SecondName = @SecondName, Sex = @Sex, Body = @Body, Leg = @Leg WHERE NoteId = 1", user);
            }
        }

        public void UpdateUserClothes(User user)
        {
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString(DB)))
            {
                con.Execute("UPDATE Users SET Sex = @Sex, Body = @Body, Leg = @Leg WHERE NoteId = 1", user);
            }
        }

        public void RefreshUserByIdFromServer(int id)
        {
            MySQL refreshDB = new MySQL();
            var user = refreshDB.GetUser(id);
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString(DB)))
            {
                con.Execute("UPDATE Users SET Id = @Id, FirstName = @FirstName, " +
                    "SecondName = @SecondName, Sex = @Sex, Body = @Body, Leg = @Leg WHERE NoteId = 1", user);
            }
        }

        private string LoadConnectionString(string id)
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
