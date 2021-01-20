using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionDemo
{
    public class GameFeature : Feature
    {
        public GameFeature(Contexts context) {
            Debug.Log(GetType() + "/GameFeature()/ ");
            Add(new AddViewSystem(context));
            Add(new SpriteRendererSystem(context));
            Add(new PositionSystem(context));
            Add(new MoveSystem(context));
            Add(new DirectionSystem(context));
            Add(new ChangeDIrectionSystem(context));
        }
    }
}
