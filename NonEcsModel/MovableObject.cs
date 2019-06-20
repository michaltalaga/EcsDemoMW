using System;
using System.Collections.Generic;
using System.Text;

namespace NonEcsModel
{
	public abstract class MovableObject : MapObject
	{
		public void MoveTo(int x, int y)
		{
			X = x;
			Y = y;
			// Collision?
		}
	}
	public interface IMoveable
	{
		void MoveTo(int x, int y);
	}

	public class MoveableComponent
	{

		public void MoveTo(int x, int y)
		{
			//X = x;
			//Y = y;
			// Collision?
		}
	}
}
