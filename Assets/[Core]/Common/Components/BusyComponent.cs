using Entitas;

namespace _Core_.Common.Components
{
    [Game]
    public sealed class BusyComponent : IComponent
    {
        public bool busy;
        public int creationIndex;
    }
}