//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly _Core_.Common.Components.FinishedComponent finishedComponent = new _Core_.Common.Components.FinishedComponent();

    public bool isFinished {
        get { return HasComponent(GameComponentsLookup.Finished); }
        set {
            if (value != isFinished) {
                var index = GameComponentsLookup.Finished;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : finishedComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherFinished;

    public static Entitas.IMatcher<GameEntity> Finished {
        get {
            if (_matcherFinished == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Finished);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherFinished = matcher;
            }

            return _matcherFinished;
        }
    }
}