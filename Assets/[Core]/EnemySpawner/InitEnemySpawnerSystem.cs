using _Core_.EnemySpawner.Configs;
using _Core_.LevelCore.Configs;
using Entitas;

namespace _Core_.EnemySpawner
{
    public class InitEnemySpawnerSystem : IInitializeSystem
    {
        private readonly Contexts _contexts;
        private readonly EnemySpawnerConfig _enemySpawnerConfig;

        public InitEnemySpawnerSystem(Contexts contexts)
        {
            _contexts = contexts;
            _enemySpawnerConfig = LevelConfig.Instance.EnemySpawnerConfig;
        }

        public void Initialize()
        {
            var enemySpawnerEntity = _contexts.game.CreateEntity();
            enemySpawnerEntity.isEnemySpawner = true;
            enemySpawnerEntity.AddSpawnTickTime(_enemySpawnerConfig.EnemySpawnTick);
            enemySpawnerEntity.AddWaveDelayTime(_enemySpawnerConfig.EnemySpawnDelay);
            enemySpawnerEntity.AddTimeBeforeFirstSpawn(_enemySpawnerConfig.TimeBeforeSpawn);
        }
    }
}