using _Core_.LevelCore.Configs;
using Entitas;
using UnityEngine;

namespace _Core_.Level
{
    public class InitLevelSystem : IInitializeSystem
    {
        private readonly Contexts _contexts;
        private readonly LevelConfig _levelConfig;

        public InitLevelSystem(Contexts contexts)
        {
            _contexts = contexts;
            _levelConfig = LevelConfig.Instance;
        }

        public void Initialize()
        {
            var levelView = Object.Instantiate(_levelConfig.LevelView);
            var levelEntity = _contexts.game.CreateEntity();
            levelView.Link(levelEntity);
        }
    }
}