using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Core_.UI
{
    public class DefeatScreen : MonoBehaviour, IAnyTotalDeathEnemyListener, IAnyDefeatStateListener
    {
        [SerializeField] private TextMeshProUGUI enemiesCountText;
        private void Awake()
        {
            gameObject.SetActive(false);
            var gameEntity = Contexts.sharedInstance.game.CreateEntity();
            gameEntity.AddAnyDefeatStateListener(this);
            gameEntity.AddAnyTotalDeathEnemyListener(this);
        }

        public void OnAnyTotalDeathEnemy(GameEntity entity, int value)
        {
            enemiesCountText.text = $"You killed {value} enemies";
        }

        public void OnAnyDefeatState(GameEntity entity)
        {
            gameObject.SetActive(true);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene("Level");
            Contexts.sharedInstance.game.Reset();
        }
    }
}