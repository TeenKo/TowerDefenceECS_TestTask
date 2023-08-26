using _Core_.Common;
using _Core_.EnemySpawner.Configs;
using _Core_.Level;
using _Core_.Player.Configs;
using _Core_.Towers.Tower.Configs;
using _Core_.WaveManager.Configs;
using UnityEngine;

namespace _Core_.LevelCore.Configs
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/LevelConfig")]
    public class LevelConfig : SingletonScriptableObject<LevelConfig>
    {
        [field: SerializeField]  public LevelView LevelView { get; private set; }
        [field: SerializeField] public WaveConfig WaveConfig { get; private set; }
        [field: SerializeField] public EnemySpawnerConfig EnemySpawnerConfig { get; private set; }
        [field: SerializeField] public PlayerConfig PlayerConfig { get; private set; }
        [field: SerializeField] public TowerConfig TowerConfig { get; private set; }
    }
}
