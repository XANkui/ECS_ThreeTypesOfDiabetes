//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity interactionDemoMouseEntity { get { return GetGroup(InputMatcher.InteractionDemoMouse).GetSingleEntity(); } }
    public InteractionDemo.MouseComponent interactionDemoMouse { get { return interactionDemoMouseEntity.interactionDemoMouse; } }
    public bool hasInteractionDemoMouse { get { return interactionDemoMouseEntity != null; } }

    public InputEntity SetInteractionDemoMouse(MouseType newMouseType, MouseState newMouseState) {
        if (hasInteractionDemoMouse) {
            throw new Entitas.EntitasException("Could not set InteractionDemoMouse!\n" + this + " already has an entity with InteractionDemo.MouseComponent!",
                "You should check if the context already has a interactionDemoMouseEntity before setting it or use context.ReplaceInteractionDemoMouse().");
        }
        var entity = CreateEntity();
        entity.AddInteractionDemoMouse(newMouseType, newMouseState);
        return entity;
    }

    public void ReplaceInteractionDemoMouse(MouseType newMouseType, MouseState newMouseState) {
        var entity = interactionDemoMouseEntity;
        if (entity == null) {
            entity = SetInteractionDemoMouse(newMouseType, newMouseState);
        } else {
            entity.ReplaceInteractionDemoMouse(newMouseType, newMouseState);
        }
    }

    public void RemoveInteractionDemoMouse() {
        interactionDemoMouseEntity.Destroy();
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
public partial class InputEntity {

    public InteractionDemo.MouseComponent interactionDemoMouse { get { return (InteractionDemo.MouseComponent)GetComponent(InputComponentsLookup.InteractionDemoMouse); } }
    public bool hasInteractionDemoMouse { get { return HasComponent(InputComponentsLookup.InteractionDemoMouse); } }

    public void AddInteractionDemoMouse(MouseType newMouseType, MouseState newMouseState) {
        var index = InputComponentsLookup.InteractionDemoMouse;
        var component = (InteractionDemo.MouseComponent)CreateComponent(index, typeof(InteractionDemo.MouseComponent));
        component.mouseType = newMouseType;
        component.mouseState = newMouseState;
        AddComponent(index, component);
    }

    public void ReplaceInteractionDemoMouse(MouseType newMouseType, MouseState newMouseState) {
        var index = InputComponentsLookup.InteractionDemoMouse;
        var component = (InteractionDemo.MouseComponent)CreateComponent(index, typeof(InteractionDemo.MouseComponent));
        component.mouseType = newMouseType;
        component.mouseState = newMouseState;
        ReplaceComponent(index, component);
    }

    public void RemoveInteractionDemoMouse() {
        RemoveComponent(InputComponentsLookup.InteractionDemoMouse);
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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherInteractionDemoMouse;

    public static Entitas.IMatcher<InputEntity> InteractionDemoMouse {
        get {
            if (_matcherInteractionDemoMouse == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.InteractionDemoMouse);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherInteractionDemoMouse = matcher;
            }

            return _matcherInteractionDemoMouse;
        }
    }
}