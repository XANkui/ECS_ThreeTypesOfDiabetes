using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System.Linq;
using ThreeTypesOfDiabetesGame.Data;

namespace ThreeTypesOfDiabetesGame
{
    /// <summary>
    /// 消除爆炸阵列的球的响应系统
    /// </summary>
    public class EliminateExplodeSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;
        public EliminateExplodeSystem(Contexts context) : base(context.game)
        {
            _contexts = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ThreeTypesOfDiabetesGameDestroyCommponent);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasThreeTypesOfDiabetesGameItemEffectState
                && entity.threeTypesOfDiabetesGameItemEffectState.state == ItemEffectName.EXPLODE;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                CustomVector2 pos = entity.threeTypesOfDiabetesGameItemIndex.index;
                GameEntity[] temp;
                for (int x = pos.x-1; x <= pos.x + 1; x++)
                {
                    for (int y = pos.y - 1; y <= pos.y + 1; y++)
                    {
                        if (x<0||y<0)
                        {
                            continue;
                        }

                        temp = _contexts.game.GetEntitiesWithThreeTypesOfDiabetesGameItemIndex(new Data.CustomVector2(x, y))
                        .ToArray();

                        if (temp.Length == 1)
                        {
                            temp[0].isThreeTypesOfDiabetesGameDestroyCommponent = true;
                        }
                    }
                }
            }
        }
    }
}
