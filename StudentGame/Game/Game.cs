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
        //Button backButton = Interface.CreateButton(100, 50, 10, 10, "Back", Resource.button_new, "back");
        //Sprite2D secondHand = new Sprite2D(new Point(0, 0), "secondHand", Resource.character_editor);



        //Button studikButton = Interface.CreateButton(Resource.studik.Width, Resource.studik.Height, 750, 510, "Studik", Resource.studik, "studik", false);
        //Button startButton = Interface.CreateButton(330, 50, 1000, 550, "Start", Resource.button_new, "start");
        //Button multiplayerButton = Interface.CreateButton(330, 50, 1000, 605, "Multiplayer", Resource.button_new, "multiplayer");
        //Button optionsButton = Interface.CreateButton(330, 50, 1000, 660, "Options", Resource.button_new, "options");
        //Button exitButton = Interface.CreateButton(330, 50, 1000, 715, "Exit", Resource.button_new, "exit");
        //Button editorWindow = Interface.CreateButton(120, 160, 600, 550, "Editor", Resource.photo_box, "editor", false);
        //TextBox nameTextBox = Interface.CreateTextBox(200, 40, 730, 550, "Name", 0);
        //TextBox surNameTextBox = Interface.CreateTextBox(200, 40, 730, 600, "SurName", 1);
        //TextBox passwordTextBox = Interface.CreateTextBox(200, 40, 730, 650, "Password", 2);
        //Sprite2D urfu = new Sprite2D(new Point(0, 0), "urfu", Resource.urfu_new_1920_1080);
        //Sprite2D openStudik = new Sprite2D(new Point(550, 510), "openStudik", Resource.studik_open_clear);
        




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

            
           //// Options.RegisterButton(backButton);
           // backButton.Click += BackButton_Click; ;

           // Editor.RegisterButton(backButton);
           // Editor.RegisterSprite(secondHand);
        }

        public override void OnUpdate()
        {
            Menu.OnUpdate();
        }

        //static Random rnd = new Random();

        //static Sprite2D[] bushes = CreateBushesArray(6);
        //static Sprite2D[] clouds = CreateCloudsArray(9);

        //static Sprite2D[] CreateBushesArray(int count)
        //{
        //    Sprite2D[] bushes = new Sprite2D[count];
        //    int[,] param = new int[,] { 
        //        { -30, 880, 150 }, 
        //        { 70, 920, 120 }, 
        //        { -15, 935, 120 }, 
        //        { 1790, 880, 150 }, 
        //        { 1690, 900, 140 }, 
        //        { 1820, 930, 120 } };

        //    for (int i = 0; i < count; i++)
        //        bushes[i] = new Sprite2D(new Point(param[i, 0], param[i, 1]), "bush" + i, Resource.bush_summer_Sheet, 4, param[i, 2]);
        //    return bushes;
        //}
        //static Sprite2D[] CreateCloudsArray(int count)
        //{
        //    Sprite2D[] clouds = new Sprite2D[count];
        //    int[,] param = new int[,] {
        //        { 10, 350, 90 },
        //        { 30, 50, 60 },
        //        { 610, 150, 50 },
        //        { 910, 50, 50 },
        //        { 1310, 300, 90 },
        //        { 1510, 100, 60 },
        //        { 1910, 10, 50 },
        //        { 1010, 400, 100 },
        //        { 1800, 200, 70 },};

        //    for (int i = 0; i < count; i++)
        //        clouds[i] = new Sprite2D(new Point(param[i, 0], param[i, 1]),"cloud", Resource.cloud1_sheet_x10, 6, param[i, 2]);
        //    return clouds;
        //}

        //public void CreateMenu()
        //{
        //    BackgroundColor = Color.SkyBlue;
            
        //    foreach (var cloud in clouds)
        //        Menu.RegisterSprite(cloud);

        //    Menu.RegisterSprite(urfu);
        //    Menu.RegisterSprite(flag);

        //    foreach (var bush in bushes)
        //        Menu.RegisterSprite(bush);

        //    Menu.RegisterButton(studikButton);
        //    studikButton.Click += StudikButton_Click;
        //}






    //    private void StudikButton_Click(object sender, EventArgs e)
    //    {
    //        if (studikButton != null)
    //        {
    //            Menu.UnRegisterButton(studikButton);
    //            studikButton = null;
    //        }

    //        Menu.RegisterSprite(openStudik);

    //        Menu.RegisterButton(startButton);
    //        Menu.RegisterButton(multiplayerButton);
    //        Menu.RegisterButton(optionsButton);
    //        Menu.RegisterButton(exitButton);
    //        Menu.RegisterButton(editorWindow);

    //        Menu.RegisterTextBox(nameTextBox);
    //        Menu.RegisterTextBox(surNameTextBox);
    //        Menu.RegisterTextBox(passwordTextBox);
    //        editorWindow.Click += EditorWindow_Click;
    //        optionsButton.Click += OptionsButton_Click;
    //        exitButton.Click += ExitButton_Click;
    //    }


    //    private void BackButton_Click(object sender, EventArgs e)
    //    {
    //        GetScene("menu");
    //    }

    //    private void EditorWindow_Click(object sender, EventArgs e)
    //    {
    //        GetScene("editor");
    //    }

    //    private void OptionsButton_Click(object sender, EventArgs e)
    //    {
    //        GetScene("options");
    //    }

    //    private void ExitButton_Click(object sender, EventArgs e)
    //    {
    //        Application.Exit();
    //    }
    }
}
