using _Core_.Common;
using Entitas;
using UnityEngine;

namespace _Core_.Towers.TowerPoints
{
    public class TowerPointView : MonobehAdvGame
    {
        [SerializeField] private Transform towerPoint;
        public override void Link(IEntity entity)
        {
            base.Link(entity);
            GameEntity.AddTowerPoint(towerPoint.position);
            GameEntity.AddBusy(false, -1);
        }
    }
}