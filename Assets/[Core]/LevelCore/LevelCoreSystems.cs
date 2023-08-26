using _Core_.ChangeCurrency;
using _Core_.Damage;
using _Core_.Enemies;
using _Core_.EnemySpawner;
using _Core_.Level;
using _Core_.ObjectPool;
using _Core_.Player;
using _Core_.Towers.Tower;
using _Core_.WaveManager;
using Entitas;

namespace _Core_.LevelCore
{
    public sealed class LevelCoreSystems : Systems
    {
        public LevelCoreSystems(Contexts contexts)
        {
            Add(new LevelViewSystems(contexts));
            Add(new WaveManagerSystems(contexts));
            Add(new EnemySpawnSystems(contexts));
            Add(new EnemySystems(contexts));
            Add(new PlayerSystems(contexts));
            Add(new DamageSystems(contexts));
            Add(new TowerSystems(contexts));
            Add(new ChangeCurrencySystems(contexts));

            Add(new GameEventSystems(contexts));
            Add(new UIEventSystems(contexts));
            Add(new UICleanupSystems(contexts));
            Add(new GameCleanupSystems(contexts));
        }
    }
}
