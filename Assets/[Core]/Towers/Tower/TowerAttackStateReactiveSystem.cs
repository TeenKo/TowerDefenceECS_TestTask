using System.Collections.Generic;
using _Core_.States.Components;
using _Core_.Tools;
using Entitas;

namespace _Core_.Towers.Tower
{
    public class TowerAttackStateReactiveSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public TowerAttackStateReactiveSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AttackState.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isTower;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.hasAttackTarget == false)
                {
                    GameTools.TransitionGameState(entity, new IdleStateComponent(), false);
                    continue;
                }

                var attackTargetEntity = _contexts.game.GetEntityWithEntityCreationIndex(entity.attackTarget.value);
                var towerPosition = entity.transform.value.position;
                var enemyPosition = attackTargetEntity.transform.value.position;
                var attackDistance = entity.attackDistance.value;
                
                if (GameTools.IsInFlatRange(towerPosition, enemyPosition, attackDistance) == false)
                {
                    GameTools.TransitionGameState(entity, new IdleStateComponent(), false);
                    continue;
                }

                if (entity.hasRechargeAttackTimer)
                {
                    GameTools.TransitionGameState(entity, new AttackStateComponent(), false);
                }
                else
                {
                    _contexts.game.CreateEntity().AddMakeDamage(entity.attackTarget.value, entity.damage.value);
                    entity.AddRechargeAttackTimer(entity.attackRate.value);
                }
            }
        }
    }
}