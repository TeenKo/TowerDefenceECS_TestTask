using System.Collections.Generic;
using _Core_.LevelCore.Configs;
using _Core_.States;
using _Core_.Towers.Tower.Configs;
using Entitas;
using UnityEngine;

namespace _Core_.Towers.Tower
{
    public class CreateTowerReactiveSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;
        private readonly TowerConfig _towerConfig;

        public CreateTowerReactiveSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
            _towerConfig = LevelConfig.Instance.TowerConfig;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.CreateTower.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var towerPointEntity =
                    _contexts.game.GetEntityWithEntityCreationIndex(entity.createTower.pointCreationIndex);
                var towerView = Object.Instantiate(_towerConfig.TowerView, towerPointEntity.transform.value, true);
                towerView.transform.position = entity.createTower.position;

                var towerEntity = _contexts.game.CreateEntity();
                towerEntity.isTower = true;
                towerEntity.AddDamage(_towerConfig.Damage);
                towerEntity.AddAttackRate(_towerConfig.AttackRate);
                towerEntity.AddStateObjectType(StateObjectType.Tower);
                towerEntity.AddLevelMultiply(_towerConfig.DamageMultiply, _towerConfig.AttackRateMultiply,
                    _towerConfig.PricePerLevel);
                towerEntity.AddLevel(0);
                towerEntity.AddAttackDistance(_towerConfig.AttackDistance);
                towerEntity.AddPrice(_towerConfig.Price);
                towerEntity.AddMinAttackRate(_towerConfig.MinAttackRate);
                towerEntity.isIdleState = true;
                towerView.Link(towerEntity);

                towerPointEntity.ReplaceBusy(true, towerEntity.entityCreationIndex.value);

                entity.Destroy();
            }
        }
    }
}