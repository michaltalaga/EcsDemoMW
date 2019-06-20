using EcsTest.Components;
using EcsTest.EntitySystem;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EcsTest.Systems
{
	public class Movement : EntitySystem
	{
		public Movement() : base(x=>x.Has<MapObject>())
		{

		}
		public override void Process(IEnumerable<Entity> entities)
		{
			var allMapObjects = entities.Select(x => x.Get<MapObject>()).ToList();

			foreach (var entity in entities.Where(x=>x.Has<NextMove>()))
			{
				var nextMove = entity.Get<NextMove>();
				var mapObject = entity.Get<MapObject>();
				mapObject.X += nextMove.Direction == Direction.Right ? 1 : 0;
				mapObject.X += nextMove.Direction == Direction.Left ? -1 : 0;
				mapObject.Y += nextMove.Direction == Direction.Up ? 1 : 0;
				mapObject.Y += nextMove.Direction == Direction.Down ? -1 : 0;
				if (Collision(mapObject, allMapObjects))
				{
					mapObject.X -= nextMove.Direction == Direction.Right ? 1 : 0;
					mapObject.X -= nextMove.Direction == Direction.Left ? -1 : 0;
					mapObject.Y -= nextMove.Direction == Direction.Up ? 1 : 0;
					mapObject.Y -= nextMove.Direction == Direction.Down ? -1 : 0;
				}
				entity.Remove<NextMove>();
			}

		}

		private bool Collision(MapObject mapObject, IEnumerable<MapObject> allMapObjects)
		{
			return allMapObjects.Except(new[] { mapObject }).Any(m => m.X == mapObject.X && m.Y == mapObject.Y);
		}
		//protected override void ProcessEntities(IDictionary<int, Entity> entities)
		//{
		//	foreach (var entity in entities.Values)
		//	{
		//		var nextMove = entity.GetComponent<NextMove>();
		//		var mapObject = entity.GetComponent<MapObject>();
		//		mapObject.X += nextMove.Direction == Direction.Right ? 1 : 0;
		//		mapObject.X += nextMove.Direction == Direction.Left ? -1 : 0;
		//		mapObject.Y += nextMove.Direction == Direction.Up ? 1 : 0;
		//		mapObject.Y += nextMove.Direction == Direction.Down ? -1 : 0;
		//		entity.RemoveComponent<NextMove>();
		//	}

		//}
	}
}
