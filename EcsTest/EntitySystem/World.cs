using EcsTest.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EcsTest.Systems;

namespace EcsTest.EntitySystem
{
	public class World
	{
		List<Entity> entities = new List<Entity>();
		

		public Entity CreateEntity(params IComponent[] components)
		{
			var entity = new Entity()
			{
				Components = components.ToList()
			};
			entities.Add(entity);
			return entity;
		}

		public void Update()
		{
			foreach (var system in Systems)
			{
				system.Process(entities.Where(system.Filter));
			}
		}

		List<Systems.EntitySystem> systems = new List<Systems.EntitySystem>();
		public IEnumerable<Systems.EntitySystem> Systems => systems.AsReadOnly();
		public T AddSystem<T>(int index, T system) where T : Systems.EntitySystem
		{
			systems.Insert(index, system);
			return system;
		}


	}
}
