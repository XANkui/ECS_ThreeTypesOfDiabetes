using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using ThreeTypesOfDiabetesGame.Data;

namespace ThreeTypesOfDiabetesGame
{
    public class SlideSystem : ReactiveSystem<InputEntity>
    {
        Contexts _context;
        public SlideSystem(Contexts context) : base(context.input)
        {
            _context = context;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.ThreeTypesOfDiabetesGameSlide);
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.hasThreeTypesOfDiabetesGameSlide;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            if (entities.Count==1)
            {

                InputEntity entity = entities.SingleEntity();
                CustomVector2 pos = new CustomVector2(entity.threeTypesOfDiabetesGameSlide.clickPos.x, entity.threeTypesOfDiabetesGameSlide.clickPos.y);
                bool canMove = _context.game.GetEntitiesWithThreeTypesOfDiabetesGameItemIndex(pos).SingleEntity().isThreeTypesOfDiabetesGameMovableCommponent;

                if (canMove)
                {
                    var nextPos = NextPos(entity);
                    _context.input.ReplaceThreeTypesOfDiabetesGameClick(nextPos.x, nextPos.y);
                }
            }
        }

        private CustomVector2 NextPos(InputEntity entity) {
            int x = entity.threeTypesOfDiabetesGameSlide.clickPos.x;
            int y = entity.threeTypesOfDiabetesGameSlide.clickPos.y;

            switch (entity.threeTypesOfDiabetesGameSlide.direction)
            {
                case SlideDirection.LEFT:
                    x--;
                    break;
                case SlideDirection.RIGHT:
                    x++;
                    break;
                case SlideDirection.UP:
                    y--;
                    break;
                case SlideDirection.DOWN:
                    y++;
                    break;
                
            }
            x = LimitValue(x,0, _context.game.threeTypesOfDiabetesGameGameBoard.columns-1);
            y = LimitValue(y,0, _context.game.threeTypesOfDiabetesGameGameBoard.rows-1);
            return new CustomVector2(x, y);
        }

        private int LimitValue(int value, int min, int max) {
            if (value<min)
            {
                value = min;
            }
            else if (value>max)
            {
                value = max;
            }

            return value;
        }
    }
}
