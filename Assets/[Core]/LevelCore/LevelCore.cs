using _Core_.GameManager;
using _Core_.LevelCore.Configs;
using UnityEngine;

namespace _Core_.LevelCore
{
    public class LevelCore : MonoBehaviour, IAnyDefeatStateListener
    {
        [SerializeField] private LevelConfig levelConfig;

        private Contexts _contexts;
        private LevelCoreSystems _levelCoreSystems;
        private GameManagerSystems _gameManagerSystems;
        private bool _defeatGame;

        private void Awake()
        {
            _defeatGame = false;
            LevelConfig.Instance = levelConfig;
            _contexts = Contexts.sharedInstance;

            _gameManagerSystems = new GameManagerSystems(_contexts);
            _levelCoreSystems = new LevelCoreSystems(_contexts);

            _contexts.game.CreateEntity().AddAnyDefeatStateListener(this);
        }

        private void Start()
        {
            _gameManagerSystems.Initialize();
            _levelCoreSystems.Initialize();
        }

        private void Update()
        {
            _gameManagerSystems.Execute();
            _gameManagerSystems.Cleanup();

            if (_defeatGame) return;
            _levelCoreSystems.Execute();
            _levelCoreSystems.Cleanup();
        }

        public void OnAnyDefeatState(GameEntity entity)
        {
            _defeatGame = true;
            _levelCoreSystems.DeactivateReactiveSystems();
        }
    }
}