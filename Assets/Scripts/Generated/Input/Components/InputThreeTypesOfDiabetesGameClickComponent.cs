//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity threeTypesOfDiabetesGameClickEntity { get { return GetGroup(InputMatcher.ThreeTypesOfDiabetesGameClick).GetSingleEntity(); } }
    public ThreeTypesOfDiabetesGame.ClickComponent threeTypesOfDiabetesGameClick { get { return threeTypesOfDiabetesGameClickEntity.threeTypesOfDiabetesGameClick; } }
    public bool hasThreeTypesOfDiabetesGameClick { get { return threeTypesOfDiabetesGameClickEntity != null; } }

    public InputEntity SetThreeTypesOfDiabetesGameClick(int newX, int newY) {
        if (hasThreeTypesOfDiabetesGameClick) {
            throw new Entitas.EntitasException("Could not set ThreeTypesOfDiabetesGameClick!\n" + this + " already has an entity with ThreeTypesOfDiabetesGame.ClickComponent!",
                "You should check if the context already has a threeTypesOfDiabetesGameClickEntity before setting it or use context.ReplaceThreeTypesOfDiabetesGameClick().");
        }
        var entity = CreateEntity();
        entity.AddThreeTypesOfDiabetesGameClick(newX, newY);
        return entity;
    }

    public void ReplaceThreeTypesOfDiabetesGameClick(int newX, int newY) {
        var entity = threeTypesOfDiabetesGameClickEntity;
        if (entity == null) {
            entity = SetThreeTypesOfDiabetesGameClick(newX, newY);
        } else {
            entity.ReplaceThreeTypesOfDiabetesGameClick(newX, newY);
        }
    }

    public void RemoveThreeTypesOfDiabetesGameClick() {
        threeTypesOfDiabetesGameClickEntity.Destroy();
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

    public ThreeTypesOfDiabetesGame.ClickComponent threeTypesOfDiabetesGameClick { get { return (ThreeTypesOfDiabetesGame.ClickComponent)GetComponent(InputComponentsLookup.ThreeTypesOfDiabetesGameClick); } }
    public bool hasThreeTypesOfDiabetesGameClick { get { return HasComponent(InputComponentsLookup.ThreeTypesOfDiabetesGameClick); } }

    public void AddThreeTypesOfDiabetesGameClick(int newX, int newY) {
        var index = InputComponentsLookup.ThreeTypesOfDiabetesGameClick;
        var component = (ThreeTypesOfDiabetesGame.ClickComponent)CreateComponent(index, typeof(ThreeTypesOfDiabetesGame.ClickComponent));
        component.x = newX;
        component.y = newY;
        AddComponent(index, component);
    }

    public void ReplaceThreeTypesOfDiabetesGameClick(int newX, int newY) {
        var index = InputComponentsLookup.ThreeTypesOfDiabetesGameClick;
        var component = (ThreeTypesOfDiabetesGame.ClickComponent)CreateComponent(index, typeof(ThreeTypesOfDiabetesGame.ClickComponent));
        component.x = newX;
        component.y = newY;
        ReplaceComponent(index, component);
    }

    public void RemoveThreeTypesOfDiabetesGameClick() {
        RemoveComponent(InputComponentsLookup.ThreeTypesOfDiabetesGameClick);
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

    static Entitas.IMatcher<InputEntity> _matcherThreeTypesOfDiabetesGameClick;

    public static Entitas.IMatcher<InputEntity> ThreeTypesOfDiabetesGameClick {
        get {
            if (_matcherThreeTypesOfDiabetesGameClick == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.ThreeTypesOfDiabetesGameClick);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherThreeTypesOfDiabetesGameClick = matcher;
            }

            return _matcherThreeTypesOfDiabetesGameClick;
        }
    }
}
