using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _Core_.WaveManager.Components
{
    [Game, Event(EventTarget.Any)]
    public class WaveComponent : IComponent
    {
        public int value;
    }
}