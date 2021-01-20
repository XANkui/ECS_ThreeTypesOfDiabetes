using Entitas;
using Entitas.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThreeTypesOfDiabetesGame
{
    public class ViewBase : MonoBehaviour, IView, IThreeTypesOfDiabetesGameDestroyCommponentListener
    {
        internal GameEntity _gameEntity;
        public virtual void Link(IEntity entity, IContext context)
        {
            if (entity is GameEntity)
            {
                _gameEntity = entity as GameEntity;
            }
            else {
                Debug.LogError(GetType()+ "/Link()/ entity‘ s type is error ");
                return;
            }
            // 添加销毁组件监听
            _gameEntity.AddThreeTypesOfDiabetesGameDestroyCommponentListener(this);

            // 该 Unity 游戏物体关联到ECS
            this.gameObject.Link(_gameEntity);
        }

        public virtual void OnThreeTypesOfDiabetesGameDestroyCommponent(GameEntity entity)
        {
            // 断开关联
            this.gameObject.Unlink();
        }
    }
}
