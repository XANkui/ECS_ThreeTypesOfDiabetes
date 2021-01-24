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


            // 随机颜色球数据面板
            //RandomColorGameBoardItems(gameBoard);

            // 配置表中的球面板数据
            JsonDataGameBoardItems(gameBoard);
        }

        // 随机颜色球面板数据
        private void RandomColorGameBoardItems(GameBoardComponent gameBoard) {
            CustomVector2 index = new CustomVector2();
            for (int x = 0; x < gameBoard.columns; x++)
            {
                for (int y = 0; y < gameBoard.rows; y++)
                {


                    index.x = x;
                    index.y = y;


                    if (RandomBlocker() == true)
                    {
                        CreatorServer.Instance.CreateBlocker(index);
                    }
                    else
                    {
                        CreatorServer.Instance.CreateRandomBall(index);
                    }
                }
            }
        }


        // 配置表中的球面板数据
        private void JsonDataGameBoardItems(GameBoardComponent gameBoard) {
            var list = GetJsonDataList();
            for (int row = 0; row < gameBoard.rows; row++)
            {
                for (int index = 0; index < list[row].Count; index++)
                {
                    CreatorServer.Instance.CreateBall(list[row][index],index,row);
                }
            }
        }

        // 获取配置表中的球面板数据
        private List<List<int>> GetJsonDataList() {

            var model = ModelManager.Instance.DataModel.Level[0];

            List<List<int>> list = new List<List<int>>();
            list.Add(model.row_0);
            list.Add(model.row_1);
            list.Add(model.row_2);
            list.Add(model.row_3);
            list.Add(model.row_4);
            list.Add(model.row_5);
            list.Add(model.row_6);
            list.Add(model.row_7);
            list.Add(model.row_8);

            return list;
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
