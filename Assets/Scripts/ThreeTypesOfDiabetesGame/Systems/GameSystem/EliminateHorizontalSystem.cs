using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System.Linq;

namespace ThreeTypesOfDiabetesGame
{
    /// <summary>
    /// 消除同行颜色球的响应系统
    /// </summary>
    public class EliminateHorizontalSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;
        public EliminateHorizontalSystem(Contexts context) : base(context.game)
        {
            Debug.Log(GetType() + "/EliminateHorizontalSystem()/ Construction ==========");
            _contexts = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ThreeTypesOfDiabetesGameDestroyCommponent);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasThreeTypesOfDiabetesGameItemEffectState
                && entity.threeTypesOfDiabetesGameItemEffectState.state == ItemEffectName.ELIMINATE_HORIZONTAL;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            
            foreach (GameEntity entity in entities)
            {
                Debug.Log(GetType() + "/Execute()/ EliminateHorizontalSystem ==========");
                var gameBoard = _contexts.game.threeTypesOfDiabetesGameGameBoard;
                GameEntity[] temp;
                for (int column = 0; column < gameBoard.columns; column++) {
                    temp = _contexts.game.GetEntitiesWithThreeTypesOfDiabetesGameItemIndex(new Data.CustomVector2(column, entity.threeTypesOfDiabetesGameItemIndex.index.y))
                        .ToArray();

                    if (temp.Length==1)
                    {
                        temp[0].isThreeTypesOfDiabetesGameDestroyCommponent = true;
                    }
                }
            }
        }
    }
}
