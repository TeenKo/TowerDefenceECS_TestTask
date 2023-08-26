using _Core_.Enemies.Configs;
using UnityEngine;

namespace _Core_.WaveManager.Configs
{
    [CreateAssetMenu(fileName = "WaveConfig", menuName = "Configs/WaveConfig")]
    public class WaveConfig : ScriptableObject
    {
        [field: SerializeField] public int MaxMonstersInLevel { get; private set; }
        [field: SerializeField] public EnemyConfig[] EnemyConfigs { get; private set; }
        
        // [Header("Added Health perWave")] 
        // public float healthPerWave;
        // public float healthPerCycle;
        //
        // [Header("Added Experience perWave")]
        // public float experiencePerWave;
    }
}
