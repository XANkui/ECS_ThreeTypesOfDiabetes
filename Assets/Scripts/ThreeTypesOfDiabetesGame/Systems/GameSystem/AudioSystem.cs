using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System.Linq;

namespace ThreeTypesOfDiabetesGame
{
    public class EliminateAudioSystem : ReactiveSystem<GameEntity>
    {
        public EliminateAudioSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ThreeTypesOfDiabetesGameElimainate);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasThreeTypesOfDiabetesGameItemEffectState
                    && entity.threeTypesOfDiabetesGameElimainate.canElimainate;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                switch (entity.threeTypesOfDiabetesGameItemEffectState.state)
                {
                    case ItemEffectName.NONE:
                        entity.ReplaceThreeTypesOfDiabetesGameAudio(AudioName.NormalBomb.ToString());
                        break;
                    case ItemEffectName.ELIMINATE_SAME_COLOR:
                        entity.ReplaceThreeTypesOfDiabetesGameAudio(AudioName.SpecialBomb.ToString());

                        break;
                    case ItemEffectName.ELIMINATE_HORIZONTAL:
                        entity.ReplaceThreeTypesOfDiabetesGameAudio(AudioName.SpecialBomb.ToString());

                        break;
                    case ItemEffectName.ELIMINATE_VERTICAL:
                        entity.ReplaceThreeTypesOfDiabetesGameAudio(AudioName.SpecialBomb.ToString());

                        break;
                    case ItemEffectName.EXPLODE:
                        entity.ReplaceThreeTypesOfDiabetesGameAudio(AudioName.SpecialBomb.ToString());

                        break;
                  
                }
            }
        }
    }

    public class ExchangeAudioSystem : ReactiveSystem<GameEntity>
    {
        public ExchangeAudioSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ThreeTypesOfDiabetesGameExchange);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasThreeTypesOfDiabetesGameExchange
                    && (entity.threeTypesOfDiabetesGameExchange.exchangeState == ExchangeState.EXCHANGE 
                        || entity.threeTypesOfDiabetesGameExchange.exchangeState == ExchangeState.EXCHANGE_BACK);
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                entity.ReplaceThreeTypesOfDiabetesGameAudio(AudioName.Switch.ToString());
            }
        }
    }

    public class FallAudioSystem : ReactiveSystem<GameEntity>
    {
        public FallAudioSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ThreeTypesOfDiabetesGameItemIndex);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasThreeTypesOfDiabetesGameFall
                    && (entity.threeTypesOfDiabetesGameFall.state == FallState.FALL);
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                Debug.Log(GetType() + "/Execute()/ Fall Audio……");
                entity.ReplaceThreeTypesOfDiabetesGameAudio(AudioName.Fall.ToString());
            }
        }
    }
}
