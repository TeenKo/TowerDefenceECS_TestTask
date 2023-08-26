using Entitas;
using Entitas.Unity;

namespace _Core_.Common
{
    public class MonobehAdvGameObjectPool : MonobehAdvGame
    {
        public delegate void OnDisableCallback(MonobehAdvGameObjectPool instance);
        public OnDisableCallback Disable;

        private void Start()
        {
            Disable?.Invoke(this);
        }

        public override void OnDestroyEntity(IEntity entity)
        {
            entity.OnDestroyEntity -= OnDestroyEntity;
            gameObject.Unlink();
            Disable?.Invoke(this);
        }
    }
}