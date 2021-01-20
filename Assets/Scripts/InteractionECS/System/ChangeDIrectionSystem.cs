using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

namespace InteractionDemo
{
    public class ChangeDIrectionSystem : ReactiveSystem<GameEntity>
    {
        public ChangeDIrectionSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.InteractionDemoDirection);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasInteractionDemoDirection
                && entity.hasInteractionDemoView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                Transform view = entity.interactionDemoView.viewTrans;
                float angle = entity.interactionDemoDirection.direction;
                // 根据自己的图片朝向修正 angle 的值
                view.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            }
        }
    }
}
