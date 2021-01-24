using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System.Linq;

namespace ThreeTypesOfDiabetesGame
{
    /// <summary>
    /// 消除相同颜色球的响应系统
    /// </summary>
    public class EliminateSameColorSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;
        public EliminateSameColorSystem(Contexts context) : base(context.game)
        {
            Debug.Log(GetType() + "/EliminateSameColorSystem()/ Construction ==========");
            _contexts = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ThreeTypesOfDiabetesGameDestroyCommponent);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasThreeTypesOfDiabetesGameItemEffectState
                && entity.threeTypesOfDiabetesGameItemEffectState.state == ItemEffectName.ELIMINATE_SAME_COLOR;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            Debug.Log(GetType() + "/Execute()/ EliminateSameColorSystem ==========");
            foreach (GameEntity entity in entities)
            {
                Debug.Log(GetType() + "/Execute()/ EliminateSameColorSystem ==========");
                var gameBoard = _contexts.game.threeTypesOfDiabetesGameGameBoard;
                string colorName = entity.threeTypesOfDiabetesGameLoadPrefabCommponent.path;
                GameEntity temp;
                for (int column = 0; column < gameBoard.columns; column++)
                {
                    for (int row = 0; row < gameBoard.rows; row++)
                    {
                        temp = _contexts.game.GetEntitiesWithThreeTypesOfDiabetesGameItemIndex(new Data.CustomVector2(column, row))
                            .FirstOrDefault(u=>u.threeTypesOfDiabetesGameLoadPrefabCommponent.path == colorName);

                        if (temp!=null)
                        {
                            temp.isThreeTypesOfDiabetesGameDestroyCommponent = true;
                        }
                    }
                }
            }

            
        }
    }
}
