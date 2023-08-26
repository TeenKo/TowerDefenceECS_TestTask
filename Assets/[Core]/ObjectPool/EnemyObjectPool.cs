using _Core_.Enemies;
using _Core_.Enemies.Components;
using Entitas;
using UnityEngine;

namespace _Core_.ObjectPool
{
    public class EnemyObjectPool : BaseObjectPool<EnemyView>
    {
        [SerializeField] private EnemyView enemyView;
        [SerializeField] private int countObjectsOnStart;
        [SerializeField] private int maxObjectsInPool;
        [SerializeField] private EnemyType enemyType;
        
        public override void Link(IEntity entity)
        {
            InitPoolObject();
            base.Link(entity);
            GameEntity.AddEnemyObjectPool(this);
            GameEntity.AddEnemyType(enemyType);
            for (var i = 0; i < countObjectsOnStart; i++) GetObject();
        }
        
        protected override void InitPoolObject()
        {
            InitializeObjectPool(CreatePoolObject, OnTakeFromPool, OnReturnToPool, OnDestroyObject, false,
                maxObjectsInPool, countObjectsOnStart);
        }

        protected override EnemyView CreatePoolObject()
        {
            var enemy = Instantiate(enemyView, Vector3.one, Quaternion.identity, gameObject.transform);
            enemy.Disable += ReturnToObjectPool;
            return enemy;
        }

        protected override void OnTakeFromPool(EnemyView instance)
        {
            instance.TakeFromPool();
        }

        protected override void OnReturnToPool(EnemyView instance)
        {
            instance.ReturnToPool();
        }

        protected override void OnDestroyObject(EnemyView instance)
        {
            instance.Disable -= ReturnToObjectPool;
        }
    }
}
