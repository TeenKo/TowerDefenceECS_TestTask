//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public LevelListenerComponent levelListener { get { return (LevelListenerComponent)GetComponent(GameComponentsLookup.LevelListener); } }
    public bool hasLevelListener { get { return HasComponent(GameComponentsLookup.LevelListener); } }

    public void AddLevelListener(System.Collections.Generic.List<ILevelListener> newValue) {
        var index = GameComponentsLookup.LevelListener;
        var component = (LevelListenerComponent)CreateComponent(index, typeof(LevelListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceLevelListener(System.Collections.Generic.List<ILevelListener> newValue) {
        var index = GameComponentsLookup.LevelListener;
        var component = (LevelListenerComponent)CreateComponent(index, typeof(LevelListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveLevelListener() {
        RemoveComponent(GameComponentsLookup.LevelListener);
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

    static Entitas.IMatcher<GameEntity> _matcherLevelListener;

    public static Entitas.IMatcher<GameEntity> LevelListener {
        get {
            if (_matcherLevelListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LevelListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLevelListener = matcher;
            }

            return _matcherLevelListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public void AddLevelListener(ILevelListener value) {
        var listeners = hasLevelListener
            ? levelListener.value
            : new System.Collections.Generic.List<ILevelListener>();
        listeners.Add(value);
        ReplaceLevelListener(listeners);
    }

    public void RemoveLevelListener(ILevelListener value, bool removeComponentWhenEmpty = true) {
        var listeners = levelListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveLevelListener();
        } else {
            ReplaceLevelListener(listeners);
        }
    }
}