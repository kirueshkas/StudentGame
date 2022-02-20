using StudentGame.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace StudentGame.Game
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Password { get; set; }
        public string Sex { get; set; } = "man";
        public string Body { get; set; } = "0";
        public string Leg { get; set; } = "0";

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
