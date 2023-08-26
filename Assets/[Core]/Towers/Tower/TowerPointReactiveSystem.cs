using System.Collections.Generic;
using Entitas;

namespace _Core_.Towers.Tower
{
    public class TowerPointReactiveSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public TowerPointReactiveSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.TowerPoint.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.busy.busy == false;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                _contexts.game.CreateEntity().AddCreateTower(entity.towerPoint.value, entity.entityCreationIndex.value);
            }
        }
    }
}