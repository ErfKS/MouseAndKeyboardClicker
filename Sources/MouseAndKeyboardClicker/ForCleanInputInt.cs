using System;

namespace AutoClickerMouseAndKeyboard
{
    public static partial class INI_Creator
    {
        public class ForCleanInputInt
        {
            
            /// <summary>
            /// To set value by user without error
            /// </summary>
            /// <param name="message">To show message for user before ser value</param>
            /// <returns></returns>
            public static int GetValue(string message = "")
            {
                int returnInt = 0;
                while (true)
                {
                    if(message != "")
                        Console.WriteLine(message);
                    try
                    {
                        returnInt = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                
                return returnInt;
            }
        }
    }
}