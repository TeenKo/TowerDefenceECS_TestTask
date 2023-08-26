using System.Collections.Generic;
using Entitas;

namespace _Core_.EnemySpawner
{
    public class TrySpawnEnemyReactiveSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public TrySpawnEnemyReactiveSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.TrySpawnEnemy.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var waveManagerEntity = _contexts.game.waveManagerEntity;
            if (waveManagerEntity.enemyInWave.value >= waveManagerEntity.maxEnemyInWave.value) return;
            
            _contexts.game.CreateEntity().isSpawnEnemy = true;

            var enemySpawnerEntity = _contexts.game.enemySpawnerEntity;
            enemySpawnerEntity.AddSpawnTickTimer(enemySpawnerEntity.spawnTickTime.value);
            
            waveManagerEntity.ReplaceEnemyInWave(waveManagerEntity.enemyInWave.value + 1);
        }
    }
}