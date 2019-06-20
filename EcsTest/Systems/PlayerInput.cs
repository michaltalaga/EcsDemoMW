using EcsTest.Components;
using EcsTest.EntitySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcsTest.Systems
{
	public class PlayerInput : EntitySystem
	{
		public PlayerInput() : base(x => x.Has<Player>())
		{

		}
		public override void Process(IEnumerable<Entity> entities)
		{
			var key = Console.ReadKey(true);
			var playerEntity = entities.Single();
			playerEntity.Remove<NextMove>();
			playerEntity.Remove<DemoKey>();
			var direction = GetDirection(key.Key);
			if (direction != null)
			{
				playerEntity.Add(new NextMove(direction.Value));
				return;
			}
			playerEntity.Add(new DemoKey(key.Key));

		}
		private Direction? GetDirection(ConsoleKey key)
		{

			var s = key.ToString().Replace("Arrow", "");
			if (Enum.TryParse<Direction>(s, out var direction)) return direction;
			return null;
		}
	}
}
