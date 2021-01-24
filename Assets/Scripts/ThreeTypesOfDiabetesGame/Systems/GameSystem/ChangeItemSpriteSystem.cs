using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Entitas;

namespace ThreeTypesOfDiabetesGame
{
    /// <summary>
    /// 特殊图片修改的相应系统 
    /// </summary>
    public class ChangeItemSpriteSystem : ReactiveSystem<GameEntity>
    {
        public ChangeItemSpriteSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ThreeTypesOfDiabetesGameItemEffectState);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasThreeTypesOfDiabetesGameItemEffectState
                && entity.threeTypesOfDiabetesGameItemEffectState.state != ItemEffectName.NONE;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                string itemEffectName = "";
                string[] buffer = entity.threeTypesOfDiabetesGameLoadPrefabCommponent.path.Split('/');
                if (buffer.Length == 2)
                {
                    itemEffectName = buffer[1];
                }
                else {
                    continue;
                }

                switch (entity.threeTypesOfDiabetesGameItemEffectState.state)
                {
                    
                    case ItemEffectName.ELIMINATE_SAME_COLOR:
                        Debug.Log(GetType() + "/Execute()/ ItemEffectName.ELIMINATE_SAME_COLOR ccccc");
                        itemEffectName += ResPath.AllPostfix;
                        break;
                    case ItemEffectName.ELIMINATE_HORIZONTAL:
                        itemEffectName += ResPath.HorizontalPostfix;
                        break;
                    case ItemEffectName.ELIMINATE_VERTICAL:
                        itemEffectName += ResPath.VertialPostfix;
                        break;
                    case ItemEffectName.EXPLODE:
                        itemEffectName += ResPath.ExplodePostfix;
                        break;
                   
                }

                // 加载图片组件
                entity.ReplaceThreeTypesOfDiabetesGameLoadSprite(itemEffectName);
                
            }

        }
    }
}
