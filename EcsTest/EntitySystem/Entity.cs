using EcsTest.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EcsTest.EntitySystem
{
	public class Entity
	{
		public List<IComponent> Components { get; set; } = new List<IComponent>();
		public T Get<T>() => Components.OfType<T>().SingleOrDefault();
		public void Remove<T>()
		{
			Components = Components.Where(c => c.GetType() != typeof(T)).ToList();
		}
		public void Add(IComponent component)
		{
			Components = Components.Where(c => c.GetType() != component.GetType()).ToList();
			Components.Add(component);
		}
		public bool Has<T>() => Components.Any(c => c.GetType() == typeof(T));
		public bool Has<T1, T2>() => Has<T1>() && Has<T2>();
		public bool Has<T1, T2, T3>() => Has<T1>() && Has<T2>() && Has<T3>();
	}
}