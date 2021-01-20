using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionDemo
{
    public class InputFeature : Feature
    {
        public InputFeature(Contexts context) {
            Debug.Log(GetType() + "/InputFeature()/ ");
            Add(new MouseSystem(context));
            Add(new CreatorSystem(context));
            Add(new StartMoveSystem(context));
        }
    }
}
