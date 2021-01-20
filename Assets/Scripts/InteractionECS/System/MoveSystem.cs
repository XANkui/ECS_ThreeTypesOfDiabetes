using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using DG.Tweening;

namespace InteractionDemo
{
    public class MoveSystem : ReactiveSystem<GameEntity>
    {
        public MoveSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.InteractionDemoMove);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasInteractionDemoMove
                && entity.isInteractionDemoMoveComplete
                && entity.hasInteractionDemoView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                entity.interactionDemoView.viewTrans.DOMove(entity.interactionDemoMove.targetPos, 3);
            }
        }
    }
}
