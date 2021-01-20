using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

namespace InteractionDemo
{
    public class SpriteRendererSystem : ReactiveSystem<GameEntity>
    {
        public SpriteRendererSystem(Contexts context) : base(context.game)
        {
            Debug.Log(GetType() + "/SpriteRendererSystem()/ construct func");
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.InteractionDemoSprite);
        }

        protected override bool Filter(GameEntity entity)
        {
            // 同时有这两个组件，才执行 Execute
            return entity.hasInteractionDemoView && entity.hasInteractionDemoSprite;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                Transform trans = entity.interactionDemoView.viewTrans;
                SpriteRenderer sr = trans.GetComponent<SpriteRenderer>();
                if (sr==null)
                {
                    sr = trans.gameObject.AddComponent<SpriteRenderer>();
                }

                sr.sprite = Resources.Load<Sprite>(entity.interactionDemoSprite.spritePath);
            }
        }
    }
}
