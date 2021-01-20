using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections;
using System.Collections.Generic;
using ThreeTypesOfDiabetesGame.Data;
using UnityEngine;

namespace ThreeTypesOfDiabetesGame {

    /// <summary>
    /// 点击组件
    /// Unique 只有一个
    /// </summary>
    [Input,Unique]
    public class ClickComponent : IComponent {
        public int x;
        public int y;
    }

    /// <summary>
    /// 滑动组件
    /// Unique 只有一个
    /// </summary>
    [Input, Unique]
    public class SlideComponent : IComponent
    {
        public CustomVector2 clickPos;
        public SlideDirection direction;
    }

}
