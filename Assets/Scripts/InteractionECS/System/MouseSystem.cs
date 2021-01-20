using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

namespace InteractionDemo {
    /// <summary>
    /// IExecuteSystem 每帧执行
    /// </summary>
    public class MouseSystem : IExecuteSystem,IInitializeSystem
    {
        private InputEntity _inputEntity;
        private InputContext _contexts;

        public MouseSystem(Contexts contexts) {
            Debug.Log(GetType() + "/MouseSystem()/ construct func");
            _contexts = contexts.input;
        }

        public void Initialize()
        {
            _inputEntity = _contexts.interactionDemoMouseEntity;
        }

        public void Execute()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _contexts.ReplaceInteractionDemoMouse(MouseType.Left, MouseState.Down);

            }
            if (Input.GetMouseButtonDown(1))
            {
                _contexts.ReplaceInteractionDemoMouse(MouseType.Right, MouseState.Down);

            }
        }

    }
}
