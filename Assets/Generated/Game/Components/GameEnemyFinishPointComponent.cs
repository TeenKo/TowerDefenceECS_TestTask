//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public _Core_.Level.Components.EnemyFinishPointComponent enemyFinishPoint { get { return (_Core_.Level.Components.EnemyFinishPointComponent)GetComponent(GameComponentsLookup.EnemyFinishPoint); } }
    public bool hasEnemyFinishPoint { get { return HasComponent(GameComponentsLookup.EnemyFinishPoint); } }

    public void AddEnemyFinishPoint(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.EnemyFinishPoint;
        var component = (_Core_.Level.Components.EnemyFinishPointComponent)CreateComponent(index, typeof(_Core_.Level.Components.EnemyFinishPointComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceEnemyFinishPoint(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.EnemyFinishPoint;
        var component = (_Core_.Level.Components.EnemyFinishPointComponent)CreateComponent(index, typeof(_Core_.Level.Components.EnemyFinishPointComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveEnemyFinishPoint() {
        RemoveComponent(GameComponentsLookup.EnemyFinishPoint);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherEnemyFinishPoint;

    public static Entitas.IMatcher<GameEntity> EnemyFinishPoint {
        get {
            if (_matcherEnemyFinishPoint == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.EnemyFinishPoint);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherEnemyFinishPoint = matcher;
            }

            return _matcherEnemyFinishPoint;
        }
    }
}