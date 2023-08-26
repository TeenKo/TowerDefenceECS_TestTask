using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _Core_.Common.Components
{
    [Game, Event(EventTarget.Self)]
    public sealed class MaxHealthComponent : IComponent
    {
        public float value;
    }
}