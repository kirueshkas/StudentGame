using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentGame.Engine
{
    public class Interface
    {
        public static Screen screen = Screen.PrimaryScreen;
        static double formWidth = screen.Bounds.Width;
        static double formHeight = screen.Bounds.Height;
        public static double resolutionX = (1 / (double)(1920) * formWidth);
        public static double resolutionY = (1 / (double)(1080) * formHeight);

        public static TextBox CreateTextBox(int width, int height, int x, int y, string text, int tabIndex)
        {
            TextBox textBox = new TextBox
            {
                Size = new Size((int)(width * resolutionX), (int)(height * resolutionY)),
                Location = new Point((int)(x * resolutionX), (int)(y * resolutionY)),
                Text = text,
                Name = text,
                TabIndex = tabIndex,
                Font = new Font("Microsoft Sans Serif", (int)(20 * resolutionX)),
                ForeColor = Color.Gray,
            };
            textBox.Multiline = true;
            textBox.Enter += TextBoxEnter;
            textBox.Leave += TextBoxLeave;
            return textBox;
        }
        public static Button CreateButton(int width, int height, int x, int y, string text, string Tag, Bitmap texture = null, bool IsText = true)
        {
            if (texture ==null)
                texture = Resource.button_menu;

            Button button = new Button
            {
                Size = new Size((int)(width * resolutionX), (int)(height * resolutionY)),
                Location = new Point((int)(x * resolutionX), (int)(y * resolutionY)),
                Name = text,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                BackgroundImage = texture,
                BackgroundImageLayout = ImageLayout.Stretch,
                Tag = Tag
            };
            button.Text = IsText ? text : null;
            button.FlatAppearance.BorderSize = 0;
            button.Font = new Font("Microsoft Sans Serif", (int)(25 * resolutionX));
            button.MouseEnter += Button_MouseEnter;
            button.MouseLeave += Button_MouseLeave;
            return button;
        }

        private static void Button_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text != "")
            {
                button.Location = new Point(button.Location.X, button.Location.Y );
                button.BackgroundImage = Resource.button_menu1;
            }
        }

        private static void Button_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text != "")
            {
                button.Location = new Point(button.Location.X, button.Location.Y );
                button.BackgroundImage = Resource.button_menu;
            }
        }

        public static void TextBoxEnter(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (textbox.Text == textbox.Name)
            {
                textbox.ForeColor = Color.Black;
                textbox.Text = "";
                if (textbox.Name == "Password")
                {
                    textbox.PasswordChar = '●';
                }
            }


        }
        public static void TextBoxLeave(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (textbox.Text == "")
            {
                textbox.ForeColor = Color.Gray;
                textbox.Text = textbox.Name;
                if (textbox.Name == "Password")
                {
                    textbox.PasswordChar = default;
                }
            }
        }
    }
}
