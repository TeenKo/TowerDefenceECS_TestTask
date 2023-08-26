using System.Collections.Generic;
using Entitas;

namespace _Core_.Towers.Tower
{
    public class TowerTryPurchaseLevelReactiveSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public TowerTryPurchaseLevelReactiveSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.TryPurchaseLevel.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isTower;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var playerEntity = _contexts.game.playerEntity;

            foreach (var entity in entities)
            {
                entity.isTryPurchaseLevel = false;

                if (playerEntity.currency.value <= entity.price.value) continue;
                
                _contexts.game.CreateEntity()
                    .AddChangeCurrency(entity.price.value * -1, playerEntity.entityCreationIndex.value);
                entity.ReplaceLevel(entity.level.value + 1);
            }
        }
    }
}