using AutoManagenmentWakeUp;
using System.Collections.Generic;
using System;
using System.Net;
using System.Threading;
using WindowsInput.Native;

namespace AutoClickerMouseAndKeyboard
{

    /// <summary>
    /// Create an ini file in the following format
    /// <code>
    /// [Main]
    /// Year = 0
    /// Mounth = 0
    /// Day = 0
    /// Hour = 0
    /// Minute = 0
    /// Second = 0
    /// canLoop = 0
    /// Capacity = 1
    /// 
    /// [Step0]
    /// Type=0
    /// PosX = 0
    /// PosY = 0
    /// Delay = 0
    /// paragraphType = Hello World
    /// </code>
    /// </summary>
    public static partial class INI_Creator
    {
        private static List<OneCommand> ListCommand = new List<OneCommand> (0);
        private static bool canLoop = true;
        private static string INI_FileName = "CommandList.ini";
        private static string MainSection = string.Empty;
        private static string[] StepStrings = new string[0];
        private static string FinalString = string.Empty;
        private static string _Year;
        private static string _Month;
        private static string _Day;
        private static string _Hour;
        private static string _Minute;
        private static string _Second;
        
        /// <summary>
        /// Start INI Creator Mode
        /// </summary>
        public static void Start()
        {
            GetValue();
            ConvertToINIString();
            WriteFile();
            ProcessFile();
        }

        /// <summary>
        /// Run Command INI Mode base on new ini file was created (Question to the user)
        /// </summary>
        private static void ProcessFile()
        {
            switch (Boolean_Question.SetQuestionCanLooping("Do you want run base on this file?(Y/N)"))
            {
                case true:
                    Console.WriteLine();
                    Command_INI.Start(INI_FileName.Replace(".ini","")); 
                    break;
                case false:
                    Console.WriteLine();
                    Restart();
                    break;
            }
        }

        /// <summary>
        /// To restart all of program values and references.
        /// </summary>
        private static void Restart()
        {
            RestartValues();
            MainClass.RestartProgram();
        }

        /// <summary>
        /// To restart all of this class values and references.
        /// </summary>
        private static void RestartValues()
        {
            ListCommand = new List<OneCommand> (0);

            canLoop = true;
            INI_FileName = "CommandList.ini";
            MainSection = string.Empty;
            StepStrings = new string[0];
            FinalString = string.Empty;
        }

        /// <summary>
        /// To create a new *.ini file.
        /// </summary>
        private static void WriteFile()
        {
            FileManagment.WriteFile(INI_FileName , FinalString);
        }

        /// <summary>
        /// To create *.ini file content.
        /// </summary>
        private static void ConvertToINIString()
        {
            int Capacity = ListCommand.Count;
            MainSection =
                string.Format("[Main]\nYear = {0}\nMonth = {1}\nDay = {2}\nHour = {3}\nMinute = {4}\nSecond = {5}\ncanLoop = {6}\nCapacity = {7}\n\n"
                    , _Year, _Month, _Day, _Hour, _Minute, _Second , canLoop.ToString() , Capacity);
            StepStrings = new string[ListCommand.Count];

            for (int i = 0; i < StepStrings.Length; i++)
            {
                StepStrings[i] = string.Format("[Step{0}]\nType = {1}\nPosX = {2}\nPosY = {3}\nDelay = {4}\nparagraphType = {5}\n\n" 
                    , i , (int)ListCommand[i].CommandTypes , ListCommand[i].CursorPoint.X , ListCommand[i].CursorPoint.Y , ListCommand[i].Delay
                    ,ListCommand[i].ParagraphType);
            }

            FinalString += MainSection;

            foreach (string currentItem in StepStrings)
            {
                FinalString += currentItem;
            }
        }

        /// <summary>
        /// To get static and non static values from user.
        /// </summary>
        private static void GetValue()
        {
            GetStaticValue();
            GetNonStaticValues();
        }

        /// <summary>
        /// to get static values
        /// </summary>
        private static void GetStaticValue()
        {
            Console.WriteLine("Enter INI File Name (Without \".ini\" suffix)");
            INI_FileName = Console.ReadLine() + ".ini";
            
            Console.WriteLine("Is can looping");
            canLoop = ForCleanInputBool.GetBoolean("Enable Looping...");

            GetDateTimeValues();
        }

        /// <summary>
        /// To get DateTime for start virtual input action from user.
        /// </summary>
        private static void GetDateTimeValues()
        {
            
            try
            {
                Console.WriteLine("Enter Year [N=Current Year]");
                _Year = InputAndCheckForPointingNowDate(TimeType.Year);
            
                Console.WriteLine("Enter Month [N=Current Month]");
                _Month = InputAndCheckForPointingNowDate(TimeType.Month);

                Console.WriteLine("Enter Day [N=Current Day]");
                _Day = InputAndCheckForPointingNowDate(TimeType.Day);

                Console.WriteLine("Enter Hour [N=Current Hour]");
                _Hour = InputAndCheckForPointingNowDate(TimeType.Hour);

                Console.WriteLine("Enter Minute [N=Current Minute]");
                _Minute = InputAndCheckForPointingNowDate(TimeType.Minute);

                Console.WriteLine("Enter Second [N=Current Second]");
                _Second = InputAndCheckForPointingNowDate(TimeType.Second);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("________________________________________________________");
                GetDateTimeValues();
            }
        }

        /// <summary>
        /// To input and check for pointing now date.
        /// </summary>
        /// <param name="thisTimeType">Type of time quantity</param>
        /// <returns>Return int number or 'n' for this time quantity type</returns>
        private static string InputAndCheckForPointingNowDate(TimeType thisTimeType)
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string returnString = input.ToLower();
                    if (returnString == "n")
                        return input;

