using System;

namespace AutoClickerMouseAndKeyboard
{
	/// <summary>
	/// This class contains functions that help to display text in a specific way in the console environment of this program.
	/// </summary>
	public class AdvancedConsoleTextTools
	{
		public int LineEdit = 0;
		
		private int LineSTOPNumberX = 0;
		private int LineSTOPNumberY = 0;

		/// <summary>
		/// Display line number to show and edit text in this line.
		/// </summary>
		/// <param name="lineEdit"></param>
		public AdvancedConsoleTextTools(int lineEdit){
			LineEdit = lineEdit;
		}
		
		/// <summary>
		/// Display and edit text in specific line of console.
		/// </summary>
		/// <param name="TextForShow"></param>
		public void SetTextConsoleInCurrentLine(string TextForShow){
			
			LineSTOPNumberX = Console.CursorLeft;
			Console.SetCursorPosition(0, LineEdit);
			ClearCurrentConsoleLine(LineEdit);

			Console.WriteLine(TextForShow);

			if(LineSTOPNumberY != 0)
				Console.SetCursorPosition(LineSTOPNumberX, LineSTOPNumberY);
		}
		
		public void ClearCurrentConsoleLine(int LineNumber)
		{
			//int currentLineCursor = Console.CursorTop;
			Console.SetCursorPosition(0, Console.CursorTop);
			Console.Write(new string(' ', Console.WindowWidth)); 
			Console.SetCursorPosition(0, LineNumber);
		}
	}
}

