using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

namespace ThreeTypesOfDiabetesGame
{
    /// <summary>
    /// 计分响应系统
    /// </summary>
    public class ScoreSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        Contexts _contexts;
        public ScoreSystem(Contexts context) : base(context.game)
        {
            _contexts = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            // 组件移除
            return context.CreateCollector(GameMatcher.ThreeTypesOfDiabetesGameGameBoardItem.Removed());
        }

        protected override bool Filter(GameEntity entity)
        {
            // 移除后不是item的条件
            return entity.isThreeTypesOfDiabetesGameGameBoardItem==false;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            // 获取当前分数，然后在加分
            int score = _contexts.game.threeTypesOfDiabetesGameScore.score;
            _contexts.game.ReplaceThreeTypesOfDiabetesGameScore(score+entities.Count);
        }

        // 初始化数据
        public void Initialize()
        {
            _contexts.game.ReplaceThreeTypesOfDiabetesGameScore(0);
        }
    }
}
