using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace AutoClickerMouseAndKeyboard
{
	/// <summary>
	/// This class contains functions that can send virtual inputs to the Windows OS.
	/// </summary>
	public class VirtualMouse
	{
		[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
		public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, int dwExtraInfo);
		private const uint MOUSEEVENTF_LEFTDOWN = 0x02;
		private const uint MOUSEEVENTF_LEFTUP = 0x04;
		private const uint MOUSEEVENTF_RIGHTDOWN = 0x08;
		private const uint MOUSEEVENTF_RIGHTUP = 0x10;

		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetCursorPos(out Point lpPoint);

		[DllImport("user32.dll", EntryPoint = "SetCursorPos")]
		private static extern int SetCursorPos(uint x, uint y);

		public static void sendMouseRightclick(Point p)
		{
			SetCursorPos (p.X, p.Y);
			mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);

			Console.WriteLine ("Right Mouse Clicked!");
		}

		public static void sendMouseDoubleLeftClick(Point p)
		{
			SetCursorPos (p.X, p.Y);
			mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
			Thread.Sleep(100);
			mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

			Thread.Sleep(150);

			mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
			Thread.Sleep(100);
			mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
			Console.WriteLine ("Double Left Mouse Clicked!");
		}

		public static void sendMouseRightDoubleClick(Point p)
		{
			SetCursorPos (p.X, p.Y);
			mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
			Thread.Sleep(100);
			mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);

			Thread.Sleep(150);

			mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
			Thread.Sleep(100);
			mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
			Console.WriteLine ("Right Double Mouse Clicked In Position:{0}" , p.ToString());
		}

		public static void sendMouseLeftClickDown(Point p)
		{
			SetCursorPos (p.X, p.Y);
			mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
			Console.WriteLine ("Left Down Mouse Clicked In Position:{0}" , p.ToString());
		}

		public static void sendMouseLeftClickUp(Point p)
		{
			SetCursorPos (p.X, p.Y);
			mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
			Console.WriteLine ("Left Up Mouse Clicked In Position:{0}" , p.ToString());
		}

		public static void sendMouseLeftClick(Point p)
		{
			SetCursorPos (p.X, p.Y);
			mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
			Thread.Sleep(100);
			mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
			Console.WriteLine ("Left Mouse Clicked In Position:{0}" , p.ToString());
		}

		public static void sendMousePosition(Point p){
			Console.WriteLine ("Cursor Set Position In {0}" , p.ToString());
			SetCursorPos (p.X, p.Y);
		}



		public static Point GetCursorPosition(){
			Point CurrentPoint = new Point ();
			GetCursorPos (out CurrentPoint);
			return CurrentPoint;
		}
	}
}

