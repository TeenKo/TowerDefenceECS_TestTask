using System.Collections.Generic;
using Entitas;

namespace _Core_.Damage
{
    public class TakeDamageReactiveSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public TakeDamageReactiveSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.TakeDamage.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isDeathState == false;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var health = entity.health.value - entity.takeDamage.value;
                entity.ReplaceHealth(health);
            }
        }
    }
}