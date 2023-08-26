using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _Core_.Common.Components
{
    [Game, Event(EventTarget.Self)]
    public sealed class LevelMultiplyComponent : IComponent
    {
        public float damage;
        public float attackRate;
        public int price;
    }
}