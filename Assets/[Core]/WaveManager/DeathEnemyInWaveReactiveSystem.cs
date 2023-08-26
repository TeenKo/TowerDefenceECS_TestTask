using System.Collections.Generic;
using Entitas;

namespace _Core_.WaveManager
{
    public class DeathEnemyInWaveReactiveSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public DeathEnemyInWaveReactiveSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.DeathEnemyInWave.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.deathEnemyInWave.value < entity.maxEnemyInWave.value) continue;
                if(entity.maxEnemyInWave.value == 0) continue;
                
                var enemySpawnerEntity = _contexts.game.enemySpawnerEntity;
                enemySpawnerEntity.AddWaveDelayTimer(enemySpawnerEntity.waveDelayTime.value);
                entity.ReplaceWave(entity.wave.value + 1);
            }
        }
    }
}