using System.Collections.Generic;
using Entitas;

namespace _Core_.Player
{
    public class PlayerDeathStateReactiveSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public PlayerDeathStateReactiveSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.DeathState.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isPlayer;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            _contexts.game.gameManagerEntity.isDefeatState = true;
        }
    }
}