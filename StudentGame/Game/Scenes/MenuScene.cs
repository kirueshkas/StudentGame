using System;
using StudentGame.Engine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

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
        Button registerButton = Interface.CreateButton(330, 50, 600, 715, "Register", Resource.button_new, "register");
        Button signOutButton = Interface.CreateButton(200, 40, 730, 650, "Sign out", Resource.button_new, "signOut");
        TextBox nameTextBox = Interface.CreateTextBox(200, 40, 730, 550, "Name", 0);
        TextBox surNameTextBox = Interface.CreateTextBox(200, 40, 730, 600, "SurName", 1);
        TextBox passwordTextBox = Interface.CreateTextBox(200, 40, 730, 650, "Password", 2);
        Sprite2D urfu = new Sprite2D(new Point(0, 0), "urfu", Resource.urfu_new_1920_1080);
        Sprite2D openStudik = new Sprite2D(new Point(550, 510), "openStudik", Resource.studik_open_clear);
        Sprite2D flag = new Sprite2D(new Point(957, 180), "flag", Resource.flag_rus_sheet, 6);

        SQLiteAcess localDB = new SQLiteAcess();
        MySQL serverDB = new MySQL();
        public static bool IsSighedIn;

        public void CreateMenu()
        {
            Engine.Engine.BackgroundColor = Color.SkyBlue;

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
        }

        public override void OnUpdate()
        {
            foreach (var cloud in clouds)
                if (cloud.position.X < 1920) cloud.position.X++; else cloud.position.X = -cloud.size.Width;
        }

        static Random rnd = new Random();

        static Sprite2D[] bushes = CreateBushesArray(6);
        static Sprite2D[] clouds = CreateCloudsArray(9);

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
                bushes[i] = new Sprite2D(new Point(param[i, 0], param[i, 1]), "bush" + i, Resource.bush_summer_Sheet, 4, param[i, 2]);
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
            this.RegisterButton(registerButton);

            this.RegisterTextBox(nameTextBox);
            this.RegisterTextBox(surNameTextBox);
            this.RegisterTextBox(passwordTextBox);

            startButton.Click += StartButton_Click;
            editorWindow.Click += EditorWindow_Click;
            exitButton.Click += ExitButton_Click;
            registerButton.Click += RegisterButton_Click;
            signOutButton.Click += SignOutButton_Click;

            this.CheckSql();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {

        }

        private void EditorWindow_Click(object sender, EventArgs e)
        {
            Engine.Engine.GetScene("editor");
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                FirstName = nameTextBox.Text,
                SecondName = surNameTextBox.Text,
                Password = passwordTextBox.Text,
                Sex = EditorScene.user.Sex,
                Body = EditorScene.bodyIndex.ToString(),
                Leg = EditorScene.legIndex.ToString()
            };
            if (!IsSighedIn)
            {
                if (user.FirstName == "Name" ||
                    user.SecondName == "SurName" ||
                    user.Password == "Password" ||
                    (user.FirstName == "local" && user.SecondName == "local"))
                    Log.Warning("Please, enter user!");
                else
                {
                    User ourUser;
                    try
                    {
                        ourUser = serverDB.GetUser(user.FirstName, user.SecondName);
                        Log.Info("User found on server!");
                        if (ourUser.Password == passwordTextBox.Text)
                            SignInUser(ourUser);
                        else
                            Log.Error("Wrong password!");
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex.Message);
                        try
                        {
                            serverDB.SaveUser(user);
                            ourUser = serverDB.GetUser(user.FirstName, user.SecondName);
                            SignInUser(ourUser);
                        }
                        catch (Exception ex2)
                        {
                            Log.Error(ex2.Message);
                            return;
                        }
                    }
                }
            }
        }

        private void CheckSql()
        {
            if (localDB.GetUser(1).FirstName != null)
            {
                var ourUser = localDB.GetUser(1);
                try
                {
                    localDB.RefreshUserByIdFromServer(ourUser.Id);
                    ourUser = localDB.GetUser(1);
                }
                catch (Exception ex)
                {
                    Log.Warning(ex.Message);
                }

                this.UnRegisterTextBox(passwordTextBox);
                this.RegisterButton(signOutButton);

                nameTextBox.Text = ourUser.FirstName;
                surNameTextBox.Text = ourUser.SecondName;
                nameTextBox.Enabled = false;
                surNameTextBox.Enabled = false;

                IsSighedIn = true;

                Log.Info("User found " + ourUser.FullInfo);
            }
            else
            {
                Log.Info("No user!");
            }
        }

        private void SignOutButton_Click(object sender, EventArgs e)
        {
            this.UnRegisterButton(signOutButton);
            this.RegisterTextBox(passwordTextBox);

            nameTextBox.Text = "Name";
            nameTextBox.ForeColor = Color.Gray;
            surNameTextBox.Text = "SurName";
            surNameTextBox.ForeColor = Color.Gray;
            passwordTextBox.Text = "Password";
            passwordTextBox.ForeColor = Color.Gray;
            passwordTextBox.PasswordChar = default;
            nameTextBox.Enabled = true;
            surNameTextBox.Enabled = true;

            User user = new User();
            localDB.SaveUser(user);

            IsSighedIn = false;

            Log.Info("User signed out!");
        }

        private void SignInUser(User ourUser)
        {
            localDB.SaveUser(ourUser);
            this.UnRegisterTextBox(passwordTextBox);
            this.RegisterButton(signOutButton);

            IsSighedIn = true;

            nameTextBox.Enabled = false;
            surNameTextBox.Enabled = false;

            Log.Info("User signed in! " + ourUser.FullInfo);
        }
    }
}
