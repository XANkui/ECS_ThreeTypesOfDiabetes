using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

namespace InteractionDemo
{

    public class CreatorSystem : ReactiveSystem<InputEntity>
    {
        private GameContext _gameContext;
        public CreatorSystem(Contexts context) : base(context.input)
        {
            Debug.Log(GetType() + "/CreatorSystem()/ construct func");
            _gameContext = context.game;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.InteractionDemoMouse);
        }

        /// <summary>
        /// 下面 Execute 执行的条件
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected override bool Filter(InputEntity entity)
        {
            return entity.hasInteractionDemoMouse
                && entity.interactionDemoMouse.mouseType == MouseType.Left
                && entity.interactionDemoMouse.mouseState == MouseState.Down;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            foreach (InputEntity entity in entities)
            {
                var gameEntity =  _gameContext.CreateEntity();
                gameEntity.AddInteractionDemoSprite("SpritesXAN/rightArrow");
                Vector3 mousePos = Input.mousePosition;
                Debug.Log("x = " + mousePos.x + ", y = " + mousePos.y + ", z = " + mousePos.z);
                mousePos.z = 10;
                Debug.Log(GetType()+"/Camera.main.ScreenToWorldPoint(Input.mousePosition):"+Camera.main.ScreenToWorldPoint(mousePos));
                gameEntity.AddInteractionDemoPosition(Camera.main.ScreenToWorldPoint(mousePos));
            }
        } 
    }
}