                    switch (thisTimeType)
                    {
                        case TimeType.Year:
                            new DateTime(int.Parse(input),1,1,1,1,1);
                            break;

                        case TimeType.Month:
                            new DateTime(1,int.Parse(input),1,1,1,1);
                            break;

                        case TimeType.Day:
                            new DateTime(1,1,int.Parse(input),1,1,1);
                            break;

                        case TimeType.Hour:
                            new DateTime(1,1,1,int.Parse(input),1,1);
                            break;

                        case TimeType.Minute:
                            new DateTime(1,1,1,1,int.Parse(input),1);
                            break;

                        case TimeType.Second:
                            new DateTime(1,1,1,1,1,int.Parse(input));
                            break;
                    }
                    
                    return input;
                }
                catch
                {
                    Console.WriteLine("This is incorrect");
                }
            }
        }

        /// <summary>
        /// To get non static values from user.
        /// </summary>
        private static void GetNonStaticValues()
        {
            while (true)
            {

                if (ListCommand.Count > 0)
                {
                    if (!Boolean_Question.SetQuestionCanLooping("Do you want to set the next step?(y/n)"))
                        break;
                }
                
                if(BypassGetNonStaticValue())
                    continue;
                
                ListCommandTypes commandTypes = ShowAndGetCommandTypes.SetCommandTypes();

                if (isKeyboardMode(commandTypes))
                {
                    GetNonStaticValueForKeyBoard(commandTypes);
                    Console.WriteLine("This Step section is defined!");
                    continue;
                }
                GetNonStaticValueForMouse(commandTypes);
            }
        }

        /// <summary>
        /// To avoid prolonging the process of setting the same values by the user.
        /// </summary>
        /// <returns>True:Values is set by user in this function. FalseValues is not set by user in this function.:</returns>
        private static bool BypassGetNonStaticValue()
        {
            if (ListCommand.Count > 0)
            {
                if (isKeyboardMode(ListCommand[ListCommand.Count - 1].CommandTypes))
                {
                    Console.WriteLine("Do you want add last values?(Y/N)");
                }
                else
                {
                    Console.WriteLine("Do you want add last values for other cursor position?(Y/N)");
                }

                switch (Boolean_Question.SetQuestionCanLooping())
                {
                    case true:
                        Console.WriteLine();
                        OneCommand lastCommand = ListCommand[ListCommand.Count - 1];

                        if (!isKeyboardMode(lastCommand.CommandTypes))
                        {
                            Console.WriteLine("Press Enter To Set Cursor Point...");
                            Console.ReadLine();
                            lastCommand.CursorPoint = VirtualMouse.GetCursorPosition();
                        }

                        ListCommand.Add(lastCommand);
                        return true;

                    case false:
                        Console.WriteLine();
                        break;
                }
            }
            return false;
        }
        
        /// <summary>
        /// to diagnosis user chose keyboard mode.
        /// </summary>
        /// <param name="thisListCommandTypes"></param>
        /// <returns></returns>
        private static bool isKeyboardMode(ListCommandTypes thisListCommandTypes)
        {
            return (thisListCommandTypes == ListCommandTypes.ParagraphType);
        }

        /// <summary>
        /// To set non static value by user for keyboard modes.
        /// </summary>
        /// <param name="thisListCommandTypes"></param>
        private static void GetNonStaticValueForKeyBoard(ListCommandTypes thisListCommandTypes)
        {
            Point CursorPoint = new Point(0,0);
            string ParagraphType = string.Empty;
            
            int ModifierKeyCodes = 0;
            int KeyCodes = 0;
            int Delay = 0;

            if (thisListCommandTypes == ListCommandTypes.ParagraphType)
            {
                Console.WriteLine("Enter ParagraphType");
                ParagraphType = Console.ReadLine();
                
                Delay = ForCleanInputInt.GetValue("Enter Delay (Miliseconds)...");
                
                ListCommand.Add(new OneCommand(CursorPoint ,thisListCommandTypes,Delay,ParagraphType,ModifierKeyCodes,KeyCodes));
                return;
            }

            Console.WriteLine("Enter Modifier Key Codes...");
            ModifierKeyCodes = (int)Console.ReadKey().Key;
            Console.WriteLine();
            
            Console.WriteLine("Enter Key Codes...");
            KeyCodes = (int)Console.ReadKey().Key;
            Console.WriteLine();
            
            Delay = ForCleanInputInt.GetValue("Enter Delay (Miliseconds)...");

            ListCommand.Add(new OneCommand(CursorPoint ,thisListCommandTypes,Delay,ParagraphType,ModifierKeyCodes,KeyCodes));
        }

        /// <summary>
        /// To set non static value by user for Mouse modes.
        /// </summary>
        /// <param name="thisListCommandTypes"></param>
        private static void GetNonStaticValueForMouse(ListCommandTypes thisListCommandTypes)
        {
            Console.WriteLine("Press Enter To Set Cursor Point...");
            Console.ReadLine();
            Point CursorPoint = VirtualMouse.GetCursorPosition();
            
            string ParagraphType = "";
            int ModifierKeyCodes = 0;
            int KeyCodes = 0;
                
            int Delay = ForCleanInputInt.GetValue("Enter Delay (Miliseconds)...");

            ListCommand.Add(new OneCommand(CursorPoint ,thisListCommandTypes,Delay,ParagraphType,ModifierKeyCodes,KeyCodes));
        }
    }
}