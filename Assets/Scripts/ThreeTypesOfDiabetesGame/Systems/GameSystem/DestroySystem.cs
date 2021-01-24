using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

namespace ThreeTypesOfDiabetesGame
{
    /// <summary>
    /// 物体消除后的销毁响应系统
    /// (由于 ReactiveSystem<GameEntity> 执行顺序先于 我们定义的IThreeTypesOfDiabetesGameItemIndexListener 所以不合适
    /// 使用  ICleanupSystem (最后执行)
    /// )
    /// </summary>
    public class DestroySystem : ICleanupSystem
    {
        Contexts _contexts;
        IGroup<GameEntity> _group;

        public DestroySystem(Contexts context) 
        {
            _contexts = context;
            _group = _contexts.game.GetGroup(GameMatcher.ThreeTypesOfDiabetesGameDestroyCommponent);
        }

        public void Cleanup()
        {

            foreach (GameEntity entity in _group.GetEntities())
            {
                entity.Destroy();
            }
        }
    }
}
