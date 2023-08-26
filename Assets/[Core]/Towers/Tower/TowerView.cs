using _Core_.Common;
using Entitas;
using TMPro;
using UnityEngine;

namespace _Core_.Towers.Tower
{
    public class TowerView : MonobehAdvGame, IPriceListener
    {
        [SerializeField] private TextMeshPro priceText;
        public override void Link(IEntity entity)
        {
            base.Link(entity);
            
            GameEntity.AddPriceListener(this);
        }

        private void OnMouseDown()
        {
            GameEntity.isTryPurchaseLevel = true;
        }

        public void OnPrice(GameEntity entity, int value)
        {
            priceText.text = $"{value} gold";
        }
    }
}