using System;

namespace AutoClickerMouseAndKeyboard
{
	public struct Point
	{
		public uint X;
		public uint Y;
		public Point(uint x , uint y){
			X = x;
			Y = y;
		}

		public override string ToString(){
			return "(" + X + "," + Y + ")";
		}

	}
}

