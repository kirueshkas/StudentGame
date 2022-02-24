using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentGame.Engine
{
    class Canvas : Form
    {

        public Canvas()
        {
            ClientSize = new Size(1920, 1080);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Game";
            Text = "StudentGame";
            TopMost = true;
            WindowState = FormWindowState.Maximized;
        }
    }

    public abstract class Engine
    {
        public System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        private Vector2 WindowSize = new Vector2(512, 512);
        private string Title;
        private static Canvas Window = null;

        private Thread GameLoopThread = null;

        public static List<Scene> scenes = new List<Scene>();
        public static int SceneID = 0;

        public static Color BackgroundColor = Color.White;

        public Engine(Vector2 WindowSize, string Title)
        {
            Log.Info("Creating Game...");
            this.WindowSize = WindowSize;
            this.Title = Title;

            Window = new Canvas();
            Window.Size = new Size((int)this.WindowSize.X, (int)this.WindowSize.Y);
            Window.Text = this.Title;
            Window.Load += GameLoad;
            Window.Paint += RendererTextures;

            GameLoopThread = new Thread(GameLoop);

            GameLoopThread.Start();

            Log.Info("Game create!");

            Application.Run(Window);

        }
        private void GameLoad(object sender, EventArgs e)
        {
            timer.Interval = 10;
            timer.Tick += new EventHandler(Update);
            timer.Start();
        }
        public void Update(object sender, EventArgs e)
        {
            RendererInterface();
            Window.Invalidate();
        }

        public static void RegisterScene(Scene scene)
        {
            scenes.Add(scene);
            Log.Info($"[SCENE] ({scene.Tag}) - Has been registered");
        }
        public static void UnRegisterScene(Scene scene)
        {
            scenes.Remove(scene);
            Log.Info($"[SCENE] ({scene.Tag}) - Has been destroyed");
        }

        public static void GetScene(string tag)
        {
            Window.Controls.Clear();
            Scene newScene = scenes.Find(scene => scene.Tag == tag);
            newScene.OnLoad();
            SceneID = newScene.ID;
        }

        void GameLoop()
        {
            OnLoad();
            while (GameLoopThread.IsAlive)
            {
                try
                {
                    foreach (var sprite in scenes[SceneID].AllSprites)
                        sprite.currentFrame = sprite.currentFrame < sprite.frameAmount - 1 ? sprite.currentFrame += 1 : sprite.currentFrame = 0;
                    Window.Invoke((MethodInvoker)delegate { Window.Refresh(); });
                    OnUpdate();
                    Thread.Sleep(150);
                }
                catch
                { Log.Error("Game has not been found..."); }
            }
        }

        private static void RendererInterface()
        {
            foreach (var gameButton in scenes[SceneID].AllGameButtons)
                Window.Controls.Add(gameButton);
            foreach (var gameTextBox in scenes[SceneID].AllGameTextBoxes)
                Window.Controls.Add(gameTextBox);
        }

        private static void RendererTextures(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(BackgroundColor);
            foreach (var shape in scenes[SceneID].AllShapes)
            {
                g.FillRectangle(new SolidBrush(Color.Red), shape.Position.X, shape.Position.Y, shape.Scale.X, shape.Scale.Y);
            }

            foreach (var sprite in scenes[SceneID].AllSprites)
            {

                g.DrawImage(
                sprite.Sprite,  //Файл текстры объекта
                new Rectangle(
                    new Point(sprite.position.X, sprite.position.Y), //Позиция объекта на форме
                    new Size(sprite.size.Width, sprite.size.Height)), //Размер объекта на форме
                sprite.Sprite.Size.Width / sprite.frameAmount * sprite.currentFrame, 0, //Верхняя левая точка выреза текстуры
                sprite.Sprite.Size.Width / sprite.frameAmount * sprite.flip, sprite.Sprite.Size.Height, //Ширина и высота части текстуры, а также поворот фигуры
                GraphicsUnit.Pixel);
            }

        }

        public abstract void OnLoad();
        public abstract void OnUpdate();

    }
}
