using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _Core_.UI.Components
{
    [UI, Event(EventTarget.Any), Cleanup(CleanupMode.DestroyEntity)]
    public class ChangePlayerHpComponent : IComponent
    {
        public float health;
        public float maxHealth;
    }
}