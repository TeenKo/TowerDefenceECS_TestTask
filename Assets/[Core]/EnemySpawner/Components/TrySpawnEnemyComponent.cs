using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _Core_.EnemySpawner.Components
{
    [Game, Cleanup(CleanupMode.DestroyEntity)]
    public class TrySpawnEnemyComponent : IComponent
    {
        
    }
}