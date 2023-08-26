using Entitas;

namespace _Core_.Damage
{
    public sealed class DamageSystems : Systems
    {
        public DamageSystems(Contexts contexts)
        {
            Add(new MakeDamageReactiveSystem(contexts));
            Add(new TakeDamageReactiveSystem(contexts));
            Add(new HealthReactiveSystem(contexts));
        }
    }
}