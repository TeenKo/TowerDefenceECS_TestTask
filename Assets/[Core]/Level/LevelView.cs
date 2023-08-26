using _Core_.Common;
using _Core_.ObjectPool;
using _Core_.Towers.TowerPoints;
using Entitas;
using UnityEngine;

namespace _Core_.Level
{
    public class LevelView : MonobehAdvGame
    {
        [Header("level Settings")]
        [SerializeField] private int levelNumber;
        
        [Header("Enemy Way")]
        [SerializeField] private Transform enemyStartPoint;
        [SerializeField] private Transform enemyFinishPoint;
        
        [Header("Tower Point")]
        [SerializeField] private TowerPointView[] towerPointViews;

        [Header("Object Pools")] 
        [SerializeField] private EnemyObjectPool[] enemyObjectPools;
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

            foreach (var enemyObjectPool in enemyObjectPools)
            {
                var enemyObjectEntity = Contexts.sharedInstance.game.CreateEntity();
                enemyObjectPool.Link(enemyObjectEntity);
            }
        }
    }
}