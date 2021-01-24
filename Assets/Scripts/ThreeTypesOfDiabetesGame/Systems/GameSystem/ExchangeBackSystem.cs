using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Entitas;

namespace ThreeTypesOfDiabetesGame
{
    public class ExchangeBackSystem : ReactiveSystem<GameEntity>
    {
        public ExchangeBackSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ThreeTypesOfDiabetesGameElimainate);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasThreeTypesOfDiabetesGameExchange
                && entity.hasThreeTypesOfDiabetesGameElimainate
                && !entity.threeTypesOfDiabetesGameElimainate.canElimainate
                && entity.threeTypesOfDiabetesGameExchange.exchangeState == ExchangeState.EXCHANGE;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                entity.ReplaceThreeTypesOfDiabetesGameExchange(ExchangeState.EXCHANGE_BACK);
            }
        }
    }
}
