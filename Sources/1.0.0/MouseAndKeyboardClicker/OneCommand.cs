using System;

namespace AutoClickerMouseAndKeyboard
{
	public struct OneCommand
	{
		public Point CursorPoint;
		public ListCommandTypes CommandTypes;
		public int Delay;
		public string ParagraphType;
		public int ModifierKeyCodes, KeyCodes;
		public OneCommand (Point currentPoint, ListCommandTypes commandTypes , int delay = 100 , string paragraphType = "" ,int modifierKeyCodes = 0, int keyCodes=0){
			CursorPoint = currentPoint;
			CommandTypes = commandTypes;
			Delay = delay;
			ParagraphType = paragraphType;
			ModifierKeyCodes = modifierKeyCodes;
			KeyCodes = keyCodes;
		}
	}
}

