using Entitas;

namespace _Core_.ObjectPool
{
    internal sealed class ObjectPoolSystems : Systems
    {
        public ObjectPoolSystems(Contexts contexts)
        {
            Add(new InitObjectPools(contexts));
        }
    }
}