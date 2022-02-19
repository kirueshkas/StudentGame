using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGame.Engine
{
    public class Sprite2D : Interface
    {
        public Point position;
        public Size size;
        public string Tag = "";
        public Bitmap Sprite = null;
        public int flip = 1;
        public int frameAmount = 1;
        public int currentFrame = 0;
        public int scale = 100;

        public Sprite2D(Point position, Size size, string Tag, Bitmap Sprite)
        {
            this.position = new Point((int)(position.X * resolutionX), (int)(position.Y * resolutionY));
            this.size = new Size((int)(size.Width * resolutionX), (int)(size.Height * resolutionY));
            this.Tag = Tag;
            this.Sprite = Sprite;
        }
        public Sprite2D(Point position, string Tag, Bitmap Sprite, int frameAmount = 1, int scale = 100)
        {
            this.position = new Point((int)(position.X * resolutionX), (int)(position.Y * resolutionY));
            this.size = new Size((int)(Sprite.Width * resolutionX * scale / 100) /frameAmount, (int)(Sprite.Height * resolutionY * scale / 100));
            this.Tag = Tag;
            this.Sprite = Sprite;
            this.frameAmount = frameAmount;
            this.scale = scale;
        }

    }
}
