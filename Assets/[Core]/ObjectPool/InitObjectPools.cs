using Entitas;
using UnityEngine;

namespace _Core_.ObjectPool
{
    internal class InitObjectPools : IInitializeSystem
    {
        private readonly Contexts _contexts;

        public InitObjectPools(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Initialize()
        {
            var enemyCapsulePool = Object.FindObjectOfType<EnemyCapsulePool>(includeInactive: true);
            var enemyCapsulePoolEntity = _contexts.game.CreateEntity();
            enemyCapsulePool.Link(enemyCapsulePoolEntity);
            
            var enemySpherePool = Object.FindObjectOfType<EnemySpherePool>(includeInactive: true);
            var enemySpherePoolEntity = _contexts.game.CreateEntity();
            enemySpherePool.Link(enemySpherePoolEntity);
            
            var enemyCubePool = Object.FindObjectOfType<EnemyCubePool>(includeInactive: true);
            var enemyCubePoolEntity = _contexts.game.CreateEntity();
            enemyCubePool.Link(enemyCubePoolEntity);
        }
    }
}