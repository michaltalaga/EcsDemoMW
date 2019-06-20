using System;
using System.Collections.Generic;
using System.Text;

namespace EcsTest.Components
{
	public class DemoKey :IComponent
	{
		public DemoKey(ConsoleKey key)
		{
			Key = key;
		}

		public ConsoleKey Key { get; }
	}
}
