using System;

namespace AutoClickerMouseAndKeyboard
{
	/* [Main]
     * Year = 0
     * Mounth = 0
     * Day = 0
     * Hour = 0
     * Minute = 0
     * Second = 0
     * canLoop = 0
     * Capacity = 0
     * AddHour = 0
     * 
     * [Step0]
     * Type=0
     * PosX = 0
     * PosY = 0
     * Delay = 0
     * paragraphType = sdfadf
     * firstShortKey = 0
     * secondShortKey = 0
     */
	class MainClass
	{
		private static int selectedModeNumber = 0;
		
		/// <summary>
		/// All of program modes
		/// </summary>
		private enum Mode
		{
			SimpleMode=1,
			Command_INI=2,
			INI_Creator =3
		}
		
		public static void Main (string[] args)
		{
			GetValues();
			CheckTrueNumber();
			StartMode((Mode)selectedModeNumber);
		}

		/// <summary>
		/// Set values by user
		/// </summary>
		private static void GetValues()
		{
			Console.WriteLine("Enter Mode Number\n{0}",ShowEnumList());
			try {
				selectedModeNumber = int.Parse(Console.ReadKey().KeyChar.ToString());
				
			}
			catch {
				Console.WriteLine("\nThis is incorrect!");
			}
			
		}

		/// <summary>
		/// if the user has entered a number that does not exist in the enum Mode, ask the user again for the value. 
		/// </summary>
		private static void CheckTrueNumber()
		{
			if (!CheckSelectedModeNumber(selectedModeNumber)) {
				Console.WriteLine("\nThis is incorrect!");
				Main(new string[0]); //Go Back
			}
		}

		/// <summary>
		/// Show list of items available in enum Mode.
		/// </summary>
		/// <returns></returns>
		private static string ShowEnumList()
		{
			string[] enumList = Enum.GetNames(typeof(Mode));
			string returnString = string.Empty;

			for (int i = 0; i < enumList.Length; i++) {
				returnString += String.Format("{0}:{1}\n", i+1, enumList[i]);
			}

			return returnString;
		}

		/// <summary>
		/// To check existing number to enum Mode.
		/// </summary>
		/// <param name="thisModeNumber"></param>
		/// <returns></returns>
		private static bool CheckSelectedModeNumber(int thisModeNumber)
		{
			foreach (int currentItem in Enum.GetValues(typeof(Mode)))
			{
				if (currentItem == thisModeNumber)
					return true;
			}
			return false;
		}

		/// <summary>
		/// To enter in chosen mode (by user)
		/// </summary>
		/// <param name="thisMode">Chosen by user.</param>
		private static void StartMode(Mode thisMode)
		{
			switch (thisMode)
			{
				case Mode.SimpleMode:
					Simple_Mode.Start();
					break;
				case Mode.Command_INI:
					Command_INI.Start();
					break;
				case Mode.INI_Creator:
					INI_Creator.Start();
					break;
				default: 
					Console.WriteLine("This value is not Undefined!\nValue:"+Enum.GetName(typeof(Mode),(int)thisMode));
					RestartProgram();
					break;
			}
		}

		/// <summary>
		/// Restart all of MainClass values and call to Main Method.
		/// </summary>
		public static void RestartProgram()
		{
			RestartValues();
			Main(new string[0]);
		}

		/// <summary>
		/// Restart All of Mainclass values.
		/// </summary>
		private static void RestartValues()
		{
			selectedModeNumber = 0;
		}
	}
}
