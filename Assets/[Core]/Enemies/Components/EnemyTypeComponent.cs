using Entitas;

namespace _Core_.Enemies.Components
{
    [Game]
    public class EnemyTypeComponent : IComponent
    {
        public EnemyType value;
    }

    public enum EnemyType
    {
        Capsule,
        Cube,
        Sphere
    }
}