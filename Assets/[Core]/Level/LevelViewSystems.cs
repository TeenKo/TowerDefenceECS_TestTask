using Entitas;

namespace _Core_.Level
{
    public sealed class LevelViewSystems : Systems
    {
        public LevelViewSystems(Contexts contexts)
        {
            Add(new InitLevelSystem(contexts));
        }
    }
}