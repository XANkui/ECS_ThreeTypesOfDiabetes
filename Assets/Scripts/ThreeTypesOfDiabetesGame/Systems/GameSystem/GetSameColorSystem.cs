using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using ThreeTypesOfDiabetesGame.Data;
using System;

namespace ThreeTypesOfDiabetesGame
{
    public class GetSameColorSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;
        public GetSameColorSystem(Contexts context) : base(context.game)
        {
            _contexts = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ThreeTypesOfDiabetesGameGetSameColor);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isThreeTypesOfDiabetesGameGetSameColor;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                //Debug.Log(GetType()+ "/Execute()/ Left SameColor Count:"+JudgeLeft(entity).Count);
                //Debug.Log(GetType()+ "/Execute()/ Right SameColor Count:"+JudgeRight(entity).Count);
                //Debug.Log(GetType()+ "/Execute()/ Up SameColor Count:"+JudgeUp(entity).Count);
                //Debug.Log(GetType()+ "/Execute()/ Down SameColor Count:"+JudgeDown(entity).Count);

                entity.ReplaceThreeTypesOfDiabetesGameDetectionSameItem(
                    JudgeLeft(entity),
                    JudgeRight(entity),
                    JudgeUp(entity),
                    JudgeDown(entity)
                    );
                entity.isThreeTypesOfDiabetesGameGetSameColor = false;

            }
        }

        private List<IEntity> JudgeLeft(GameEntity entity) {
            CustomVector2 pos = entity.threeTypesOfDiabetesGameItemIndex.index;
            List<IEntity> sameColorItems = new List<IEntity>();

            for (int i = pos.x - 1; i >= 0; i--)
            {
                if (AddSameColorItem(entity, i, pos.y, sameColorItems) == false) break;
            }

            return sameColorItems;
        }

        private List<IEntity> JudgeRight(GameEntity entity)
        {
            CustomVector2 pos = entity.threeTypesOfDiabetesGameItemIndex.index;
            List<IEntity> sameColorItems = new List<IEntity>();

            for (int i = pos.x + 1; i < _contexts.game.threeTypesOfDiabetesGameGameBoard.columns; i++)
            {
                if (AddSameColorItem(entity, i, pos.y, sameColorItems) == false) break;
            }
            return sameColorItems;
        }

        private List<IEntity> JudgeDown(GameEntity entity)
        {
            CustomVector2 pos = entity.threeTypesOfDiabetesGameItemIndex.index;
            List<IEntity> sameColorItems = new List<IEntity>();

            for (int i = pos.y - 1; i >= 0; i--)
            {
                if (AddSameColorItem(entity, pos.x,i, sameColorItems) == false) break;
            }
            return sameColorItems;
        }

        private List<IEntity> JudgeUp(GameEntity entity)
        {
            CustomVector2 pos = entity.threeTypesOfDiabetesGameItemIndex.index;
            List<IEntity> sameColorItems = new List<IEntity>();

            for (int i = pos.y + 1; i < _contexts.game.threeTypesOfDiabetesGameGameBoard.rows; i++)
            {
                if (AddSameColorItem(entity, pos.x, i, sameColorItems) == false) break;
            }

            return sameColorItems;
        }

        private bool AddSameColorItem(GameEntity entity, int x,int y,List<IEntity> sameColorItems) {
            string colorName = entity.threeTypesOfDiabetesGameLoadPrefabCommponent.path;
            // 判断，然后添加相同颜色Item
            var returnValue = JudgeSameColor(colorName, x, y);
            if (returnValue.Item1 == false)
            {
                return false;
            }
            else
            {
                sameColorItems.Add(returnValue.Item2);
                return true;
            }
        }

        private Tuple<bool,GameEntity> JudgeSameColor(string colorName, int x, int y ) {
            var array = _contexts.game.GetEntitiesWithThreeTypesOfDiabetesGameItemIndex(new CustomVector2(x,y));

            if (array.Count ==1)
            {
                var entity = array.SingleEntity();

                if (entity.isThreeTypesOfDiabetesGameMovableCommponent==false)
                {
                    return new Tuple<bool, GameEntity>(false, entity);
                }

                if (entity.threeTypesOfDiabetesGameLoadPrefabCommponent.path == colorName)
                {
                    return new Tuple<bool, GameEntity>(true, entity); ;
                }
            }

            return new Tuple<bool, GameEntity>(false, null); ;
        }
    }
}
