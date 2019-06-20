using System;
using System.Collections.Generic;
using System.Text;
using EcsTest.Components;
using EcsTest.EntitySystem;
using System.Linq;

namespace EcsTest.Systems
{
	public class Demo : EntitySystem
	{
		public Demo()
		{

		}
		public override void Process(IEnumerable<Entity> entities)
		{
			PrintHelpLine(1, "1 - Animate");
			PrintHelpLine(2, "2 - Assing Profession");
			PrintHelpLine(3, "3 - Change Own Profession");
			var player = entities.FirstOrDefault(x => x.Has<Player>());
			var demoKey = player.Get<DemoKey>();
			if (demoKey == null) return;
			player.Remove<DemoKey>();
			var playerLocation = player.Get<MapObject>();
			if (demoKey.Key == ConsoleKey.D1) AnimateWall(entities, playerLocation);
			if (demoKey.Key == ConsoleKey.D2) AssignProfession(entities, playerLocation);
			if (demoKey.Key == ConsoleKey.D3) { player.Remove<Profession>(); player.Add(new Profession(Role.Mage)); }

		}

		private void PrintHelpLine(int line, string text)
		{
			//return;
			Console.SetCursorPosition(50, line);
			Console.Write(text);
		}

		private void AssignProfession(IEnumerable<Entity> entities, MapObject playerLocation)
		{
			foreach (var entity in entities)
			{
				if (!entity.Has<MapObject>()) continue;
				var mapObject = entity.Get<MapObject>();
				if (playerLocation.Y == mapObject.Y)
				{
					if (playerLocation.X - 1 == mapObject.X || playerLocation.X + 1 == mapObject.X)
					{
						entity.Add(new Profession(Role.Warrior));
						return;
					}
				}

			}
		}

		private static void AnimateWall(IEnumerable<Entity> entities, MapObject playerLocation)
		{

			foreach (var entity in entities)
			{
				if (!entity.Has<MapObject>()) continue;
				var mapObject = entity.Get<MapObject>();
				if (playerLocation.Y == mapObject.Y)
				{
					if (playerLocation.X - 1 == mapObject.X || playerLocation.X + 1 == mapObject.X)
					{
						entity.Add(new Movable());
						entity.Add(new Brain());
						return;
					}
				}

			}

		}
	}
}
