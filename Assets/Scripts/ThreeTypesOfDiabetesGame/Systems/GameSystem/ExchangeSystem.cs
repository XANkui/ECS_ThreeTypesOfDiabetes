using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

namespace ThreeTypesOfDiabetesGame
{
    /// <summary>
    /// 交换运动部分的响应系统
    /// </summary>
    public class ExchangeSystem : ReactiveSystem<GameEntity>
    {
        public ExchangeSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ThreeTypesOfDiabetesGameExchange);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasThreeTypesOfDiabetesGameExchange
                && (entity.threeTypesOfDiabetesGameExchange.exchangeState==ExchangeState.START
                    || entity.threeTypesOfDiabetesGameExchange.exchangeState == ExchangeState.EXCHANGE_BACK);
        }

        protected override void Execute(List<GameEntity> entities)
        {
            if (entities.Count == 2)
            {
                Exchange(entities[0],entities[1]);
            }
        }

        // 交换两球
        private void Exchange(GameEntity one, GameEntity two) {
            var onePos = one.threeTypesOfDiabetesGameItemIndex.index;
            var twoPos = two.threeTypesOfDiabetesGameItemIndex.index;

            one.ReplaceThreeTypesOfDiabetesGameItemIndex(twoPos);
            two.ReplaceThreeTypesOfDiabetesGameItemIndex(onePos);

            SetExchangeState(one);
            SetExchangeState(two);
        }

        // 更新交换后球的状态标记
        private void SetExchangeState(GameEntity entity) {
            if (entity.threeTypesOfDiabetesGameExchange.exchangeState == ExchangeState.START)
            {
                entity.ReplaceThreeTypesOfDiabetesGameExchange(ExchangeState.EXCHANGE);
            }
            else if (entity.threeTypesOfDiabetesGameExchange.exchangeState == ExchangeState.EXCHANGE_BACK)
            {
                entity.ReplaceThreeTypesOfDiabetesGameExchange(ExchangeState.END);
            }
        }
    }
}

