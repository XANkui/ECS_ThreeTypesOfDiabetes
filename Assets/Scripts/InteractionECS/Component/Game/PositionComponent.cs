using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionDemo
{
    [Game]
    public class PositionComponent : IComponent
    {
        public Vector2 position;
    }
}
