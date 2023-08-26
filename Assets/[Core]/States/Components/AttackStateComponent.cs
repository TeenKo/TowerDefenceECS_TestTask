using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _Core_.States.Components
{
    [Game, Event(EventTarget.Self)]
    public sealed class AttackStateComponent : IComponent, IGameContextState
    {
        public List<StateObjectType> SetSateObjectType()
        {
            var list = new List<StateObjectType>()
            {
                StateObjectType.Tower
            };

            return list;
        }
    }
}