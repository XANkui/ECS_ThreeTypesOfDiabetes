//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class GameEventSystems : Feature {

    public GameEventSystems(Contexts contexts) {
        Add(new ThreeTypesOfDiabetesGameAudioEventSystem(contexts)); // priority: 0
        Add(new ThreeTypesOfDiabetesGameDestroyCommponentEventSystem(contexts)); // priority: 0
        Add(new ThreeTypesOfDiabetesGameAnyLoadPrefabCommponentEventSystem(contexts)); // priority: 0
        Add(new ThreeTypesOfDiabetesGameLoadSpriteEventSystem(contexts)); // priority: 0
        Add(new ThreeTypesOfDiabetesGameAnyScoreEventSystem(contexts)); // priority: 0
        Add(new ThreeTypesOfDiabetesGameItemIndexEventSystem(contexts)); // priority: 1
    }
}
