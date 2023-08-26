using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _Core_.Common.Components
{
    [Game, Event(EventTarget.Self)]
    public sealed class AttackDistanceComponent : IComponent
    {
        public float value;
    }
}