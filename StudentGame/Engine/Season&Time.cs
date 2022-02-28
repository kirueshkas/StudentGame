using System;
using System.Drawing;
using System.Windows.Forms;

namespace StudentGame.Engine
{
    public class SeasonAndTime
    {
        public enum Seasons
        {
            Summer,
            Autumn,
            Winter,
            Spring
        };

        public enum TimesDay
        {
            Morning,
            Day,
            Evening,
            Night
        };

        public static Seasons Season = DetermineSeason();
        public static TimesDay DayTime = DetermineTimeDay();
        private static DateTime timeNow;

        private static Seasons DetermineSeason()
        {
            timeNow = DateTime.Now;
            var month = timeNow.Month;
            if (month < 3 || month == 12) 
                Season = Seasons.Winter;
            if (month > 2 && month < 6)
                Season = Seasons.Spring;
            if (month > 5 && month < 9)
                Season = Seasons.Summer;
            if (month > 8 && month < 12)
                Season = Seasons.Autumn;
            return Season;
        }

        private static TimesDay DetermineTimeDay()
        {
            timeNow = DateTime.Now;
            var time = timeNow.Hour;
            if (time < 6)
                DayTime = TimesDay.Night;
            if (time > 5 && time < 12)
                DayTime = TimesDay.Morning;
            if (time > 11 && time < 18)
                DayTime = TimesDay.Day;
            if (time > 17)
                DayTime = TimesDay.Evening;
            return DayTime;
        }

        public static Point DeterminePositionByDurationTime(int DurationInMinutes, Size windowSize )
        {
            var timeNow = DateTime.Now;
            var timeNowInMinutes = (timeNow.Hour * 60 + timeNow.Minute) % DurationInMinutes;
            var a = 8d * windowSize.Height / (3 * windowSize.Width * windowSize.Width);
            var b = -8d * windowSize.Height / (3 * windowSize.Width);
            var c = 2d * windowSize.Height / 3;
            var x = windowSize.Width * timeNowInMinutes / DurationInMinutes;
            var y = a * x * x + b * x + c;
            return new Point(x, (int) y);
        }
        

        public static Bitmap SetBrightness(Bitmap btmap, int brightness)
        {
            Bitmap temp = btmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            if (brightness < -255) brightness = -255;
            if (brightness > 255) brightness = 255;
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    int cR = c.R + brightness;
                    int cG = c.G + brightness;
                    int cB = c.B + brightness;
 
                    if (cR < 0) cR = 1;
                    if (cR > 255) cR = 255;
 
                    if (cG < 0) cG = 1;
                    if (cG > 255) cG = 255;
 
                    if (cB < 0) cB = 1;
                    if (cB > 255) cB = 255;
 
                    bmap.SetPixel(i, j, Color.FromArgb((byte)cR, (byte)cG, (byte)cB));
                }
            }
            return (Bitmap)bmap.Clone();
        }
    }
}