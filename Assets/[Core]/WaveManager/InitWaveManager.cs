using Entitas;

namespace _Core_.WaveManager
{
    public class InitWaveManager : IInitializeSystem
    {
        private readonly Contexts _contexts;

        public InitWaveManager(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Initialize()
        {
            var waveManagerEntity = _contexts.game.CreateEntity();
            waveManagerEntity.isWaveManager = true;
            waveManagerEntity.AddEnemyInWave(0);
            waveManagerEntity.AddMaxEnemyInWave(0);
            waveManagerEntity.AddWave(1);
            waveManagerEntity.AddDeathEnemyInWave(0);
            waveManagerEntity.AddTotalDeathEnemy(0);
        }
    }
}