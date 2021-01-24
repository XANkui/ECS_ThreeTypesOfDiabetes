using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

namespace ThreeTypesOfDiabetesGame
{
    public class JudgeFormationSystem : ReactiveSystem<GameEntity>
    {
        public JudgeFormationSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ThreeTypesOfDiabetesGameJudgeFormatiom);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isThreeTypesOfDiabetesGameJudgeFormatiom;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                if (entity.threeTypesOfDiabetesGameItemEffectState.state == ItemEffectName.NONE)
                {
                    JudgeItem(entity);
                }
                else {
                    entity.isThreeTypesOfDiabetesGameJudgeFormatiom = false;
                }

                entity.ReplaceThreeTypesOfDiabetesGameElimainate(true);
            }
        }

        // 判断是否满足特殊元素生成要求
        private void JudgeItem(GameEntity entity) {
            Debug.Log(GetType()+ "/JudgeItem()/ JudgeEliminateXXXXX……");
            // 添加队形标记
            if (JudgeEliminateAll(entity.threeTypesOfDiabetesGameDetectionSameItem))
            {
                Debug.Log(GetType() + "/JudgeItem()/ JudgeEliminateAll……");
                entity.ReplaceThreeTypesOfDiabetesGameItemEffectState(ItemEffectName.ELIMINATE_SAME_COLOR);
            }
            else if (JudgeEliminateHorizontal(entity.threeTypesOfDiabetesGameDetectionSameItem))
            {
                Debug.Log(GetType() + "/JudgeItem()/ JudgeEliminateHorizontal……");
                entity.ReplaceThreeTypesOfDiabetesGameItemEffectState(ItemEffectName.ELIMINATE_HORIZONTAL);
            }
            else if (JudgeEliminateVertical(entity.threeTypesOfDiabetesGameDetectionSameItem))
            {
                Debug.Log(GetType() + "/JudgeItem()/ JudgeEliminateVertical……");
                entity.ReplaceThreeTypesOfDiabetesGameItemEffectState(ItemEffectName.ELIMINATE_VERTICAL);
            }
            else if (JudgeExplode(entity.threeTypesOfDiabetesGameDetectionSameItem))
            {
                Debug.Log(GetType() + "/JudgeItem()/ JudgeExplode……");
                entity.ReplaceThreeTypesOfDiabetesGameItemEffectState(ItemEffectName.EXPLODE);
            }
            else
            {
                Debug.Log(GetType() + "/JudgeItem()/ JudgeEliminate None……");
                entity.isThreeTypesOfDiabetesGameJudgeFormatiom = false;
            }
        }

        // 消除所有相同颜色的元素（条件5个及5个以上元素连成一条线(加上自身)）
        private bool JudgeEliminateAll(DetectionSameItem listComponent)
        {

            // 判断行
            if ((listComponent._leftEntities.Count + listComponent._rightEntities.Count) >= 4)
            {
                return true;
            }
            // 判断列
            if ((listComponent._upEntities.Count + listComponent._downEntities.Count) >= 4)
            {
                return true;
            }

            return false;
        }

        // 消除行（条件：四个元素连成横线）
        private bool JudgeEliminateHorizontal(DetectionSameItem listComponent)
        {
            // 判断行
            if ((listComponent._leftEntities.Count + listComponent._rightEntities.Count) == 3)
            {
                return true;
            }

            return false;
        }

        // 消除列（条件：四个元素连成竖线）
        private bool JudgeEliminateVertical(DetectionSameItem listComponent)
        {
            // 判断列
            if ((listComponent._upEntities.Count + listComponent._downEntities.Count) == 3)
            {
                return true;
            }

            return false;



        }

        // 爆炸消除以此元素为中心的九宫格范围（条件：横竖都满足三个及三个元素以上）
        private bool JudgeExplode(DetectionSameItem listComponent)
        {
            // 判断列行
            if ((listComponent._upEntities.Count + listComponent._downEntities.Count) >= 2
                && (listComponent._leftEntities.Count + listComponent._rightEntities.Count) >= 2)
            {
                return true;
            }

            return false;
        }
    }
}
