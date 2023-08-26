using System;
using _Core_.Common;
using Entitas;
using UnityEngine.Pool;

namespace _Core_.ObjectPool
{
    public abstract class BaseObjectPool<T> : MonobehAdvGame where T : class
    {
        private ObjectPool<T> _objectPool;
        protected abstract void InitPoolObject();
        protected abstract T CreatePoolObject();
        protected abstract void OnTakeFromPool(T instance);
        protected abstract void OnReturnToPool(T instance);
        protected abstract void OnDestroyObject(T instance);

        public override void Link(IEntity entity)
        {
            base.Link(entity);
            GameEntity.AddTotalSize(0);
            GameEntity.AddActiveObjects(0);
            GameEntity.AddInactiveObjects(0);
        }

        protected void InitializeObjectPool(Func<T> createFunc, Action<T> onTakeAction, Action<T> onReturnAction,
            Action<T> onDestroyAction, bool collectionCheck = false, int defaultCapacity = 10, int maxSize = 10000)
        {
            _objectPool = new ObjectPool<T>(createFunc, onTakeAction, onReturnAction, onDestroyAction, collectionCheck,
                defaultCapacity, maxSize);
        }

        private void Update()
        {
            RecalculateObjectsInPool();
        }

        public T GetObject()
        {
            return _objectPool.Get();
        }

        protected void ReturnToObjectPool(MonobehAdvGameObjectPool instance)
        {
            _objectPool.Release(instance as T);
        }

        private void RecalculateObjectsInPool()
        {
            if(GameEntity is null) return;
            
            if (GameEntity.hasTotalSize && GameEntity.totalSize.value != _objectPool.CountAll)
            {
                GameEntity.ReplaceTotalSize(_objectPool.CountAll);
            }

            if (GameEntity.hasActiveObjects && GameEntity.activeObjects.value != _objectPool.CountActive)
            {
                GameEntity.ReplaceActiveObjects(_objectPool.CountActive);
            }
            
            if (GameEntity.hasInactiveObjects && GameEntity.inactiveObjects.value != _objectPool.CountInactive)
            {
                GameEntity.ReplaceInactiveObjects(_objectPool.CountInactive);
            }
        }
    }
}