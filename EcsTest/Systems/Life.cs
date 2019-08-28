using System;
using System.Collections.Generic;
using System.Text;
using EcsTest.Components;
using EcsTest.EntitySystem;

namespace EcsTest.Systems
{
    public class Life : EntitySystem
    {
        public Life() : base(x => x.Has<Components.Life>())
        {

        }
        public override void Process(IEnumerable<Entity> entities)
        {
            foreach (var entity in entities)
            {
                var life = entity.Get<Components.Life>();
                life.HP -= 1;
                if (life.HP < 0)
                {
                    entity.Remove<Brain>();
                    entity.Remove<MapObject>();

                }
            }
        }
    }
}
