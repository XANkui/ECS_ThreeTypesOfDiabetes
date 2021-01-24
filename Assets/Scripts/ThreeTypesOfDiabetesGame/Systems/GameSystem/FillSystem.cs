using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using ThreeTypesOfDiabetesGame.Data;

namespace ThreeTypesOfDiabetesGame
{
    /// <summary>
    /// 消除后填充新的item的响应系统
    /// </summary>
    public class FillSystem : ReactiveSystem<GameEntity>
    {
        Contexts _contexts;
        public FillSystem(Contexts context) : base(context.game)
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
            var gameBoard = _contexts.game.threeTypesOfDiabetesGameGameBoard;
            for (int column = 0; column < gameBoard.columns; column++)
            {
                // 获取最上层之上的坐标，方便遍历到最上面一行
                var pos = new CustomVector2(column, gameBoard.rows);
                // 得到最小的位置
                var rowPosMin = GetEmptyItemServer.Instance.getNextEmptyRow(pos);

                for (int row = rowPosMin; row < gameBoard.rows; row++)
                {
                    CreatorServer.Instance.CreateRandomBall(new CustomVector2(column,row));
                }
            }
        }
    }
}
