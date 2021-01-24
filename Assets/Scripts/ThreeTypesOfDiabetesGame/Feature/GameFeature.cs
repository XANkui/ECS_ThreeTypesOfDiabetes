using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThreeTypesOfDiabetesGame
{
    public class GameFeature : Feature
    {
        public GameFeature(Contexts contexts) {
            Add(new GameBoardSystem(contexts));
            Add(new ExchangeSystem(contexts));
            Add(new MoveCompleteSystem(contexts));
            Add(new GetSameColorSystem(contexts));
            Add(new JudgeSameItemSysem(contexts));
            Add(new EliminateSystem(contexts));
            Add(new ExchangeBackSystem(contexts));
            Add(new FallSystem(contexts));
            Add(new DestroySystem(contexts));
            Add(new FillSystem(contexts));
            Add(new ChangeItemSpriteSystem(contexts));
            Add(new JudgeFormationSystem(contexts));
            Add(new EliminateSameColorSystem(contexts));
            Add(new EliminateHorizontalSystem(contexts));
            Add(new EliminateVerticalSystem(contexts));
            Add(new EliminateExplodeSystem(contexts));

        }
    }
}
