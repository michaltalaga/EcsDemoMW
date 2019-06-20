using System;
using System.Collections.Generic;
using System.Text;

namespace NonEcsModel
{
	public abstract class Character : MovableObject
	{
		public bool IsAlive => Life > 0;
		public int Life { get; set; }
		public int Power { get; set; }
		public void Attack(Character target)
		{
			target.Life -= Power;
		}
	}
}
