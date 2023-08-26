using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _Core_.States.Components
{
    [Game, Event(EventTarget.Self)]
    public sealed class DeathStateComponent : IComponent, IGameContextState
    {
        public List<StateObjectType> SetSateObjectType()
        {
            var list = new List<StateObjectType>()
            {
                StateObjectType.Enemy,
                StateObjectType.Player
            };

            return list;
        }
    }
}