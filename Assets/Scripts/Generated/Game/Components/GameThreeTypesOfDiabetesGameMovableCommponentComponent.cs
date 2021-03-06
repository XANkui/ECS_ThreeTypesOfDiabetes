//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly ThreeTypesOfDiabetesGame.MovableCommponent threeTypesOfDiabetesGameMovableCommponentComponent = new ThreeTypesOfDiabetesGame.MovableCommponent();

    public bool isThreeTypesOfDiabetesGameMovableCommponent {
        get { return HasComponent(GameComponentsLookup.ThreeTypesOfDiabetesGameMovableCommponent); }
        set {
            if (value != isThreeTypesOfDiabetesGameMovableCommponent) {
                var index = GameComponentsLookup.ThreeTypesOfDiabetesGameMovableCommponent;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : threeTypesOfDiabetesGameMovableCommponentComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherThreeTypesOfDiabetesGameMovableCommponent;

    public static Entitas.IMatcher<GameEntity> ThreeTypesOfDiabetesGameMovableCommponent {
        get {
            if (_matcherThreeTypesOfDiabetesGameMovableCommponent == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ThreeTypesOfDiabetesGameMovableCommponent);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherThreeTypesOfDiabetesGameMovableCommponent = matcher;
            }

            return _matcherThreeTypesOfDiabetesGameMovableCommponent;
        }
    }
}
