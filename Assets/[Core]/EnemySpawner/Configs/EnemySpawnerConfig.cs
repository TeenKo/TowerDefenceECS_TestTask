using UnityEngine;

namespace _Core_.EnemySpawner.Configs
{
    [CreateAssetMenu(fileName = "EnemySpawnerConfig", menuName = "Configs/EnemySpawnerConfig")]
    public class EnemySpawnerConfig : ScriptableObject
    {
        [field: SerializeField] public float EnemySpawnTick { get; private set; }
        [field: SerializeField] public float EnemySpawnDelay { get; private set; }
        [field: SerializeField] public float TimeBeforeSpawn { get; private set; }
    }
}
