using System.Collections.Generic;
using Entitas;

namespace _Core_.GameManager
{
    public class DefeatStateReactiveSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;
        private readonly IGroup<GameEntity> _pathfinderAgentEntitiesGroup;

        public DefeatStateReactiveSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
            _pathfinderAgentEntitiesGroup = contexts.game.GetGroup(GameMatcher.PathfinderAgent);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.DefeatState.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var pathfinderAgentEntity in _pathfinderAgentEntitiesGroup)
            {
                pathfinderAgentEntity.pathfinderAgent.value.ResetAgent();
            }
        }
    }
}