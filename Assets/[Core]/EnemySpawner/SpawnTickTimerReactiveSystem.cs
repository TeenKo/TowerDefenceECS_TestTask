using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace _Core_.EnemySpawner
{
    public class SpawnTickTimerReactiveSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;
        public SpawnTickTimerReactiveSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.SpawnTickTimer.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var time = entity.spawnTickTimer.value - Time.deltaTime;

                if (time <= 0)
                {
                    _contexts.game.CreateEntity().isTrySpawnEnemy = true;
                    entity.RemoveSpawnTickTimer();
                    continue;
                }

                entity.ReplaceSpawnTickTimer(time);
            }
        }
    }
}