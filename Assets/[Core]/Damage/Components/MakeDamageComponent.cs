using Entitas;

namespace _Core_.Damage.Components
{
    [Game]
    public class MakeDamageComponent : IComponent
    {
        public int creationIndex;
        public float damage;
    }
}