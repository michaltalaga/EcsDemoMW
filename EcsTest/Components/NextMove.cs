using System;
using System.Collections.Generic;
using System.Text;

namespace EcsTest.Components
{
	public class NextMove : IComponent
	{
		public NextMove(Direction direction)
		{
			Direction = direction;
		}
		public Direction Direction { get; set; }
	}
	public enum Direction
	{
		Up,
		Right,
		Down,
		Left

	}
}
