using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGame.Engine
{
    public class Shape2D : Interface
    {
        public Vector2 Position = null;
        public Vector2 Scale = null;
        public string Tag = "";

        public Shape2D(Vector2 Position, Vector2 Scale, string Tag)
        {
            this.Position = new Vector2((float)(Position.X * resolutionX), (float)(Position.Y * resolutionY));
            this.Scale = new Vector2((float)(Scale.X * resolutionX), (float)(Scale.Y * resolutionY));
            this.Tag = Tag;
        }

    }
}
