//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class ThreeTypesOfDiabetesGameLoadSpriteEventSystem : Entitas.ReactiveSystem<GameEntity> {

    readonly System.Collections.Generic.List<IThreeTypesOfDiabetesGameLoadSpriteListener> _listenerBuffer;

    public ThreeTypesOfDiabetesGameLoadSpriteEventSystem(Contexts contexts) : base(contexts.game) {
        _listenerBuffer = new System.Collections.Generic.List<IThreeTypesOfDiabetesGameLoadSpriteListener>();
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.ThreeTypesOfDiabetesGameLoadSprite)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasThreeTypesOfDiabetesGameLoadSprite && entity.hasThreeTypesOfDiabetesGameLoadSpriteListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.threeTypesOfDiabetesGameLoadSprite;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.threeTypesOfDiabetesGameLoadSpriteListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnThreeTypesOfDiabetesGameLoadSprite(e, component.name);
            }
        }
    }
}
