using Entitas;

namespace _Core_.Common.Interfaces
{
    public interface IViewObject
    {
        public void Link(IEntity entity);
        public void OnDestroyEntity(IEntity entity);
        public void DestroyObject();
    }
}
