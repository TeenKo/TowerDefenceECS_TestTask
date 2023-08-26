using System.Collections.Generic;
using _Core_.LevelCore.Configs;
using _Core_.WaveManager.Configs;
using Entitas;
using UnityEngine;

namespace _Core_.WaveManager
{
    public class WaveCountReactiveSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;
        private readonly WaveConfig _waveConfig;

        public WaveCountReactiveSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
            _waveConfig = LevelConfig.Instance.WaveConfig;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Wave.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var wave = entity.wave.value;
                var maxEnemyInWave = Random.Range(wave, wave + _waveConfig.MaxMonstersInLevel);
                
                entity.ReplaceDeathEnemyInWave(0);
                entity.ReplaceEnemyInWave(0);
                entity.ReplaceMaxEnemyInWave(maxEnemyInWave);
            }
        }
    }
}