using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThreeTypesOfDiabetesGame
{
    public class RandomPathServer
    {
        public static string RandomPath() {
            int index = Random.Range(0, 6);

            return ResPath.PrefabPath+ "Item" + index;
        }
    }
}
