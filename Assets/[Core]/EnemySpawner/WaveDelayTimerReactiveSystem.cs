using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace _Core_.EnemySpawner
{
    public class WaveDelayTimerReactiveSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public WaveDelayTimerReactiveSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.WaveDelayTimer.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var time = entity.waveDelayTimer.value - Time.deltaTime;

                if (time <= 0)
                {
                    _contexts.game.CreateEntity().isTrySpawnEnemy = true;
                    entity.RemoveWaveDelayTimer();
                    continue;
                }

                entity.ReplaceWaveDelayTimer(time);
            }
        }
    }
}