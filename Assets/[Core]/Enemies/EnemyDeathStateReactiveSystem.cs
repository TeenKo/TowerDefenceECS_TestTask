using System.Collections.Generic;
using Entitas;

namespace _Core_.Enemies
{
    public class EnemyDeathStateReactiveSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;
        private readonly IGroup<GameEntity> _attackTargetEntitiesGroup;

        public EnemyDeathStateReactiveSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
            _attackTargetEntitiesGroup =
                contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Tower, GameMatcher.AttackTarget));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.DeathState.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isEnemy;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var waveManagerEntity = _contexts.game.waveManagerEntity;
            var playerEntity = _contexts.game.playerEntity;
            
            foreach (var entity in entities)
            {
                if (entity.isFinished == false)
                {
                    var playerCreationIndex = _contexts.game.playerEntity.entityCreationIndex.value;

                    _contexts.game.CreateEntity().AddChangeCurrency(entity.reward.value, playerCreationIndex);
                }

                foreach (var attackTargetEntity in _attackTargetEntitiesGroup.GetEntities())
                {
                    if (attackTargetEntity.attackTarget.value == entity.entityCreationIndex.value)
                    {
                        attackTargetEntity.RemoveAttackTarget();
                    }
                }

                waveManagerEntity.ReplaceDeathEnemyInWave(waveManagerEntity.deathEnemyInWave.value + 1);
                playerEntity.ReplaceTotalDeathEnemy(playerEntity.totalDeathEnemy.value + 1);
                entity.Destroy();
            }
        }
    }
}