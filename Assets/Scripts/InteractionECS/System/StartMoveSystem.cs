using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

namespace InteractionDemo
{
    public class StartMoveSystem : ReactiveSystem<InputEntity>
    {
        private IGroup<GameEntity> _moveGroup;

        public StartMoveSystem(Contexts context) : base(context.input)
        {
            _moveGroup = context.game.GetGroup(GameMatcher.InteractionDemoView);
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.InteractionDemoMouse);
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.hasInteractionDemoMouse
                && entity.interactionDemoMouse.mouseType == MouseType.Right
                && entity.interactionDemoMouse.mouseState == MouseState.Down;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            foreach (InputEntity entity in entities)
            {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 10;
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
                foreach (GameEntity gameEntity in _moveGroup)
                {
                    gameEntity.ReplaceInteractionDemoMove(worldPos);
                }
            }
        }
    }
    
}
