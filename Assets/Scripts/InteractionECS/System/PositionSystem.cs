using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

namespace InteractionDemo
{
    public class PositionSystem : ReactiveSystem<GameEntity>
    {
        public PositionSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.InteractionDemoPosition);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasInteractionDemoPosition && entity.hasInteractionDemoView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                entity.interactionDemoView.viewTrans.position = entity.interactionDemoPosition.position;
            }
        }
    }
}
