using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGame.Game
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Password { get; set; }

        public static string sex = "man";

        //clothes

        public string FullInfo
        {
            get
            {
                return $"{Id} {FirstName} {SecondName} {Password}";
            }
        }
    }
}