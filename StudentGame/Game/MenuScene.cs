using System;
using StudentGame.Engine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace StudentGame.Game
{
    class MenuScene : Engine.Scene
    {
        Button studikButton = Interface.CreateButton(Resource.studik.Width, Resource.studik.Height, 750, 510, "Studik", Resource.studik, "studik", false);
        Button startButton = Interface.CreateButton(330, 50, 1000, 550, "Start", Resource.button_new, "start");
        Button multiplayerButton = Interface.CreateButton(330, 50, 1000, 605, "Multiplayer", Resource.button_new, "multiplayer");
        Button optionsButton = Interface.CreateButton(330, 50, 1000, 660, "Options", Resource.button_new, "options");
        Button exitButton = Interface.CreateButton(330, 50, 1000, 715, "Exit", Resource.button_new, "exit");
        Button editorWindow = Interface.CreateButton(120, 160, 600, 550, "Editor", Resource.photo_box, "editor", false);
        TextBox nameTextBox = Interface.CreateTextBox(200, 40, 730, 550, "Name", 0);
        TextBox surNameTextBox = Interface.CreateTextBox(200, 40, 730, 600, "SurName", 1);
        TextBox passwordTextBox = Interface.CreateTextBox(200, 40, 730, 650, "Password", 2);
        static Random rnd = new Random();
        private static Sprite2D urfu = DetermineSeasonUrfu();
        private static Bitmap bush = DetermineSeasonBush();
        private static Sprite2D[] stars;
        private static Sprite2D moonSun;
        static Sprite2D[] bushes = CreateBushesArray(6);
        static Sprite2D[] clouds = CreateCloudsArray(9);
        Sprite2D openStudik = new Sprite2D(new Point(550, 510), "openStudik", Resource.studik_open_clear);
        Sprite2D flag = new Sprite2D(new Point(957, 180), "flag", Resource.flag_rus_sheet, 6);


        public  void CreateMenu()
        {
            //Engine.Engine.BackgroundColor = Color.SkyBlue;
            moonSun = new Sprite2D(SeasonAndTime.DeterminePositionByDurationTime(720, new Size(1920, 1080)), "moonOrSun", DetermineTime(), 4, 100);
            RegisterSprite(moonSun);

            if (stars != null)
            {
                foreach (var star in stars)
                    RegisterSprite(star);
            }

            foreach (var cloud in clouds)
                this.RegisterSprite(cloud);
            
            this.RegisterSprite(urfu);
            this.RegisterSprite(flag);
            
            foreach (var bush in bushes)
                this.RegisterSprite(bush);
            
            this.RegisterButton(studikButton);
            studikButton.Click += StudikButton_Click;
        }

        public override void OnLoad()
        {
            CreateMenu();
        }

        public override void OnUpdate()
        {
            foreach (var cloud in clouds)
                if (cloud.position.X < 1920) cloud.position.X++; else cloud.position.X = -cloud.size.Width;
            moonSun.position = SeasonAndTime.DeterminePositionByDurationTime(720, new Size(1920, 1080));
        }


        static Sprite2D[] CreateBushesArray(int count)
        {
            Sprite2D[] bushes = new Sprite2D[count];
            int[,] param = new int[,] {
                { -30, 880, 150 },
                { 70, 920, 120 },
                { -15, 935, 120 },
                { 1790, 880, 150 },
                { 1690, 900, 140 },
                { 1820, 930, 120 } };

            for (int i = 0; i < count; i++)
                bushes[i] = new Sprite2D(new Point(param[i, 0], param[i, 1]), "bush" + i, bush, 4, param[i, 2]);
            return bushes;
        }
        static Sprite2D[] CreateCloudsArray(int count)
        {
            Sprite2D[] clouds = new Sprite2D[count];
            int[,] param = new int[,] {
                { 10, 350, 90 },
                { 30, 50, 60 },
                { 610, 150, 50 },
                { 910, 50, 50 },
                { 1310, 300, 90 },
                { 1510, 100, 60 },
                { 1910, 10, 50 },
                { 1010, 400, 100 },
                { 1800, 200, 70 },};

            for (int i = 0; i < count; i++)
                clouds[i] = new Sprite2D(new Point(param[i, 0], param[i, 1]), "cloud", Resource.cloud1_sheet_x10, 6, param[i, 2]);
            return clouds;
        }

        static Sprite2D[] CreateStarsArray(int count)
        {
            var stars = new Sprite2D[count];
            var positionAndScale = new int[count, 3];
            var random = new Random();
            for (int i = 0; i < count; i++)
            {
                positionAndScale[i, 0] = random.Next(1920);
                positionAndScale[i, 1] = random.Next(700);
                positionAndScale[i, 2] = random.Next(25, 100);
            }

            for (int i = 0; i < count; i++)
            {
                Bitmap star;
                switch (random.Next(1, 3))
                {
                    case 1:
                        star = Resource.star1;
                        break;
                    case 2:
                        star = Resource.star2;
                        break;
                    case 3:
                        star = Resource.star3;
                        break;
                    default:
                        star = Resource.star1;
                        break;
                }
                stars[i] = new Sprite2D(new Point(positionAndScale[i, 0], positionAndScale[i, 1]), "star" + (i + 1),
                    star, 4);
            }

            return stars;
        }


        private void StudikButton_Click(object sender, EventArgs e)
        {
            if (studikButton != null)
            {
                this.UnRegisterButton(studikButton);
                studikButton = null;
            }

            this.RegisterSprite(openStudik);

            this.RegisterButton(startButton);
            this.RegisterButton(multiplayerButton);
            this.RegisterButton(optionsButton);
            this.RegisterButton(exitButton);
            this.RegisterButton(editorWindow);

            this.RegisterTextBox(nameTextBox);
            this.RegisterTextBox(surNameTextBox);
            this.RegisterTextBox(passwordTextBox);
            editorWindow.Click += EditorWindow_Click;
            exitButton.Click += ExitButton_Click;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Engine.Engine.GetScene("menu");
        }

        private void EditorWindow_Click(object sender, EventArgs e)
        {
            Engine.Engine.GetScene("editor");
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private static Sprite2D DetermineSeasonUrfu()
        {
            var season = SeasonAndTime.Season;
            switch (season)
            {
                case SeasonAndTime.Seasons.Summer:
                    return new Sprite2D(new Point(0, 0), "urfu", Resource.urfu_summer);
                case SeasonAndTime.Seasons.Autumn:
                    return new Sprite2D(new Point(0, 0), "urfu", Resource.urfu_fall);
                case SeasonAndTime.Seasons.Winter:
                    return new Sprite2D(new Point(0, 0), "urfu", Resource.urfu_winter);
                case SeasonAndTime.Seasons.Spring:
                    return new Sprite2D(new Point(0, 0), "urfu", Resource.urfu_spring);
                default:
                    return new Sprite2D(new Point(0, 0), "urfu", Resource.urfu_new_1920_1080);
            }
        }
        
        private static Bitmap DetermineSeasonBush()
        {
            var season = SeasonAndTime.Season;
            switch (season)
            {
                case SeasonAndTime.Seasons.Summer:
                    return Resource.bush_summer_Sheet;
                case SeasonAndTime.Seasons.Autumn:
                    return Resource.bush_fall_Sheet;
                case SeasonAndTime.Seasons.Winter:
                    return Resource.bush_winter_Sheet;
                case SeasonAndTime.Seasons.Spring:
                    return  Resource.bush_spring_Sheet;
                default:
                    return Resource.bush_summer_Sheet;
            }
        }

        private static Bitmap DetermineTime()
        {
            var dayTime = SeasonAndTime.DayTime;
            switch (dayTime)
            {
                case SeasonAndTime.TimesDay.Morning:
                    Engine.Engine.BackgroundColor = Color.Beige;
                    return Resource.sun;
                case SeasonAndTime.TimesDay.Day:
                    Engine.Engine.BackgroundColor = Color.SkyBlue;
                    return Resource.sun;
                case SeasonAndTime.TimesDay.Evening:
                    Engine.Engine.BackgroundColor = Color.FromArgb(250, 214, 165);
                    return Resource.moon;
                case SeasonAndTime.TimesDay.Night:
                {
                    Engine.Engine.BackgroundColor = Color.FromArgb(29, 29, 29);
                    stars = CreateStarsArray(20);
                }
                    return Resource.moon;
                default:
                    return Resource.sun;
            }
        }
    }
}
