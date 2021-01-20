using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

namespace InteractionDemo
{
    public class DirectionSystem : ReactiveSystem<GameEntity>
    {
        public DirectionSystem(Contexts context) : base(context.game)
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
                #region 获得方向和旋转方向两方法合用
                //Transform view = entity.interactionDemoView.viewTrans;
                //Vector3 targetPos = entity.interactionDemoMove.targetPos;
                //Vector3 dir = (targetPos - view.position).normalized;
                //Quaternion angleOffset = Quaternion.FromToRotation(view.right, dir);
                //view.rotation *= angleOffset;
                #endregion

                #region 获得方向和旋转方向两方法拆分，使用 ChangeDirectionSystem 改变方向
                Transform view = entity.interactionDemoView.viewTrans;
                Vector3 targetPos = entity.interactionDemoMove.targetPos;
                Vector3 dir = (targetPos - view.position).normalized;
                float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
                entity.ReplaceInteractionDemoDirection(angle);
                #endregion
            }
        }
    }
}
