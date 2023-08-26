using UnityEngine;

namespace _Core_.Towers.Tower.Configs
{
    [CreateAssetMenu(fileName = "TowerConfig", menuName = "Configs/TowerConfig")]
    public class TowerConfig : ScriptableObject
    {
        [field: SerializeField] public TowerView TowerView { get; private set; }
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float AttackRate { get; private set; }
        [field: SerializeField] public float AttackDistance { get; private set; }
        [field: SerializeField] public int Price { get; private set; }
        [field: SerializeField] public float DamageMultiply { get; private set; }
        [field: SerializeField] public float AttackRateMultiply { get; private set; }
        [field: SerializeField] public int PricePerLevel{ get; private set; }
        [field: SerializeField] public float MinAttackRate{ get; private set; }
    }
}