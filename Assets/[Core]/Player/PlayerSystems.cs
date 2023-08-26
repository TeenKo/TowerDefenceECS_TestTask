using Entitas;

namespace _Core_.Player
{
    public sealed class PlayerSystems : Systems
    {
        public PlayerSystems(Contexts contexts)
        {
            Add(new InitPlayerSystem(contexts));
            Add(new PlayerDeathStateReactiveSystem(contexts));
            Add(new PlayerHealthReactiveSystem(contexts));
        }
    }
}