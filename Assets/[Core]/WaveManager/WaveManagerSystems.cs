using Entitas;

namespace _Core_.WaveManager
{
    public sealed class WaveManagerSystems : Systems
    {
        public WaveManagerSystems(Contexts contexts)
        {
            Add(new InitWaveManager(contexts));
            Add(new WaveCountReactiveSystem(contexts));
            Add(new DeathEnemyInWaveReactiveSystem(contexts));
        }
    }
}