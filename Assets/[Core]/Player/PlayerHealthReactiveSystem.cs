using System.Collections.Generic;
using Entitas;

namespace _Core_.Player
{
    public class PlayerHealthReactiveSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public PlayerHealthReactiveSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Health.Added());
            ;        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isPlayer;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                _contexts.uI.CreateEntity().AddChangePlayerHp(entity.health.value, entity.maxHealth.value);
            }
        }
    }
}