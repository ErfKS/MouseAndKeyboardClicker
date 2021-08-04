using System.Threading;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace AutoClickerMouseAndKeyboard
{
	
	/// <summary>
	/// Create record and start virtual input action
	/// </summary>
	public class Simple_Mode
    {
        static List<OneCommand> ListClicks = new List<OneCommand> (0);
        static int Year = 2020 , Month = 12 , Day = 15 , Hour = 2 , Minutes = 35 , Second = 0;
        
        /// <summary>
        /// Start Simple Mode
        /// </summary>
        public static void Start()
        {
            ListClicks = new List<OneCommand> (0);
            RecordClick ();
            SetTimeToStart ();
            WatingForStart ();
            StartActions ();
        }
        
			public static void WatingForStart(){
			/*Console.WriteLine ("Time Set:\t{0}\n", ConvertTimeToString (Year, Month, Day, Hour, Minutes, Second));*/
			DateTime dateTimeToStart = new DateTime(Year, Month, Day, Hour, Minutes, Second, new GregorianCalendar());
			Console.WriteLine ("Time Set:\t{0}\n", ConvertDateTimeToGregorianCalender(dateTimeToStart));
			while (true) {
				Thread.Sleep (100);
				DateTime CurrentDateTime = DateTime.Now;
				
				ShowTime ("Current Time",CurrentDateTime);
				if(CurrentDateTime.Year == Year && CurrentDateTime.Month == Month && CurrentDateTime.Day == Day &&
					CurrentDateTime.Hour == Hour && CurrentDateTime.Minute == Minutes && CurrentDateTime.Second == Second){
					break;
				}
			}
		}

	    /// <summary>
		/// Start all ordered virtual input action.
		/// </summary>
		public static void StartActions(){
			Console.WriteLine ("ClickStarted!");
			foreach (OneCommand CurrentItem in ListClicks) {
				Thread.Sleep (CurrentItem.Delay);
				OneAction (CurrentItem.CommandTypes, CurrentItem.CursorPoint , CurrentItem.ParagraphType);
			}
			Console.WriteLine ("Click Is Done!");
			Start();
		}

		/// <summary>
		/// One virtual input action
		/// </summary>
		/// <param name="commandTypes">Type of virtual input action</param>
		/// <param name="clickPoint">To set cursor position</param>
		/// <param name="text">This is for paragraph type, type this text</param>
		public static void OneAction(ListCommandTypes commandTypes , Point clickPoint , string text){
			switch (commandTypes) {
			case ListCommandTypes.DoubleLeftClick:
				VirtualMouse.sendMouseDoubleLeftClick (clickPoint);
				break;
			default:
			case ListCommandTypes.LeftClickDown:
				VirtualMouse.sendMouseLeftClick (clickPoint);
				break;
			case ListCommandTypes.LeftClickUp:
				VirtualMouse.sendMouseLeftClickUp (clickPoint);
				break;
			case ListCommandTypes.Rightclick:
				VirtualMouse.sendMouseRightclick (clickPoint);
				break;
			case ListCommandTypes.RightDoubleClick:
				VirtualMouse.sendMouseRightDoubleClick (clickPoint);
				break;
			case ListCommandTypes.MousePosition:
				VirtualMouse.sendMousePosition (clickPoint);
				break;
			case ListCommandTypes.ParagraphType:
				Virtual_Keyboard.Type(text);
				break;
			}
		}

		/// <summary>
		/// Create records (By User)
		/// </summary>
		public static void RecordClick(){
			while (true)
			{
				Point currentPoint = VirtualMouse.GetCursorPosition();
				Console.WriteLine(
					"\nEnter Key(R:RightClick L:Left Click K:Double Left Click F:Double Right Click E:Exit Recording P:Set Cursor Position T:Paragraph Type)...");
				switch (Console.ReadKey().Key)
				{
					case ConsoleKey.L:
						Console.WriteLine();
						currentPoint = VirtualMouse.GetCursorPosition();
						Console.WriteLine("Left Click in Pos ({0}) Is Recorded!\nEnter Delay(MilliSeconds)...",
							currentPoint.X.ToString() + "," + currentPoint.Y);
						int TimeDelayLClick = int.Parse(Console.ReadLine());
						ListClicks.Add(new OneCommand(currentPoint, ListCommandTypes.LeftClickDown, TimeDelayLClick,
							string.Empty));
						//ListClicks.Add (new OneClick (currentPoint , ListClickTypes.LeftClickUp , TimeDelayLClick));
						break;

					case ConsoleKey.R:
						Console.WriteLine();
						currentPoint = VirtualMouse.GetCursorPosition();
						Console.WriteLine("Right Click in Pos ({0}) Is Recorded!\nEnter Delay(MilliSeconds)...",
							currentPoint.X.ToString() + "," + currentPoint.Y);
						int timeDelayRClick = int.Parse(Console.ReadLine());
						ListClicks.Add(new OneCommand(currentPoint, ListCommandTypes.Rightclick, timeDelayRClick,
							string.Empty));
						break;
					case ConsoleKey.K:
						Console.WriteLine();
						currentPoint = VirtualMouse.GetCursorPosition();
						Console.WriteLine("Double Left Click in Pos ({0}) Is Recorded!\nEnter Delay(MilliSeconds)...",
							currentPoint.X.ToString() + "," + currentPoint.Y);
						int timeDelayDlClick = int.Parse(Console.ReadLine());
						ListClicks.Add(new OneCommand(currentPoint, ListCommandTypes.DoubleLeftClick, timeDelayDlClick,
							string.Empty));
						break;
					case ConsoleKey.F:
						Console.WriteLine();
						currentPoint = VirtualMouse.GetCursorPosition();
						Console.WriteLine("Double Right Click in Pos ({0}) Is Recorded!\nEnter Delay(MilliSeconds)...",
							currentPoint.X.ToString() + "," + currentPoint.Y);
						int timeDelayDrClick = int.Parse(Console.ReadLine());
						ListClicks.Add(new OneCommand(currentPoint, ListCommandTypes.RightDoubleClick, timeDelayDrClick,
							string.Empty));
						break;
					case ConsoleKey.P:
						Console.WriteLine();
						currentPoint = VirtualMouse.GetCursorPosition();
						Console.WriteLine("SetCursorPosition in Pos ({0}) Is Recorded!\nEnter Delay(MilliSeconds)...",
							currentPoint.X.ToString() + "," + currentPoint.Y);
						int timeDelayPClick = int.Parse(Console.ReadLine());
						ListClicks.Add(new OneCommand(currentPoint, ListCommandTypes.MousePosition, timeDelayPClick,
							string.Empty));
						break;
					case ConsoleKey.E:
						Console.WriteLine();
						return;
					case ConsoleKey.T:
						Console.WriteLine();
						Console.WriteLine("Enter Text");
						string text = Console.ReadLine();
						Console.WriteLine("Paragraph Type Is Recorded!\nEnter Delay(MilliSeconds)...");
						int timeDelayTClick = int.Parse(Console.ReadLine());
						ListClicks.Add(new OneCommand(currentPoint, ListCommandTypes.ParagraphType, timeDelayTClick,
							text));
						break;
					default:
						Console.WriteLine("This Key Is Incorrect!");
						break;
				}

			}
		}

		/// <summary>
		/// Set time to start virtual input actions(by user)
		/// </summary>
		public static void SetTimeToStart(){
			ShowTime ("Current Time",DateTime.Now);
			Console.WriteLine ("Enter Time To Start(Year)...");
			Year = InputAndCheckForPointingNowDate(TimeType.Year);
			Console.WriteLine ("Enter Time To Start(Month)...");
			Month = InputAndCheckForPointingNowDate(TimeType.Month);
			Console.WriteLine ("Enter Time To Start(Day)...");
			Day = InputAndCheckForPointingNowDate(TimeType.Day);
			Console.WriteLine ("Enter Time To Start(Hour)...");
			Hour = InputAndCheckForPointingNowDate(TimeType.Hour);
			Console.WriteLine ("Enter Time To Start(Minutes)...");
			Minutes = InputAndCheckForPointingNowDate(TimeType.Minute);
			Console.WriteLine ("Enter Time To Start(Seconds)...");
			Second = InputAndCheckForPointingNowDate(TimeType.Second);
		}
		
		/// <summary>
		/// Check for debugging import text by user for date time 
		/// </summary>
		/// <param name="thisTimeType">Type of time quantity</param>
		/// <returns>Return int number for this time quantity type</returns>
		private static int InputAndCheckForPointingNowDate(TimeType thisTimeType)
		{
			while (true)
			{
				try
				{
					string input = Console.ReadLine();
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
                    
					return int.Parse(input);
				}
				catch
				{
					Console.WriteLine("This is incorrect");
				}
			}
		}

		/// <summary>
		/// show DateTime in one line of console
		/// </summary>
		/// <param name="thisDateTime">DateTime to show in console</param>
		public static void ShowTime(string text,DateTime thisDateTime){
			
			AdvancedConsoleTextTools LineEditor = new AdvancedConsoleTextTools (Console.CursorTop - 1);
			GregorianCalendar gc = new GregorianCalendar();

			string DateTime = string.Format("{0}:\t{1}", text, ConvertDateTimeToGregorianCalender(thisDateTime));
			
			LineEditor.SetTextConsoleInCurrentLine(DateTime);
		}

		/// <summary>
		/// Convert DateTime to Gregorian calendar (MM/dd/yyyy HH:mm:ss)
		/// </summary>
		/// <param name="thisDateTime">DateTime to convert as a</param>
		/// <returns>(MM/dd/yyyy HH:mm:ss)</returns>
		private static string ConvertDateTimeToGregorianCalender(DateTime thisDateTime)
		{
			GregorianCalendar gc = new GregorianCalendar();
			return string.Format("{0}/{1}/{2} {3}:{4}:{5}", gc.GetMonth(thisDateTime) , gc.GetDayOfMonth(thisDateTime) , gc.GetYear(thisDateTime) , gc.GetHour(thisDateTime) , gc.GetMinute(thisDateTime),gc.GetSecond(thisDateTime));
		}

		/// <summary>
		/// return time
		/// </summary>
		/// <param name="year"></param>
		/// <param name="month"></param>
		/// <param name="day"></param>
		/// <param name="hour"></param>
		/// <param name="minutes"></param>
		/// <param name="seconds"></param>
		/// <returns></returns>
		public static string ConvertTimeToString(int year , int month , int day , int hour , int minutes , int seconds){
			return string.Format ("{0}/{1}/{2}: {3}:{4}:{5} ",year.ToString () , month.ToString () , day.ToString() , hour.ToString() 
				, minutes.ToString() , seconds.ToString());
		}

    }
}