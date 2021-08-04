using System;
namespace AutoClickerMouseAndKeyboard
{
    public struct Date_Time_String
    {
        public string Year, Month, Day, Hour, Minute, Second;
        public Date_Time_String(string year , string month , string day , string hour, string minute, string second)
        {
            
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minute = minute;
            Second = second;
        }
        
        public Date_Time_String(int year , int month , int day , int hour, int minute, int second)
        {
            
            Year = year.ToString();
            Month = month.ToString();
            Day = day.ToString();
            Hour = hour.ToString();
            Minute = minute.ToString();
            Second = second.ToString();
        }

        public Date_Time_String(DateTime dateTime)
        {
            Year = dateTime.Year.ToString();
            Month = dateTime.Month.ToString();
            Day = dateTime.Day.ToString();
            Hour = dateTime.Hour.ToString();
            Minute = dateTime.Minute.ToString();
            Second = dateTime.Second.ToString();
        }

        public DateTime GetDateTime
        {
            get
            {
                int intYear = AutoClickerMouseAndKeyboard.GetDateTime.GetCurrentTime(TimeType.Year, Year);
                int intMonth = AutoClickerMouseAndKeyboard.GetDateTime.GetCurrentTime(TimeType.Month, Month);
                int intDay = AutoClickerMouseAndKeyboard.GetDateTime.GetCurrentTime(TimeType.Day, Day);
                int intHour = AutoClickerMouseAndKeyboard.GetDateTime.GetCurrentTime(TimeType.Hour, Hour);
                int intMinute = AutoClickerMouseAndKeyboard.GetDateTime.GetCurrentTime(TimeType.Minute, Minute);
                int intSecond = AutoClickerMouseAndKeyboard.GetDateTime.GetCurrentTime(TimeType.Second, Second);
                DateTime dateTimeForReturn = new DateTime(intYear, intMonth, intDay, intHour, intMinute, intSecond);
                return dateTimeForReturn;
            }
        }
    }
}