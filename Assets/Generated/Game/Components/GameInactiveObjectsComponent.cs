//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public _Core_.ObjectPool.Components.InactiveObjectsComponent inactiveObjects { get { return (_Core_.ObjectPool.Components.InactiveObjectsComponent)GetComponent(GameComponentsLookup.InactiveObjects); } }
    public bool hasInactiveObjects { get { return HasComponent(GameComponentsLookup.InactiveObjects); } }

    public void AddInactiveObjects(int newValue) {
        var index = GameComponentsLookup.InactiveObjects;
        var component = (_Core_.ObjectPool.Components.InactiveObjectsComponent)CreateComponent(index, typeof(_Core_.ObjectPool.Components.InactiveObjectsComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceInactiveObjects(int newValue) {
        var index = GameComponentsLookup.InactiveObjects;
        var component = (_Core_.ObjectPool.Components.InactiveObjectsComponent)CreateComponent(index, typeof(_Core_.ObjectPool.Components.InactiveObjectsComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveInactiveObjects() {
        RemoveComponent(GameComponentsLookup.InactiveObjects);
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

    static Entitas.IMatcher<GameEntity> _matcherInactiveObjects;

    public static Entitas.IMatcher<GameEntity> InactiveObjects {
        get {
            if (_matcherInactiveObjects == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.InactiveObjects);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherInactiveObjects = matcher;
            }

            return _matcherInactiveObjects;
        }
    }
}