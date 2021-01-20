using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

namespace InteractionDemo
{
    public class AddViewSystem : ReactiveSystem<GameEntity>
    {
        private Transform _parent;
        private Contexts _context;

        public AddViewSystem(Contexts contexts) : base(contexts.game)
        {
            Debug.Log(GetType()+ "/AddViewSystem()/ construct func");
            _context = contexts;
            _parent = new GameObject("ViewParent").transform;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.InteractionDemoSprite);
        }

        protected override bool Filter(GameEntity entity)
        {
            // 如果有精灵组件 但没有 没有 View 组件
            return entity.hasInteractionDemoSprite && !entity.hasInteractionDemoView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                GameObject go = new GameObject("View");
                go.transform.SetParent(_parent);
                go.Link(entity);
                entity.AddInteractionDemoView(go.transform);
                entity.isInteractionDemoMoveComplete = true;
            }
        }
    }
}
