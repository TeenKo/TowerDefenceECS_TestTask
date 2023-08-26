//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public _Core_.Towers.Tower.Components.CreateTowerComponent createTower { get { return (_Core_.Towers.Tower.Components.CreateTowerComponent)GetComponent(GameComponentsLookup.CreateTower); } }
    public bool hasCreateTower { get { return HasComponent(GameComponentsLookup.CreateTower); } }

    public void AddCreateTower(UnityEngine.Vector3 newPosition, int newPointCreationIndex) {
        var index = GameComponentsLookup.CreateTower;
        var component = (_Core_.Towers.Tower.Components.CreateTowerComponent)CreateComponent(index, typeof(_Core_.Towers.Tower.Components.CreateTowerComponent));
        component.position = newPosition;
        component.pointCreationIndex = newPointCreationIndex;
        AddComponent(index, component);
    }

    public void ReplaceCreateTower(UnityEngine.Vector3 newPosition, int newPointCreationIndex) {
        var index = GameComponentsLookup.CreateTower;
        var component = (_Core_.Towers.Tower.Components.CreateTowerComponent)CreateComponent(index, typeof(_Core_.Towers.Tower.Components.CreateTowerComponent));
        component.position = newPosition;
        component.pointCreationIndex = newPointCreationIndex;
        ReplaceComponent(index, component);
    }

    public void RemoveCreateTower() {
        RemoveComponent(GameComponentsLookup.CreateTower);
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

    static Entitas.IMatcher<GameEntity> _matcherCreateTower;

    public static Entitas.IMatcher<GameEntity> CreateTower {
        get {
            if (_matcherCreateTower == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CreateTower);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCreateTower = matcher;
            }

            return _matcherCreateTower;
        }
    }
}