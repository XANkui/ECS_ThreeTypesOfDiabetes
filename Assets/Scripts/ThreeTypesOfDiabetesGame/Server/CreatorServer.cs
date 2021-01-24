using System.Collections;
using System.Collections.Generic;
using ThreeTypesOfDiabetesGame.Data;
using UnityEngine;

namespace ThreeTypesOfDiabetesGame
{
    public class CreatorServer 
    {
        private static CreatorServer _instance;

        public static CreatorServer Instance
        {
            get
            {
                if (_instance==null)
                {
                    _instance = new CreatorServer();
                }
                return _instance;
            } 
        
        }

        private Contexts _contexts;

        public void Init(Contexts contexts) {
            _contexts = contexts;
        }

        /// <summary>
        /// 创建游戏面板
        /// </summary>
        public GameEntity CreateGameBoard() {
            GameEntity entity = _contexts.game.CreateEntity();
            entity.AddThreeTypesOfDiabetesGameGameBoard(8,9);
            return entity;
        }

        public GameEntity CreateRandomBall(CustomVector2 index) {
            GameEntity entity = _contexts.game.CreateEntity();
            entity.isThreeTypesOfDiabetesGameGameBoardItem = true;
            entity.isThreeTypesOfDiabetesGameMovableCommponent = true;
            entity.AddThreeTypesOfDiabetesGameItemIndex(index);
            entity.AddThreeTypesOfDiabetesGameLoadPrefabCommponent(RandomPathServer.RandomPath());
            entity.AddThreeTypesOfDiabetesGameItemEffectState(ItemEffectName.NONE);
            return entity;
        }

        public GameEntity CreateBlocker(CustomVector2 index) {
            GameEntity entity = _contexts.game.CreateEntity();
            entity.isThreeTypesOfDiabetesGameGameBoardItem = true;
            entity.isThreeTypesOfDiabetesGameMovableCommponent = false;
            entity.AddThreeTypesOfDiabetesGameItemIndex(index);
            entity.AddThreeTypesOfDiabetesGameLoadPrefabCommponent(ResPath.BlockerPath);
            return entity;
        }

        public GameEntity CreateBall(int nameIndex,int x, int y) {
            GameEntity entity = _contexts.game.CreateEntity();
            entity.isThreeTypesOfDiabetesGameGameBoardItem = true;
            entity.isThreeTypesOfDiabetesGameMovableCommponent = true;
            entity.ReplaceThreeTypesOfDiabetesGameFall(FallState.FALL);
            entity.AddThreeTypesOfDiabetesGameItemIndex(new CustomVector2(x,y));
            entity.AddThreeTypesOfDiabetesGameLoadPrefabCommponent(ResPath.PrefabPath+"Item"+nameIndex);
            entity.AddThreeTypesOfDiabetesGameItemEffectState(ItemEffectName.NONE);
            return entity;
        }
    }
}
