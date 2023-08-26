using Entitas;

namespace _Core_.States.Components
{
    [Game]
    public sealed class TransitionStateComponent : IComponent
    {
        public IGameContextState value;
    }
}