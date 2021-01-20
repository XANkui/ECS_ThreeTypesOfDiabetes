
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class HelloECSSystem : ReactiveSystem<GameEntity>
{
    /// <summary>
    /// 构建函数，传入上下文
    /// 目前上下文只有 Game，Input
    /// 这里 HelloECSComponent 组件是 Game,故 contexts.game
    /// </summary>
    /// <param name="contexts"></param>
    public HelloECSSystem(Contexts contexts) : base(contexts.game) { 
        
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.HelloECS);
    }

    /// <summary>
    /// 过滤器，判断上下文是否包含该组件 Component
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    protected override bool Filter(GameEntity entity)
    {
        return entity.hasHelloECS;
    }

    /// <summary>
    /// 具体执行的代码
    /// </summary>
    /// <param name="entities"></param>
    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity entity in entities)
        {
            Debug.Log(entity.helloECS.message);
        }
    }
}
