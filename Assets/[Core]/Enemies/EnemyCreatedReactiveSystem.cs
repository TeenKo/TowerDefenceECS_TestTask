using System.Collections.Generic;
using _Core_.States.Components;
using _Core_.Tools;
using Entitas;

namespace _Core_.Enemies
{
    public class EnemyCreatedReactiveSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public EnemyCreatedReactiveSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.EnemyCreated.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var levelEntity = _contexts.game.gameLevelEntity;
            
            foreach (var entity in entities)
            {
                entity.transform.value.position = levelEntity.enemyStartPoint.value;
                GameTools.TransitionGameState(entity, new IdleStateComponent(), false);
            }
        }
    }
}