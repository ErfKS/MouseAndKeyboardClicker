using AutoManagenmentWakeUp;
using System.Collections.Generic;
using System;
using System.Threading;
using WindowsInput.Native;

namespace AutoClickerMouseAndKeyboard
{
    
    /// <summary>
    /// Start virtual input actions base on an ini file.
    /// </summary>
    public static class Command_INI
    {
        private static List<OneCommand> ListCommand = new List<OneCommand> (0);
        private static int Capacity = 0;
        private static Date_Time_String DateTimeStart = new Date_Time_String();
        private static bool canLoop = true;
        private static string INI_FileName = "CommandList.ini";
        
        /// <summary>
        /// Start Command INI Mode
        /// </summary>
        public static void Start()
        {
            GetValues();
            WaitForTime();
            StartProcess();
        }

        /// <summary>
        /// Start Command INI Mode With File Name.
        /// </summary>
        /// <param name="FileName">*.ini File</param>
        public static void Start(string FileName)
        {
            INI_FileName = FileName + ".ini";
            GetStaticValue(false);
            for (int i = 0; i < Capacity; i++) {
                GetNonStaticValues(i);
            }
            
            WaitForTime();
            StartProcess();
        }

        /// <summary>
        /// Waiting for the time to arrive.
        /// </summary>
        private static void WaitForTime()
        {
            Console.WriteLine("Wating For Time for start");
            Console.WriteLine("In time: Year:{0} Month:{1} Day:{2} Hour:{3} Minute:{4} Second:{5}", DateTimeStart.Year,
                DateTimeStart.Month, DateTimeStart.Day, DateTimeStart.Hour, DateTimeStart.Minute, DateTimeStart.Second);
            while (true)
            {
                long elapsedTicks = DateTime.Now.Ticks - DateTimeStart.GetDateTime.Ticks;
                TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
                if ((int)Math.Abs(elapsedSpan.TotalSeconds) <= 0) 
                {
                    return;
                }
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// To start the action ordered virtual input.
        /// </summary>
        private static void StartProcess()
        {
            Console.WriteLine("Process is starting!");
            for (int i = 0; i < Capacity; i++)
            {
                ProcessOneCommand(ListCommand[i]);
            }
            
            Console.WriteLine("All commands are processed!");

            if (canLoop)
            {
                Start(INI_FileName.Replace(".ini",""));
                WaitForTime();
                StartProcess();
            }

            RestartProgram();
        }

        /// <summary>
        /// To start a virtual input action.
        /// </summary>
        /// <param name="thisCommand"></param>
        private static void ProcessOneCommand(OneCommand thisCommand)
        {
            switch (thisCommand.CommandTypes)
            {
                case ListCommandTypes.Rightclick: 
                    Thread.Sleep(thisCommand.Delay);
                    Rightclick(thisCommand.CursorPoint.X , thisCommand.CursorPoint.Y); 
                    break;
                case ListCommandTypes.DoubleLeftClick:
                    Thread.Sleep(thisCommand.Delay);
                    DoubleLeftClick(thisCommand.CursorPoint.X , thisCommand.CursorPoint.Y);
                    break;
                case ListCommandTypes.RightDoubleClick:
                    Thread.Sleep(thisCommand.Delay);
                    DoubleRightClick(thisCommand.CursorPoint.X , thisCommand.CursorPoint.Y);
                    break;
                case ListCommandTypes.LeftClickDown:
                    Thread.Sleep(thisCommand.Delay);
                    LeftClickDown(thisCommand.CursorPoint.X , thisCommand.CursorPoint.Y);
                    break;
                case ListCommandTypes.LeftClickUp:
                    Thread.Sleep(thisCommand.Delay);
                    LeftClickUp(thisCommand.CursorPoint.X , thisCommand.CursorPoint.Y);
                    break;
                case ListCommandTypes.LeftClick:
                    Thread.Sleep(thisCommand.Delay);
                    LeftClick(thisCommand.CursorPoint.X , thisCommand.CursorPoint.Y);
                    break;
                case ListCommandTypes.MousePosition:
                    Thread.Sleep(thisCommand.Delay);
                    MousePosition(thisCommand.CursorPoint.X , thisCommand.CursorPoint.Y);
                    break;
                case ListCommandTypes.ParagraphType:
                    Thread.Sleep(thisCommand.Delay);
                    ParagraphType(thisCommand.ParagraphType);
                    break;
                default:
                    Console.WriteLine("This value is not Undefined!\nValue:"+Enum.GetName(typeof(ListCommandTypes),(int)thisCommand.CommandTypes));
                    RestartProgram();
                    break;
            }
        }

        /// <summary>
        /// To restart all of program values and references.
        /// </summary>
        public static void RestartProgram()
        {
            RestartValue();
            MainClass.RestartProgram();
        }

        /// <summary>
        /// To restart all of this class values and references.
        /// </summary>
        private static void RestartValue()
        {
            ListCommand = new List<OneCommand> (0);
            Capacity = 0;
            DateTimeStart = new Date_Time_String();
            canLoop = true;
        }
        
        /// <summary>
        /// Send right mouse click
        /// </summary>
        /// <param name="posX">Cursor position in x-axis</param>
        /// <param name="posY">Cursor position in y-axis</param>
        private static void Rightclick(uint posX , uint posY){
            VirtualMouse.sendMouseRightclick(new Point(posX , posY));
        }
        
        /// <summary>
        /// Send double left mouse click
        /// </summary>
        /// <param name="posX">Cursor position in x-axis</param>
        /// <param name="posY">Cursor position in y-axis</param>
        private static void DoubleLeftClick(uint posX , uint posY){
           VirtualMouse.sendMouseDoubleLeftClick(new Point(posX , posY));
        }
        
        /// <summary>
        /// Send double right click.
        /// </summary>
        /// <param name="posX">Cursor position in x-axis</param>
        /// <param name="posY">Cursor position in y-axis</param>
        private static void DoubleRightClick(uint posX , uint posY){
           VirtualMouse.sendMouseRightDoubleClick(new Point(posX , posY));
        }
        
        /// <summary>
        /// Send left click down
        /// </summary>
        /// <param name="posX">Cursor position in x-axis</param>
        /// <param name="posY">Cursor position in y-axis</param>
        /// <param name="posX">Cursor position in x-axis</param>
        /// <param name="posY">Cursor position in y-axis</param>
        private static void LeftClickDown(uint posX , uint posY){
            VirtualMouse.sendMouseLeftClickDown(new Point(posX , posY));
        }
        
        /// <summary>
        /// Send left click up
        /// </summary>
        /// <param name="posX">Cursor position in x-axis</param>
        /// <param name="posY">Cursor position in y-axis</param>
        private static void LeftClickUp(uint posX , uint posY){
            VirtualMouse.sendMouseLeftClickUp(new Point(posX , posY));
        }

        /// <summary>
        /// Send left click
        /// </summary>
        /// <param name="posX">Cursor position in x-axis</param>
        /// <param name="posY">Cursor position in y-axis</param>
        private static void LeftClick(uint posX, uint posY)
        {
            VirtualMouse.sendMouseLeftClick(new Point(posX , posY));
        }
        
        /// <summary>
        /// Send mouse position
        /// </summary>
        /// <param name="posX">Cursor position in x-axis</param>
        /// <param name="posY">Cursor position in y-axis</param>
        private static void MousePosition(uint posX , uint posY){
           VirtualMouse.sendMousePosition(new Point(posX , posY));
        }

        /// <summary>
        /// Type a paragraph
        /// </summary>
        /// <param name="text">Text to type</param>
        private static void ParagraphType(string text)
        {
            Virtual_Keyboard.Type(text);
        }

        /// <summary>
        /// To get static and non static values from user.
        /// </summary>
        private static void GetValues()
        {
            GetStaticValue();
            
            for (int i = 0; i < Capacity; i++) {
                GetNonStaticValues(i);
            }
        }

        /// <summary>
        /// To get static values
        /// </summary>
        /// <param name="canChooseFileName">Allow the user to chose the file name</param>
        private static void GetStaticValue(bool canChooseFileName = true)
        {
            if (canChooseFileName)
            {
                Console.WriteLine("Enter INI File Name [with out \".ini\" suffix] (Defult=CommandList.ini)");
                string ini_FileName = Console.ReadLine() + ".ini";
                INI_FileName = (ini_FileName == string.Empty) ? INI_FileName : (ini_FileName);
            }

            Capacity = int.Parse(ReadConfig(string.Format("Main"),"Capacity"));
            
            string mYear = ReadConfig(string.Format("Main"),"Year");
            string mMonth = ReadConfig(string.Format("Main"),"Month");
            string mDay = ReadConfig(string.Format("Main"),"Day");
            string mHour = ReadConfig(string.Format("Main"),"Hour");
            string mMinute = ReadConfig(string.Format("Main"),"Minute");
            string mSecond = ReadConfig(string.Format("Main"),"Second");
            canLoop = ForCleanInputBool.GetBoolean(ReadConfig(string.Format("Main"),"canLoop"));

            DateTimeStart = new Date_Time_String(mYear,mMonth,mDay,mHour,mMinute,mSecond);
        }

        /// <summary>
        /// To get non static values
        /// </summary>
        /// <param name="numberStep">Number of step to process</param>
        private static void GetNonStaticValues(int numberStep)
        {

            int thisType = int.Parse(ReadConfig(string.Format("Step{0}", numberStep), "Type"));
            uint posX = uint.Parse(ReadConfig(string.Format("Step{0}", numberStep), "PosX"));
            uint posY = uint.Parse(ReadConfig(string.Format("Step{0}", numberStep), "PosY"));
            int delay = int.Parse(ReadConfig(string.Format("Step{0}", numberStep), "Delay"));
            string paragraphType = ReadConfig(string.Format("Step{0}", numberStep), "paragraphType");
            int firstShortKey = int.Parse(ReadConfig(string.Format("Step{0}", numberStep), "firstShortKey"));
            int secondShortKey = int.Parse(ReadConfig(string.Format("Step{0}", numberStep), "secondShortKey"));
            ListCommand.Add(new OneCommand(new Point(posX,posY),(ListCommandTypes)thisType,delay , paragraphType , firstShortKey , secondShortKey));
        }
        
        /// <summary>
        /// to Read ini file
        /// </summary>
        /// <param name="section">Section to read</param>
        /// <param name="key">Key to read</param>
        /// <returns></returns>
        static string ReadConfig(string section, string key)
        {
            var iniFile = new IniFile(INI_FileName);
            string returnString = iniFile.GetValue(section, key, "0");
            return returnString;
        } 
    }
}