using _Core_.NavMesh.Interfaces;
using Entitas;

namespace _Core_.NavMesh.Components
{
    [Game]
    public class PathfinderAgentComponent : IComponent
    {
        public IPathfinderAgent value;
    }
}