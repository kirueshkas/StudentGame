using System;
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
    }
}