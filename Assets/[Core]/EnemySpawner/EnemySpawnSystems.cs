using Entitas;

namespace _Core_.EnemySpawner
{
    public sealed class EnemySpawnSystems : Systems
    {
        public EnemySpawnSystems(Contexts contexts)
        {
            Add(new InitEnemySpawnerSystem(contexts));
            Add(new TimeBeforeFirstSpawnReactiveSystem(contexts));
            Add(new TrySpawnEnemyReactiveSystem(contexts));
            Add(new SpawnTickTimerReactiveSystem(contexts));
            Add(new WaveDelayTimerReactiveSystem(contexts));
        }
    }
}