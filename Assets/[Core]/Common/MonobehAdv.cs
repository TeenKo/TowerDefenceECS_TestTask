using _Core_.Common.Interfaces;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace _Core_.Common
{
    public class MonobehAdv : MonoBehaviour, IViewObject
    {
        public virtual void Link(IEntity entity)
        {
            gameObject.Link(entity);
            entity.OnDestroyEntity += OnDestroyEntity;
        }

        public virtual void OnDestroyEntity(IEntity entity)
        {
            entity.OnDestroyEntity -= OnDestroyEntity;
            if (gameObject.GetEntityLink().entity != null) gameObject.Unlink();
            Destroy(gameObject);
        }

        public void DestroyObject()
        {
        }
    }
}