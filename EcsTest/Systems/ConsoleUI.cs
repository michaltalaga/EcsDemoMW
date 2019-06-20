using EcsTest.Components;
using EcsTest.EntitySystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcsTest.Systems
{
	public class ConsoleUI : EntitySystem
	{
		public const int MaxY = 20;
		public const int MaxX = 100;
		public ConsoleUI() : base(x=>x.Has<MapObject>())
		{
			Console.CursorVisible = false;
		}
		public override void Process(IEnumerable<Entity> entities)
		{
			Console.Clear();
			foreach (var entity in entities)
			{
				var mapObject = entity.Get<MapObject>();
				Console.SetCursorPosition(mapObject.X, MaxY - mapObject.Y);
				var professionComponent = entity.Get<Profession>();
				WriteInColor(mapObject, professionComponent == null ? Console.ForegroundColor : GetProfessionColor(professionComponent.Role));
			}
		}

		private void WriteInColor(MapObject mapObject, ConsoleColor color)
		{
			var previous = Console.ForegroundColor;
			Console.ForegroundColor = color;
			Console.Write(mapObject.Char);
			Console.ForegroundColor = previous;
		}

		private ConsoleColor GetProfessionColor(Role profession)
		{
			switch (profession)
			{
				case Role.Mage: return ConsoleColor.Blue;
				case Role.Priest: return ConsoleColor.Yellow;
				case Role.Warrior: return ConsoleColor.DarkRed;
				default: return Console.ForegroundColor;
			}
		}
	}
}
