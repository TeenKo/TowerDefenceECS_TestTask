using Entitas;

namespace _Core_.Common
{
    public class MonobehAdvGame : MonobehAdv
    {
        public GameEntity GameEntity { get; private set; }

        public override void Link(IEntity entity)
        {
            base.Link(entity);
            GameEntity = (GameEntity)entity;
            GameEntity.AddTransform(transform);
            GameEntity.AddViewObject(this);
            GameEntity.AddEntityCreationIndex(GameEntity.creationIndex);
        }
    }
}
