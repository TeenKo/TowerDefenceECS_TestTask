using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace _Core_.EnemySpawner
{
    public class TimeBeforeFirstSpawnReactiveSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public TimeBeforeFirstSpawnReactiveSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.TimeBeforeFirstSpawn.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var time = entity.timeBeforeFirstSpawn.value - Time.deltaTime;

                if (time <= 0)
                {
                    _contexts.game.CreateEntity().isTrySpawnEnemy = true;
                    entity.RemoveTimeBeforeFirstSpawn();
                    break;
                }
                
                entity.ReplaceTimeBeforeFirstSpawn(time);
            }
        }
    }
}