using System;
using System.Collections.Generic;
using System.Text;

namespace NonEcsModel
{
	public abstract class MapObject : BaseObject
	{
		public int X { get; set; }
		public int Y { get; set; }
		public char Char { get; set; }

		public bool IsVisible { get; set; }
	}
	
}
