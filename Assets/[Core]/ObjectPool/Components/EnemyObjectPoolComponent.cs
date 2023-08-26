using _Core_.Enemies;
using Entitas;

namespace _Core_.ObjectPool.Components
{
    [Game]
    public class EnemyObjectPoolComponent : IComponent
    {
        public BaseObjectPool<EnemyView> value;
    }
}