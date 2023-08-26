using _Core_.Common;
using _Core_.NavMesh;
using Entitas;
using UnityEngine;

namespace _Core_.Enemies
{
    public class EnemyView : MonobehAdvGameObjectPool
    {
        [SerializeField] private NavMeshPathfinderAgent navMeshPathfinderAgent;
        public override void Link(IEntity entity)
        {
            base.Link(entity);
            
            navMeshPathfinderAgent.Link(GameEntity);
            GameEntity.isEnemyCreated = true;
        }

        public void TakeFromPool()
        {
            gameObject.SetActive(true);
        }
        
        public void ReturnToPool()
        {
            gameObject.SetActive(false);
        }
    }
}
