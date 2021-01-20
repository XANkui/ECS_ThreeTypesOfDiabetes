using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;


namespace InteractionDemo
{
    /// <summary>
    /// 鼠标点击组件
    /// </summary>
    [Input, Unique]
    public class MouseComponent : IComponent
    {
        public MouseType mouseType;

        public MouseState mouseState;
    }
}
