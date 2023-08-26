using System.Collections.Generic;
using _Core_.States.Components;
using _Core_.Tools;
using Entitas;

namespace _Core_.Towers.Tower
{
    public class TowerSearchAttackTargetStateReactiveSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;
        private readonly IGroup<GameEntity> _enemyEntitiesGroup;

        public TowerSearchAttackTargetStateReactiveSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
            _enemyEntitiesGroup = contexts.game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Enemy)
                .NoneOf(GameMatcher.DeathState));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.SearchAttackTargetState.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isTower;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var towerPosition = entity.transform.value.position;
                var distance = entity.attackDistance.value;
                var enemyEntityCreationIndex = -1;

                foreach (var enemyEntity in _enemyEntitiesGroup.GetEntities())
                {
                    var distanceToEnemy =
                        GameTools.GetFlatDistance(towerPosition, enemyEntity.transform.value.position);
                    if (distanceToEnemy > distance) continue;

                    enemyEntityCreationIndex = enemyEntity.entityCreationIndex.value;
                    distance = distanceToEnemy;
                }

                if (enemyEntityCreationIndex == -1)
                {
                    GameTools.TransitionGameState(entity, new SearchAttackTargetStateComponent(), false);
                    continue;
                }
                
                entity.AddAttackTarget(enemyEntityCreationIndex);
                GameTools.TransitionGameState(entity, new AttackStateComponent(), false);
            }
        }
    }
}