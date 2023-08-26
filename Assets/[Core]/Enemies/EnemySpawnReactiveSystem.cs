using System.Collections.Generic;
using System.Linq;
using _Core_.LevelCore.Configs;
using _Core_.States;
using _Core_.WaveManager.Configs;
using Entitas;
using UnityEngine;

namespace _Core_.Enemies
{
    public class EnemySpawnReactiveSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;
        private readonly WaveConfig _waveConfig;
        private readonly IGroup<GameEntity> _enemyObjectPoolEntitiesGroup;

        public EnemySpawnReactiveSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
            _waveConfig = LevelConfig.Instance.WaveConfig;
            _enemyObjectPoolEntitiesGroup =
                contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.EnemyObjectPool, GameMatcher.EnemyType));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.SpawnEnemy.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var waveManagerEntity = _contexts.game.waveManagerEntity;

            foreach (var entity in entities)
            {
                var enemyConfig = _waveConfig.EnemyConfigs[Random.Range(0, _waveConfig.EnemyConfigs.Length)];
                var enemyObjectPoolEntity = _enemyObjectPoolEntitiesGroup.GetEntities()
                    .FirstOrDefault(e => e.enemyType.value == enemyConfig.EnemyType);

                if (enemyObjectPoolEntity == null)
                {
                    Debug.Log("enemyObjectPoolEntity == null");
                    continue;
                }

                var enemyView = enemyObjectPoolEntity.enemyObjectPool.value.GetObject();
                var enemyEntity = _contexts.game.CreateEntity();
                var health = enemyConfig.Health + waveManagerEntity.wave.value * enemyConfig.MultiplyHealthPerWave;

                enemyEntity.isEnemy = true;
                enemyEntity.AddSpeed(enemyConfig.Speed);
                enemyEntity.AddDamage(enemyConfig.Damage);
                enemyEntity.AddHealth(health);
                enemyEntity.AddReward(enemyConfig.Reward);
                enemyEntity.AddStateObjectType(StateObjectType.Enemy);
                enemyView.Link(enemyEntity);

                entity.Destroy();
            }
        }
    }
}