//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public InteractionDemo.ViewComponent interactionDemoView { get { return (InteractionDemo.ViewComponent)GetComponent(GameComponentsLookup.InteractionDemoView); } }
    public bool hasInteractionDemoView { get { return HasComponent(GameComponentsLookup.InteractionDemoView); } }

    public void AddInteractionDemoView(UnityEngine.Transform newViewTrans) {
        var index = GameComponentsLookup.InteractionDemoView;
        var component = (InteractionDemo.ViewComponent)CreateComponent(index, typeof(InteractionDemo.ViewComponent));
        component.viewTrans = newViewTrans;
        AddComponent(index, component);
    }

    public void ReplaceInteractionDemoView(UnityEngine.Transform newViewTrans) {
        var index = GameComponentsLookup.InteractionDemoView;
        var component = (InteractionDemo.ViewComponent)CreateComponent(index, typeof(InteractionDemo.ViewComponent));
        component.viewTrans = newViewTrans;
        ReplaceComponent(index, component);
    }

    public void RemoveInteractionDemoView() {
        RemoveComponent(GameComponentsLookup.InteractionDemoView);
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

    static Entitas.IMatcher<GameEntity> _matcherInteractionDemoView;

    public static Entitas.IMatcher<GameEntity> InteractionDemoView {
        get {
            if (_matcherInteractionDemoView == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.InteractionDemoView);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherInteractionDemoView = matcher;
            }

            return _matcherInteractionDemoView;
        }
    }
}