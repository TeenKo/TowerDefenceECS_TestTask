using Entitas;

namespace _Core_.Towers.Tower
{
    public sealed class TowerSystems : Systems
    {
        public TowerSystems(Contexts contexts)
        {
            Add(new TowerPointReactiveSystem(contexts));
            Add(new CreateTowerReactiveSystem(contexts));
            Add(new TowerIdleStateReactiveSystem(contexts));
            Add(new TowerSearchAttackTargetStateReactiveSystem(contexts));
            Add(new TowerAttackStateReactiveSystem(contexts));
            Add(new TowerRechargeAttackTimerReactiveSystem(contexts));
            Add(new TowerTryPurchaseLevelReactiveSystem(contexts));
            Add(new TowerLevelReactiveSystem(contexts));
        }
    }
}