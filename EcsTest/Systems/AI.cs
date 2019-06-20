using System;
using System.Collections.Generic;
using System.Text;
using EcsTest.Components;
using EcsTest.EntitySystem;

namespace EcsTest.Systems
{
	public class AI : EntitySystem
	{
		static Random random = new Random();
		public AI() : base(x => x.Has<MapObject, Movable, Components.Brain>())
		{

		}
		public override void Process(IEnumerable<Entity> entities)
		{
			foreach (var entity in entities)
			{
				entity.Remove<NextMove>();
				entity.Add(new NextMove(GetRandomDirection()));
			}
		}

		private Direction GetRandomDirection()
		{
			return (Direction)random.Next(0, 4);
		}
	}
}
