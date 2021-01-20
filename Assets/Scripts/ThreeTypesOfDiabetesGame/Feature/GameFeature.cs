using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThreeTypesOfDiabetesGame
{
    public class GameFeature : Feature
    {
        public GameFeature(Contexts contexts) {
            Add(new GameBoardSystem(contexts));
        }
    }
}
