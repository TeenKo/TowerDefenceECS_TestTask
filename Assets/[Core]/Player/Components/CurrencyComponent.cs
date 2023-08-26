using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _Core_.Player.Components
{
    [Game, Event(EventTarget.Any)]
    public class CurrencyComponent : IComponent
    {
        public int value;
    }
}