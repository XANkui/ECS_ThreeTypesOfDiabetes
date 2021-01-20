//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public InteractionDemo.DirectionComponent interactionDemoDirection { get { return (InteractionDemo.DirectionComponent)GetComponent(GameComponentsLookup.InteractionDemoDirection); } }
    public bool hasInteractionDemoDirection { get { return HasComponent(GameComponentsLookup.InteractionDemoDirection); } }

    public void AddInteractionDemoDirection(float newDirection) {
        var index = GameComponentsLookup.InteractionDemoDirection;
        var component = (InteractionDemo.DirectionComponent)CreateComponent(index, typeof(InteractionDemo.DirectionComponent));
        component.direction = newDirection;
        AddComponent(index, component);
    }

    public void ReplaceInteractionDemoDirection(float newDirection) {
        var index = GameComponentsLookup.InteractionDemoDirection;
        var component = (InteractionDemo.DirectionComponent)CreateComponent(index, typeof(InteractionDemo.DirectionComponent));
        component.direction = newDirection;
        ReplaceComponent(index, component);
    }

    public void RemoveInteractionDemoDirection() {
        RemoveComponent(GameComponentsLookup.InteractionDemoDirection);
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

    static Entitas.IMatcher<GameEntity> _matcherInteractionDemoDirection;

    public static Entitas.IMatcher<GameEntity> InteractionDemoDirection {
        get {
            if (_matcherInteractionDemoDirection == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.InteractionDemoDirection);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherInteractionDemoDirection = matcher;
            }

            return _matcherInteractionDemoDirection;
        }
    }
}
