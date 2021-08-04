using System;

namespace AutoClickerMouseAndKeyboard
{
    public class GetDateTime
    {
        public static int GetCurrentTime(TimeType thisTimeType, string input)
        {
            if (input.ToLower() == "n")
            {
                DateTime currentTime = DateTime.Now;
                switch (thisTimeType)
                {
                    case TimeType.Year:
                        return currentTime.Year;

                    case TimeType.Month:
                        return currentTime.Month;

                    case TimeType.Day:
                        return currentTime.Day;

                    case TimeType.Hour:
                        return currentTime.Hour;

                    case TimeType.Minute:
                        return currentTime.Minute;

                    case TimeType.Second:
                        return currentTime.Second;
                }
            }

            return int.Parse(input);
        }
    }
}