using System.Collections.Generic;
using Entitas;

namespace _Core_.ChangeCurrency
{
    public class ChangeCurrencyReactiveSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public ChangeCurrencyReactiveSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ChangeCurrency.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var targetEntity = _contexts.game.GetEntityWithEntityCreationIndex(entity.changeCurrency.creationIndex);
                targetEntity.ReplaceCurrency(targetEntity.currency.value + entity.changeCurrency.currency);
                entity.Destroy();
            }
        }
    }
}