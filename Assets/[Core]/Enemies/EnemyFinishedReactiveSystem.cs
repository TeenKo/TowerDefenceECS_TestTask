using System.Collections.Generic;
using _Core_.States.Components;
using _Core_.Tools;
using Entitas;

namespace _Core_.Enemies
{
    public class EnemyFinishedReactiveSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public EnemyFinishedReactiveSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Finished.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isEnemy;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var playerEntity = _contexts.game.playerEntity;

            foreach (var entity in entities)
            {
                _contexts.game.CreateEntity().AddMakeDamage(playerEntity.entityCreationIndex.value, entity.damage.value);
                GameTools.TransitionGameState(entity, new DeathStateComponent(), false);
            }
        }
    }
}