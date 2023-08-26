using System.Collections.Generic;
using Entitas;

namespace _Core_.Enemies
{
    public class EnemyIdleStateReactiveSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public EnemyIdleStateReactiveSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.IdleState.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isEnemy;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var levelEntity = _contexts.game.gameLevelEntity;

            foreach (var entity in entities)
            {
                entity.pathfinderAgent.value.MoveToDestination(levelEntity.enemyFinishPoint.value,
                    () => entity.isFinished = true);
            }
        }
    }
}