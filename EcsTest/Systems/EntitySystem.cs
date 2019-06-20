using EcsTest.EntitySystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcsTest.Systems
{
	public abstract class EntitySystem
	{
		public EntitySystem() : this(x => true)
		{

		}
		public EntitySystem(Func<Entity, bool> filter)
		{
			Filter = filter;
		}

		public Func<Entity, bool> Filter { get; }

		public abstract void Process(IEnumerable<Entity> entities);
	}
}
