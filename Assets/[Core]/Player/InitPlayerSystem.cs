using _Core_.LevelCore.Configs;
using _Core_.Player.Configs;
using _Core_.States;
using Entitas;

namespace _Core_.Player
{
    public class InitPlayerSystem : IInitializeSystem
    {
        private readonly Contexts _contexts;
        private readonly PlayerConfig _playerConfig;

        public InitPlayerSystem(Contexts contexts)
        {
            _contexts = contexts;
            _playerConfig = LevelConfig.Instance.PlayerConfig;
        }

        public void Initialize()
        {
            
            var playerEntity = _contexts.game.CreateEntity();
            playerEntity.isPlayer = true;
            playerEntity.AddEntityCreationIndex(playerEntity.creationIndex);
            playerEntity.AddHealth(_playerConfig.Health);
            playerEntity.AddMaxHealth(_playerConfig.Health);
            playerEntity.AddCurrency(_playerConfig.StartCurrency);
            playerEntity.AddStateObjectType(StateObjectType.Player);
            playerEntity.AddTotalDeathEnemy(0);
        }
    }
}