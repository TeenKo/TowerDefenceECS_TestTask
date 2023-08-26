using Entitas;

namespace _Core_.GameManager
{
    public class InitGameManagerSystem : IInitializeSystem
    {
        private readonly Contexts _contexts;

        public InitGameManagerSystem(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Initialize()
        {
            var gameManagerEntity = _contexts.game.CreateEntity();
            gameManagerEntity.isGameManager = true;
        }
    }
}