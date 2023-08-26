//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public _Core_.EnemySpawner.Components.TimeBeforeFirstSpawnComponent timeBeforeFirstSpawn { get { return (_Core_.EnemySpawner.Components.TimeBeforeFirstSpawnComponent)GetComponent(GameComponentsLookup.TimeBeforeFirstSpawn); } }
    public bool hasTimeBeforeFirstSpawn { get { return HasComponent(GameComponentsLookup.TimeBeforeFirstSpawn); } }

    public void AddTimeBeforeFirstSpawn(float newValue) {
        var index = GameComponentsLookup.TimeBeforeFirstSpawn;
        var component = (_Core_.EnemySpawner.Components.TimeBeforeFirstSpawnComponent)CreateComponent(index, typeof(_Core_.EnemySpawner.Components.TimeBeforeFirstSpawnComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceTimeBeforeFirstSpawn(float newValue) {
        var index = GameComponentsLookup.TimeBeforeFirstSpawn;
        var component = (_Core_.EnemySpawner.Components.TimeBeforeFirstSpawnComponent)CreateComponent(index, typeof(_Core_.EnemySpawner.Components.TimeBeforeFirstSpawnComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveTimeBeforeFirstSpawn() {
        RemoveComponent(GameComponentsLookup.TimeBeforeFirstSpawn);
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

    static Entitas.IMatcher<GameEntity> _matcherTimeBeforeFirstSpawn;

    public static Entitas.IMatcher<GameEntity> TimeBeforeFirstSpawn {
        get {
            if (_matcherTimeBeforeFirstSpawn == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TimeBeforeFirstSpawn);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTimeBeforeFirstSpawn = matcher;
            }

            return _matcherTimeBeforeFirstSpawn;
        }
    }
}