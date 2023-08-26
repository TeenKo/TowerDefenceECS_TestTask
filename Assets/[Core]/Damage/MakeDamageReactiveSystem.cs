using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace _Core_.Damage
{
    public class MakeDamageReactiveSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public MakeDamageReactiveSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.MakeDamage.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var targetEntity = _contexts.game.GetEntityWithEntityCreationIndex(entity.makeDamage.creationIndex);

                if (targetEntity == null)
                {
                    Debug.Log("targetEntity == null");
                    continue;
                }

                if (targetEntity.hasTakeDamage)
                {
                    targetEntity.ReplaceTakeDamage(targetEntity.takeDamage.value + entity.makeDamage.damage);
                }
                else
                {
                    targetEntity.AddTakeDamage(entity.makeDamage.damage);
                }

                entity.Destroy();
            }
        }
    }
}