using Entitas;

namespace _Core_.Enemies
{
    public sealed class EnemySystems : Systems
    {
        public EnemySystems(Contexts contexts)
        {
            Add(new EnemySpawnReactiveSystem(contexts));
            Add(new EnemyCreatedReactiveSystem(contexts));
            Add(new EnemyIdleStateReactiveSystem(contexts));
            Add(new EnemyFinishedReactiveSystem(contexts));
            Add(new EnemyDeathStateReactiveSystem(contexts));
        }
    }
}