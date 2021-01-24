//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity threeTypesOfDiabetesGameScoreEntity { get { return GetGroup(GameMatcher.ThreeTypesOfDiabetesGameScore).GetSingleEntity(); } }
    public ThreeTypesOfDiabetesGame.Score threeTypesOfDiabetesGameScore { get { return threeTypesOfDiabetesGameScoreEntity.threeTypesOfDiabetesGameScore; } }
    public bool hasThreeTypesOfDiabetesGameScore { get { return threeTypesOfDiabetesGameScoreEntity != null; } }

    public GameEntity SetThreeTypesOfDiabetesGameScore(int newScore) {
        if (hasThreeTypesOfDiabetesGameScore) {
            throw new Entitas.EntitasException("Could not set ThreeTypesOfDiabetesGameScore!\n" + this + " already has an entity with ThreeTypesOfDiabetesGame.Score!",
                "You should check if the context already has a threeTypesOfDiabetesGameScoreEntity before setting it or use context.ReplaceThreeTypesOfDiabetesGameScore().");
        }
        var entity = CreateEntity();
        entity.AddThreeTypesOfDiabetesGameScore(newScore);
        return entity;
    }

    public void ReplaceThreeTypesOfDiabetesGameScore(int newScore) {
        var entity = threeTypesOfDiabetesGameScoreEntity;
        if (entity == null) {
            entity = SetThreeTypesOfDiabetesGameScore(newScore);
        } else {
            entity.ReplaceThreeTypesOfDiabetesGameScore(newScore);
        }
    }

    public void RemoveThreeTypesOfDiabetesGameScore() {
        threeTypesOfDiabetesGameScoreEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ThreeTypesOfDiabetesGame.Score threeTypesOfDiabetesGameScore { get { return (ThreeTypesOfDiabetesGame.Score)GetComponent(GameComponentsLookup.ThreeTypesOfDiabetesGameScore); } }
    public bool hasThreeTypesOfDiabetesGameScore { get { return HasComponent(GameComponentsLookup.ThreeTypesOfDiabetesGameScore); } }

    public void AddThreeTypesOfDiabetesGameScore(int newScore) {
        var index = GameComponentsLookup.ThreeTypesOfDiabetesGameScore;
        var component = (ThreeTypesOfDiabetesGame.Score)CreateComponent(index, typeof(ThreeTypesOfDiabetesGame.Score));
        component.score = newScore;
        AddComponent(index, component);
    }

    public void ReplaceThreeTypesOfDiabetesGameScore(int newScore) {
        var index = GameComponentsLookup.ThreeTypesOfDiabetesGameScore;
        var component = (ThreeTypesOfDiabetesGame.Score)CreateComponent(index, typeof(ThreeTypesOfDiabetesGame.Score));
        component.score = newScore;
        ReplaceComponent(index, component);
    }

    public void RemoveThreeTypesOfDiabetesGameScore() {
        RemoveComponent(GameComponentsLookup.ThreeTypesOfDiabetesGameScore);
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

    static Entitas.IMatcher<GameEntity> _matcherThreeTypesOfDiabetesGameScore;

    public static Entitas.IMatcher<GameEntity> ThreeTypesOfDiabetesGameScore {
        get {
            if (_matcherThreeTypesOfDiabetesGameScore == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ThreeTypesOfDiabetesGameScore);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherThreeTypesOfDiabetesGameScore = matcher;
            }

            return _matcherThreeTypesOfDiabetesGameScore;
        }
    }
}