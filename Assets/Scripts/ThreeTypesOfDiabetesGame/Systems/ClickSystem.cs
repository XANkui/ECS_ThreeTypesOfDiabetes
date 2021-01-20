using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using ThreeTypesOfDiabetesGame.Data;

namespace ThreeTypesOfDiabetesGame
{
    public class ClickSystem : ReactiveSystem<InputEntity>
    {
        Contexts _contexts;
        ClickComponent _lastClickComponent;
        public ClickSystem(Contexts context) : base(context.input)
        {
            _contexts = context;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.ThreeTypesOfDiabetesGameClick);
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.hasThreeTypesOfDiabetesGameClick;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            InputEntity input = entities.SingleEntity();
            var click = input.threeTypesOfDiabetesGameClick;
            var gameEntity = _contexts.game.GetEntitiesWithThreeTypesOfDiabetesGameItemIndex(new CustomVector2(click.x, click.y));

            bool canMove = false;
            if (gameEntity !=null)
            {
                canMove = gameEntity.SingleEntity().isThreeTypesOfDiabetesGameMovableCommponent;
            }

            if (canMove==true)
            {
                if (_lastClickComponent == null)
                {
                    _lastClickComponent = click;
                }
                else {
                    // 判断当前元素是都是上一个元素的上下左右四个元素之一
                    if ((click.x == _lastClickComponent.x - 1 && click.y == _lastClickComponent.y)
                        || (click.x == _lastClickComponent.x + 1 && click.y == _lastClickComponent.y)
                        || (click.x == _lastClickComponent.x && click.y == _lastClickComponent.y - 1)
                        || (click.x == _lastClickComponent.x && click.y == _lastClickComponent.y + 1)
                        )
                    {
                        Debug.Log(GetType()+ "/Execute ()/ changeItem: " + click.x + ","+click.y);
                        // ToDO : 元素交换 

                        _lastClickComponent = null;
                    }
                    
                }
            }
        }
    }
}
