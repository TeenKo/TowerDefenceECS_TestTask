using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Core_.UI
{
    public class GameScreenView : MonoBehaviour, IAnyCurrencyListener, IAnyChangePlayerHpListener
    {
        [SerializeField] private TextMeshProUGUI currency;
        [SerializeField] private Image hpImage;
        [SerializeField] private TextMeshProUGUI hpText;

        private void Awake()
        {
            Contexts.sharedInstance.game.CreateEntity().AddAnyCurrencyListener(this);
            Contexts.sharedInstance.uI.CreateEntity().AddAnyChangePlayerHpListener(this);
        }

        public void OnAnyCurrency(GameEntity entity, int value)
        {
            currency.text = $"{value} Gold";
        }

        public void OnAnyChangePlayerHp(UIEntity entity, float health, float maxHealth)
        {
            var fillValue = health / maxHealth;
            hpText.text = $"{health} / {maxHealth}";
            hpImage.fillAmount = fillValue;
        }
    }
}