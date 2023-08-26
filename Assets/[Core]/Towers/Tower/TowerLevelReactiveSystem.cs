using System.Collections.Generic;
using Entitas;

namespace _Core_.Towers.Tower
{
    public class TowerLevelReactiveSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public TowerLevelReactiveSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Level.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isTower;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var level = entity.level.value;
                var damage = entity.damage.value + entity.levelMultiply.damage * level;
                var attackRate = entity.attackRate.value - entity.levelMultiply.attackRate * level;
                var price = entity.price.value + entity.levelMultiply.price * level;
                
                entity.ReplaceDamage(damage);
                entity.ReplaceAttackRate(attackRate);
                entity.ReplacePrice(price);
            }
        }
    }
}