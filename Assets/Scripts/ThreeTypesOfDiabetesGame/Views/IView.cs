using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThreeTypesOfDiabetesGame
{
    public interface IView 
    {
        void Link(IEntity entity, IContext context);
    }
}
