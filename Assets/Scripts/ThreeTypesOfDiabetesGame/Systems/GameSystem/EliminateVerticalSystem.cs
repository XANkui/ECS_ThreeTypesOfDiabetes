using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System.Linq;

namespace ThreeTypesOfDiabetesGame
{
    /// <summary>
    /// 消除同列颜色球的响应系统
    /// </summary>
    public class EliminateVerticalSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;
        public EliminateVerticalSystem(Contexts context) : base(context.game)
        {
            _contexts = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ThreeTypesOfDiabetesGameDestroyCommponent);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasThreeTypesOfDiabetesGameItemEffectState
                && entity.threeTypesOfDiabetesGameItemEffectState.state == ItemEffectName.ELIMINATE_VERTICAL;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                var gameBoard = _contexts.game.threeTypesOfDiabetesGameGameBoard;
                GameEntity[] temp;
                for (int row = 0; row < gameBoard.rows; row++)
                {
                    temp = _contexts.game.GetEntitiesWithThreeTypesOfDiabetesGameItemIndex(new Data.CustomVector2(entity.threeTypesOfDiabetesGameItemIndex.index.x,row))
                        .ToArray();

                    if (temp.Length == 1)
                    {
                        temp[0].isThreeTypesOfDiabetesGameDestroyCommponent = true;
                    }
                }
            }
        }
    }
}
