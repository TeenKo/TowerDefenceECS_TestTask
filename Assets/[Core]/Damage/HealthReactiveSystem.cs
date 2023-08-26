using System.Collections.Generic;
using _Core_.States.Components;
using _Core_.Tools;
using Entitas;

namespace _Core_.Damage
{
    public class HealthReactiveSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public HealthReactiveSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Health.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.health.value > 0) continue;
                if (entity.hasPathfinderAgent) entity.pathfinderAgent.value.OffAgent();
                GameTools.TransitionGameState(entity, new DeathStateComponent(), false);
            }
        }
    }
}