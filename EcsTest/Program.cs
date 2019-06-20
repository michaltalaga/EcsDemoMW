using EcsTest.Components;
using EcsTest.EntitySystem;
using EcsTest.Systems;
using System;
using System.Threading;

namespace EcsTest
{
	class Program
	{
		static void Main(string[] args)
		{
			var world = new World();

			CreatePlayer(world);
			BuildRooms(world);
			AddMonsters(world);

			world.AddSystem(0, new ConsoleUI());
			world.Update();


			world.AddSystem(0, new PlayerInput());
			world.AddSystem(1, new Systems.AI());

			world.AddSystem(2, new Movement());
			world.AddSystem(3, new Systems.Life());
			world.AddSystem(0, new Demo());




			while (true)
			{
				world.Update();
			}
		}

		private static void AddMonsters(World world)
		{
			world.CreateEntity(new MapObject { X = 3, Y = 7, Char = 'g' }, new Movable(), new Components.Brain(), new Profession(Role.Warrior), new Components.Life() { HP = 10 });
			world.CreateEntity(new MapObject { X = 6, Y = 7, Char = 'l' }, new Movable(), new Components.Brain(), new Components.Life() { HP = 5 });

		}

		private static void CreatePlayer(World world)
		{
			world.CreateEntity(new Player(), new MapObject { X = 2, Y = 4, Char = '@' }, new Movable(), new Profession(Role.Priest), new Components.Life() { HP = 20 } );
		}

		private static void BuildRooms(World world)
		{
			for (int x = 0; x <= ConsoleUI.MaxX; x++)
			{
				world.CreateEntity(new MapObject { X = x, Y = 0, Char = '#' });
				world.CreateEntity(new MapObject { X = x, Y = ConsoleUI.MaxY, Char = '#' });
			}
			for (int y = 0; y < ConsoleUI.MaxY; y++)
			{
				world.CreateEntity(new MapObject { X = 0, Y = y, Char = '#' });
				world.CreateEntity(new MapObject { X = ConsoleUI.MaxX, Y = y, Char = '#' });
			}

			for (int x = 5; x <= 10; x++)
			{
				world.CreateEntity(new MapObject { X = x, Y = 5, Char = '#' });
				world.CreateEntity(new MapObject { X = x, Y = 10, Char = '#' });
			}
			for (int y = 5; y < 10; y++)
			{
				world.CreateEntity(new MapObject { X = 5, Y = y, Char = '#' });
				world.CreateEntity(new MapObject { X = 10, Y = y, Char = '#' });
			}
		}
	}
}
