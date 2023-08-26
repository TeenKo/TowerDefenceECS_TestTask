using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _Core_.Damage.Components
{
    [Game, Event(EventTarget.Self), Cleanup(CleanupMode.RemoveComponent)]
    public class TakeDamageComponent : IComponent
    {
        public float value;
    }
}