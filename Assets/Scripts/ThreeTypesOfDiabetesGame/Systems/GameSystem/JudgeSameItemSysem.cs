using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;


namespace ThreeTypesOfDiabetesGame
{
    /// <summary>
    /// 判断相同颜色数组是否满足条件进行消除
    /// </summary>
    public class JudgeSameItemSysem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;
        public JudgeSameItemSysem(Contexts context) : base(context.game)
        {
            _contexts = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ThreeTypesOfDiabetesGameDetectionSameItem);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasThreeTypesOfDiabetesGameDetectionSameItem;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                if (IsMeetCondition(entity))
                {
                    // 判断队形消除
                    entity.isThreeTypesOfDiabetesGameJudgeFormatiom=(true);
                    // 仅消除
                    //entity.ReplaceThreeTypesOfDiabetesGameElimainate(true);
                }
                else {
                    // 不消除
                    entity.ReplaceThreeTypesOfDiabetesGameElimainate(false);
                }
            }
        }

        private bool IsMeetCondition(GameEntity entity) {
            int left = entity.threeTypesOfDiabetesGameDetectionSameItem._leftEntities.Count;
            int right = entity.threeTypesOfDiabetesGameDetectionSameItem._rightEntities.Count;
            int up = entity.threeTypesOfDiabetesGameDetectionSameItem._upEntities.Count;
            int down = entity.threeTypesOfDiabetesGameDetectionSameItem._downEntities.Count;

            return (left + right >= 2)
                || (up + down >= 2);
        }
    }

}