//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly _Core_.EnemySpawner.Components.TrySpawnEnemyComponent trySpawnEnemyComponent = new _Core_.EnemySpawner.Components.TrySpawnEnemyComponent();

    public bool isTrySpawnEnemy {
        get { return HasComponent(GameComponentsLookup.TrySpawnEnemy); }
        set {
            if (value != isTrySpawnEnemy) {
                var index = GameComponentsLookup.TrySpawnEnemy;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : trySpawnEnemyComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherTrySpawnEnemy;

    public static Entitas.IMatcher<GameEntity> TrySpawnEnemy {
        get {
            if (_matcherTrySpawnEnemy == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TrySpawnEnemy);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTrySpawnEnemy = matcher;
            }

            return _matcherTrySpawnEnemy;
        }
    }
}