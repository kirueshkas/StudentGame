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

        public static Seasons season = DetermineSeason();
        public static TimesDay dayTime = DetermineTimeDay();
        readonly static DateTime TimeNow = DateTime.Now;

        private static Seasons DetermineSeason()
        {
            var month = TimeNow.Month;
            if (month < 3 || month == 12) 
                season = Seasons.Winter;
            if (month > 2 && month < 6)
                season = Seasons.Spring;
            if (month > 5 && month < 9)
                season = Seasons.Summer;
            if (month > 8 && month < 12)
                season = Seasons.Autumn;
            return season;
        }

        private static TimesDay DetermineTimeDay()
        {
            var time = TimeNow.Hour;
            if (time < 6)
                dayTime = TimesDay.Night;
            if (time > 5 && time < 12)
                dayTime = TimesDay.Morning;
            if (time > 11 && time < 18)
                dayTime = TimesDay.Day;
            if (time > 17)
                dayTime = TimesDay.Evening;
            return dayTime;
        }
    }
}