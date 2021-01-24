//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ThreeTypesOfDiabetesGame.DetectionSameItem threeTypesOfDiabetesGameDetectionSameItem { get { return (ThreeTypesOfDiabetesGame.DetectionSameItem)GetComponent(GameComponentsLookup.ThreeTypesOfDiabetesGameDetectionSameItem); } }
    public bool hasThreeTypesOfDiabetesGameDetectionSameItem { get { return HasComponent(GameComponentsLookup.ThreeTypesOfDiabetesGameDetectionSameItem); } }

    public void AddThreeTypesOfDiabetesGameDetectionSameItem(System.Collections.Generic.List<Entitas.IEntity> new_leftEntities, System.Collections.Generic.List<Entitas.IEntity> new_rightEntities, System.Collections.Generic.List<Entitas.IEntity> new_upEntities, System.Collections.Generic.List<Entitas.IEntity> new_downEntities) {
        var index = GameComponentsLookup.ThreeTypesOfDiabetesGameDetectionSameItem;
        var component = (ThreeTypesOfDiabetesGame.DetectionSameItem)CreateComponent(index, typeof(ThreeTypesOfDiabetesGame.DetectionSameItem));
        component._leftEntities = new_leftEntities;
        component._rightEntities = new_rightEntities;
        component._upEntities = new_upEntities;
        component._downEntities = new_downEntities;
        AddComponent(index, component);
    }

    public void ReplaceThreeTypesOfDiabetesGameDetectionSameItem(System.Collections.Generic.List<Entitas.IEntity> new_leftEntities, System.Collections.Generic.List<Entitas.IEntity> new_rightEntities, System.Collections.Generic.List<Entitas.IEntity> new_upEntities, System.Collections.Generic.List<Entitas.IEntity> new_downEntities) {
        var index = GameComponentsLookup.ThreeTypesOfDiabetesGameDetectionSameItem;
        var component = (ThreeTypesOfDiabetesGame.DetectionSameItem)CreateComponent(index, typeof(ThreeTypesOfDiabetesGame.DetectionSameItem));
        component._leftEntities = new_leftEntities;
        component._rightEntities = new_rightEntities;
        component._upEntities = new_upEntities;
        component._downEntities = new_downEntities;
        ReplaceComponent(index, component);
    }

    public void RemoveThreeTypesOfDiabetesGameDetectionSameItem() {
        RemoveComponent(GameComponentsLookup.ThreeTypesOfDiabetesGameDetectionSameItem);
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

    static Entitas.IMatcher<GameEntity> _matcherThreeTypesOfDiabetesGameDetectionSameItem;

    public static Entitas.IMatcher<GameEntity> ThreeTypesOfDiabetesGameDetectionSameItem {
        get {
            if (_matcherThreeTypesOfDiabetesGameDetectionSameItem == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ThreeTypesOfDiabetesGameDetectionSameItem);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherThreeTypesOfDiabetesGameDetectionSameItem = matcher;
            }

            return _matcherThreeTypesOfDiabetesGameDetectionSameItem;
        }
    }
}