//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ThreeTypesOfDiabetesGame.LoadPrefabCommponent threeTypesOfDiabetesGameLoadPrefabCommponent { get { return (ThreeTypesOfDiabetesGame.LoadPrefabCommponent)GetComponent(GameComponentsLookup.ThreeTypesOfDiabetesGameLoadPrefabCommponent); } }
    public bool hasThreeTypesOfDiabetesGameLoadPrefabCommponent { get { return HasComponent(GameComponentsLookup.ThreeTypesOfDiabetesGameLoadPrefabCommponent); } }

    public void AddThreeTypesOfDiabetesGameLoadPrefabCommponent(string newPath) {
        var index = GameComponentsLookup.ThreeTypesOfDiabetesGameLoadPrefabCommponent;
        var component = (ThreeTypesOfDiabetesGame.LoadPrefabCommponent)CreateComponent(index, typeof(ThreeTypesOfDiabetesGame.LoadPrefabCommponent));
        component.path = newPath;
        AddComponent(index, component);
    }

    public void ReplaceThreeTypesOfDiabetesGameLoadPrefabCommponent(string newPath) {
        var index = GameComponentsLookup.ThreeTypesOfDiabetesGameLoadPrefabCommponent;
        var component = (ThreeTypesOfDiabetesGame.LoadPrefabCommponent)CreateComponent(index, typeof(ThreeTypesOfDiabetesGame.LoadPrefabCommponent));
        component.path = newPath;
        ReplaceComponent(index, component);
    }

    public void RemoveThreeTypesOfDiabetesGameLoadPrefabCommponent() {
        RemoveComponent(GameComponentsLookup.ThreeTypesOfDiabetesGameLoadPrefabCommponent);
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

    static Entitas.IMatcher<GameEntity> _matcherThreeTypesOfDiabetesGameLoadPrefabCommponent;

    public static Entitas.IMatcher<GameEntity> ThreeTypesOfDiabetesGameLoadPrefabCommponent {
        get {
            if (_matcherThreeTypesOfDiabetesGameLoadPrefabCommponent == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ThreeTypesOfDiabetesGameLoadPrefabCommponent);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherThreeTypesOfDiabetesGameLoadPrefabCommponent = matcher;
            }

            return _matcherThreeTypesOfDiabetesGameLoadPrefabCommponent;
        }
    }
}