using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentGame.Engine
{
    public abstract class Scene
    {
        public List<Shape2D> AllShapes = new List<Shape2D>();
        public List<Sprite2D> AllSprites = new List<Sprite2D>();
        public List<Button> AllGameButtons = new List<Button>();
        public List<TextBox> AllGameTextBoxes = new List<TextBox>();
        public string Tag;

        public static int SceneId;
        public readonly int ID;

        public Scene()
        {
            this.ID = SceneId;
            SceneId++;

            Engine.RegisterScene(this);
        }

        public void RegisterShape(Shape2D shape)
        {
            AllShapes.Add(shape);
            Log.Info($"[SHAPE2D] ({shape.Tag}) - Has been registered");
        }
        public void UnRegisterShape(Shape2D shape)
        {
            AllShapes.Remove(shape);
            Log.Info($"[SHAPE2D] ({shape.Tag}) - Has been destroyed");
        }


        public void RegisterSprite(Sprite2D sprite)
        {
            AllSprites.Add(sprite);
            Log.Info($"[SPRITE2D] ({sprite.Tag}) - Has been registered");
        }
        public void UnRegisterSprite(Sprite2D sprite)
        {
            AllSprites.Remove(sprite);
            Log.Info($"[SPRITE2D] ({sprite.Tag}) - Has been destroyed");
        }


        public void RegisterButton(Button button)
        {
            AllGameButtons.Add(button);
            Log.Info($"[BTN] ({button.Tag}) - Has been registered");
        }
        public void UnRegisterButton(Button button)
        {
            AllGameButtons.Remove(button);
            Form.ActiveForm.Controls.Remove(button);
            Log.Info($"[BTN] ({button.Tag}) -  Has been destroyed");
        }


        public void RegisterTextBox(TextBox textBox)
        {
            AllGameTextBoxes.Add(textBox);
            Log.Info($"[TXTBOX] ({textBox.Tag}) - Has been registered");
        }
        public void UnRegisterTextBox(TextBox textBox)
        {
            AllGameTextBoxes.Remove(textBox);
            Form.ActiveForm.Controls.Remove(textBox);
            Log.Info($"[TXTBOX] ({textBox.Tag}) - Has been destroyed");
        }

        public abstract void OnLoad();
        public abstract void OnUpdate();
    }
}
