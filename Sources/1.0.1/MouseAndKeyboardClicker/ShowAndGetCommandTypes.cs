using System;

namespace AutoClickerMouseAndKeyboard
{
    /// <summary>
    /// Create an ini file in the above format
    /// </summary>
    public static partial class INI_Creator
    {
        private class ShowAndGetCommandTypes
        {
            /// <summary>
            /// Set CommandType by user.
            /// </summary>
            /// <returns>Return commandTypes was set by user.</returns>
            public static ListCommandTypes SetCommandTypes()
            {
                ListCommandTypes commandTypes = ListCommandTypes.Rightclick;
                while (true)
                {
                    Console.WriteLine("Enter CommandTypes\n{0}",ShowCommandTypeListString());
                    try
                    {
                        commandTypes = (ListCommandTypes)int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                return commandTypes;
            }

            /// <summary>
            /// Return all of item of list ListCommandTypes.
            /// </summary>
            /// <returns></returns>
            private static string ShowCommandTypeListString()
            {
                string[] commandListArray = Enum.GetNames(typeof(ListCommandTypes));
                string returnCommands = string.Empty;
                for (int i = 0; i < commandListArray.Length; i++)
                {
                    if (i == commandListArray.Length - 1)
                    {
                        returnCommands += i.ToString() + ":" + commandListArray[i];
                        break;
                    }
                    returnCommands += i.ToString() + ":" + commandListArray[i] + "\n";
                }
                return returnCommands;
            }
        }
    }
}