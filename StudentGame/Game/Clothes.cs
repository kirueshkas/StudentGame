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
    class Clothes
    {
        public static Sprite2D body1 = new Sprite2D(new Point(870, 700), "body1", Resource.Body1);
        public static Sprite2D body2 = new Sprite2D(new Point(870, 700), "body2", Resource.Body2);
        public static Sprite2D body3 = new Sprite2D(new Point(870, 700), "body3", Resource.Body3);
        public static Sprite2D body4 = new Sprite2D(new Point(870, 700), "body4", Resource.Body4);
        public static Sprite2D body5 = new Sprite2D(new Point(870, 700), "body5", Resource.Body5);

        public static Sprite2D leg1 = new Sprite2D(new Point(900, 840), "leg1", Resource.Leg1);
        public static Sprite2D leg2 = new Sprite2D(new Point(900, 840), "leg2", Resource.Leg2);
        public static Sprite2D leg3 = new Sprite2D(new Point(900, 840), "leg3", Resource.Leg3);
        public static Sprite2D leg4 = new Sprite2D(new Point(900, 840), "leg4", Resource.Leg4);
        public static Sprite2D leg5 = new Sprite2D(new Point(900, 840), "leg5", Resource.Leg5);

        public static Sprite2D manHair1 = new Sprite2D(new Point(870, 520), "leg1", Resource.ManHair1);
        public static Sprite2D manHair2 = new Sprite2D(new Point(870, 520), "leg1", Resource.ManHair2);

        public static Sprite2D womanHair1 = new Sprite2D(new Point(870, 520), "leg1", Resource.WomanHair1);
        public static Sprite2D womanHair2 = new Sprite2D(new Point(870, 520), "leg1", Resource.WomanHair2);


        public static Sprite2D[] BodyClothes = new Sprite2D[]
        {
            body1,
            body2,
            body3,
            body4,
            body5
        };
        public static int bodyIndex = 0;

        public static Sprite2D[] LegClothes = new Sprite2D[]
        {
            leg1,
            leg2,
            leg3,
            leg4,
            leg5
        };
        public static int legIndex = 0;

        public static int hairIndex = 0;
        public static Sprite2D[] ManHair = new Sprite2D[]
        {
            manHair1,
            manHair2
        };

        public static Sprite2D[] WomanHair = new Sprite2D[]
        {
            womanHair1,
            womanHair2
        };
    }
}
