using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using ThreeTypesOfDiabetesGame.Data;
using System.Linq;

namespace ThreeTypesOfDiabetesGame
{
    /// <summary>
    /// 原有球下落的响应系统
    /// </summary>
    public class FallSystem : ReactiveSystem<GameEntity>
    {
        Contexts _contexts;
        public FallSystem(Contexts context) : base(context.game)
        {
            _contexts = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            // 筛选消除的 Item 
            return context.CreateCollector(GameMatcher.ThreeTypesOfDiabetesGameGameBoardItem.Removed());
        }

        protected override bool Filter(GameEntity entity)
        {
            // 判断是消除了的 Item 球
            return !entity.isThreeTypesOfDiabetesGameGameBoardItem;
        }

        protected override void Execute(List<GameEntity> entities)
        {

            // 每个元素检测自己能不能懂
            // 能动，就检测下一个位置是否为空
            // 为空，下落
            // 这里只负责在场景中已有原色的下落，新生成的元素下落不在这里
            Debug.Log(GetType() + "/Execute()/……");
            var gameBoard = _contexts.game.threeTypesOfDiabetesGameGameBoard;

            for (int column = 0; column < gameBoard.columns; column++)
            {
                for (int row = 1; row < gameBoard.rows; row++)
                {
                    var pos = new CustomVector2(column,row);

                    var movable = _contexts.game.GetEntitiesWithThreeTypesOfDiabetesGameItemIndex(pos)
                        .Where(e => e.isThreeTypesOfDiabetesGameMovableCommponent).ToArray();
                    Debug.Log(GetType() + "/Execute()/movable.Length ……" + movable.Length);
                    foreach (GameEntity entity in movable)
                    {
                        MoveDown(entity);
                    }
                }
            }
              
        }

        private void MoveDown(GameEntity entity) {
            // 检查是否有空位
            // 有则下落到最下面(更新元素位置，自行就会下落)
            Debug.Log(GetType() + "/MoveDown()/……");
            var newRow = GetEmptyItemServer.Instance.getNextEmptyRow(entity.threeTypesOfDiabetesGameItemIndex.index);
            if (newRow < entity.threeTypesOfDiabetesGameItemIndex.index.y)
            {
                Debug.Log(GetType()+ "/MoveDown() newRow < entity.threeTypesOfDiabetesGameItemIndex.index.y/……");
                entity.ReplaceThreeTypesOfDiabetesGameFall(FallState.FALL);
                entity.ReplaceThreeTypesOfDiabetesGameItemIndex(new CustomVector2(entity.threeTypesOfDiabetesGameItemIndex.index.x,newRow));
            }
        }
    }
}
