using System.Collections.Generic;
using _Core_.States.Components;
using _Core_.Tools;
using Entitas;
using UnityEngine;

namespace _Core_.Towers.Tower
{
    public class TowerRechargeAttackTimerReactiveSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public TowerRechargeAttackTimerReactiveSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.RechargeAttackTimer.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isTower && entity.hasRechargeAttackTimer;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var time = entity.rechargeAttackTimer.value - Time.deltaTime;

                if (time <= 0)
                {
                    GameTools.TransitionGameState(entity, new IdleStateComponent(), false);
                    entity.RemoveRechargeAttackTimer();
                    continue;
                }
                
                entity.ReplaceRechargeAttackTimer(time);
            }
        }
    }
}