using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using ThreeTypesOfDiabetesGame.Data;

namespace ThreeTypesOfDiabetesGame
{
    /// <summary>
    /// 游戏面板的响应系统
    /// </summary>
    public class GameBoardSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private IGroup<GameEntity> _itemsGroup;

        public GameBoardSystem(Contexts context) : base(context.game)
        {
            _itemsGroup = context.game.GetGroup(GameMatcher.ThreeTypesOfDiabetesGameGameBoardItem);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ThreeTypesOfDiabetesGameGameBoard);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasThreeTypesOfDiabetesGameGameBoard;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            GameBoardComponent gameBoard = entities.SingleEntity().threeTypesOfDiabetesGameGameBoard;

            foreach (GameEntity entity in entities)
            {
                // TOdo :超出面板元素需要清除的逻辑
            }
        }

        /// <summary>
        /// 会自动调用的初始化
        /// </summary>
        public void Initialize()
        {
            GameBoardComponent gameBoard = CreatorServer.Instance.CreateGameBoard().threeTypesOfDiabetesGameGameBoard;

            for (int x = 0; x < gameBoard.columns; x++)
            {
                for (int y = 0; y < gameBoard.rows; y++)
                {
                    CustomVector2 index = new CustomVector2();

                    index.x = x;
                    index.y = y;


                    if (RandomBlocker() == true)
                    {
                        CreatorServer.Instance.CreateBlocker(index);
                    }
                    else {
                        CreatorServer.Instance.CreateBall(index);
                    }
                }
            }
        }

        /// <summary>
        /// 随机生成障碍物的概率
        /// </summary>
        /// <returns></returns>
        private bool RandomBlocker() {

            int num = Random.Range(0,10);
            if (num < 1)
            {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
