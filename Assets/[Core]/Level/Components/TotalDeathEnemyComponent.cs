using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _Core_.Level.Components
{
    [Game, Event(EventTarget.Any)]
    public class TotalDeathEnemyComponent : IComponent
    {
        public int value;
    }
}