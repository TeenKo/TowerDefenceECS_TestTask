using Entitas;

namespace _Core_.GameManager
{
    public sealed class GameManagerSystems : Systems
    {
        public GameManagerSystems(Contexts contexts)
        {
            Add(new InitGameManagerSystem(contexts));
            Add(new DefeatStateReactiveSystem(contexts));
            
            Add(new GameEventSystems(contexts));
            Add(new GameCleanupSystems(contexts));
        }
    }
}