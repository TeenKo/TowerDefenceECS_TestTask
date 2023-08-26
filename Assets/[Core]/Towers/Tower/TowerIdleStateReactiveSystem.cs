using System.Collections.Generic;
using _Core_.States.Components;
using _Core_.Tools;
using Entitas;

namespace _Core_.Towers.Tower
{
    public class TowerIdleStateReactiveSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public TowerIdleStateReactiveSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.IdleState.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.hasAttackTarget)
                {
                    GameTools.TransitionGameState(entity, new AttackStateComponent(), false);
                }
                else
                {
                    GameTools.TransitionGameState(entity, new SearchAttackTargetStateComponent(), false);
                }
            }
        }
    }
}