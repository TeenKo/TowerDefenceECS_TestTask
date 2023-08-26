using _Core_.Enemies.Components;
using UnityEngine;

namespace _Core_.Enemies.Configs
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [field: SerializeField] public EnemyType EnemyType { get; private set; }
        [field: SerializeField] public float Health { get; private set; }
        [field: SerializeField] public float MultiplyHealthPerWave { get; private set; }
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public int Reward { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
    }
}
