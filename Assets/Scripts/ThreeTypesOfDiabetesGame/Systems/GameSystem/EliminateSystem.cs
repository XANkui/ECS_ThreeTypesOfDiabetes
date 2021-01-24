using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

namespace ThreeTypesOfDiabetesGame
{
    public class EliminateSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;
        public EliminateSystem(Contexts context) : base(context.game)
        {
            _contexts = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ThreeTypesOfDiabetesGameElimainate);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasThreeTypesOfDiabetesGameElimainate && entity.threeTypesOfDiabetesGameElimainate.canElimainate;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            List<IEntity> sameEntities = GetSameEntities(entities);

            GameEntity temp;
            foreach (IEntity entity in sameEntities)
            {
                temp = entity as GameEntity;
                if (temp != null)
                {
                    temp.isThreeTypesOfDiabetesGameDestroyCommponent = true;
                }
            }
        }


        /// <summary>
        /// 添加要消除的物体球
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        private List<IEntity> GetSameEntities(List<GameEntity> entities) {

            List<IEntity> sameEntities = new List<IEntity>();
            foreach (GameEntity entity in entities)
            {
                if (entity.isThreeTypesOfDiabetesGameJudgeFormatiom == false)
                {
                    // 添加自身
                    sameEntities.Add(entity);
                }
                else {  // 特殊元素状态恢复，后面可消除
                    entity.isThreeTypesOfDiabetesGameJudgeFormatiom = false;
                }        

                int left = entity.threeTypesOfDiabetesGameDetectionSameItem._leftEntities.Count;
                int right = entity.threeTypesOfDiabetesGameDetectionSameItem._rightEntities.Count;
                int up = entity.threeTypesOfDiabetesGameDetectionSameItem._upEntities.Count;
                int down = entity.threeTypesOfDiabetesGameDetectionSameItem._downEntities.Count;

                // 添加 横向
                if ((left + right >= 2))
                {
                    sameEntities.AddRange(entity.threeTypesOfDiabetesGameDetectionSameItem._leftEntities);
                    sameEntities.AddRange(entity.threeTypesOfDiabetesGameDetectionSameItem._rightEntities);
                }

                // 添加 竖向
                if ((up + down >= 2))
                {
                    sameEntities.AddRange(entity.threeTypesOfDiabetesGameDetectionSameItem._upEntities);
                    sameEntities.AddRange(entity.threeTypesOfDiabetesGameDetectionSameItem._downEntities);
                }
                
            }

            return sameEntities;
        }

    }
}
