using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

namespace ThreeTypesOfDiabetesGame
{
    public class MoveCompleteSystem : ReactiveSystem<GameEntity>
    {
        public MoveCompleteSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ThreeTypesOfDiabetesGameMoveComplete);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isThreeTypesOfDiabetesGameMoveComplete;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                entity.ReplaceThreeTypesOfDiabetesGameFall(FallState.STEADY);
                entity.isThreeTypesOfDiabetesGameGetSameColor = true;
                entity.isThreeTypesOfDiabetesGameMoveComplete = false;
            }
        }
    }
}
