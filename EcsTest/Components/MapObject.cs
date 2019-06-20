using System;
using System.Collections.Generic;
using System.Text;

namespace EcsTest.Components
{
	public class MapObject : IComponent
	{
		public int X { get; set; }
		public int Y { get; set; }
		public char Char { get; set; }
	}
}