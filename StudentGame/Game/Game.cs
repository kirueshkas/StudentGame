using StudentGame.Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace StudentGame.Game
{
    public class Game : Engine.Engine
    {
        MenuScene Menu = new MenuScene { Tag = "menu" };
        //Scene Options = new Scene { Tag = "options" };
        EditorScene Editor = new EditorScene { Tag = "editor" };

        public Game() : base(new Vector2(1000,600), "Game")
        {
        }

        public override void OnLoad()
        {
            Menu.CreateMenu();
            Editor.CreateEdtior();
        }

        public override void OnUpdate()
        {
            Menu.OnUpdate();
        }
    }
}
