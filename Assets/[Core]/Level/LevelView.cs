using _Core_.Common;
using _Core_.Towers.TowerPoints;
using Entitas;
using UnityEngine;

namespace _Core_.Level
{
    public class LevelView : MonobehAdvGame
    {
        [SerializeField] private Transform enemyStartPoint;
        [SerializeField] private Transform enemyFinishPoint;
        [SerializeField] private int levelNumber;
        [SerializeField] private TowerPointView[] towerPointViews;
        public override void Link(IEntity entity)
        {
            base.Link(entity);
            GameEntity.isGameLevel = true;
            GameEntity.AddGameLevelNumber(levelNumber);
            GameEntity.AddEnemyStartPoint(enemyStartPoint.position);
            GameEntity.AddEnemyFinishPoint(enemyFinishPoint.position);

            foreach (var towerPointView in towerPointViews)
            {
                var towerPointEntity = Contexts.sharedInstance.game.CreateEntity();
                towerPointView.Link(towerPointEntity);
            }
        }
    }
}