
using Entitas;

/// <summary>
/// 初始化系统
/// </summary>
public class InitSystem : IInitializeSystem
{
    private readonly GameContext mGameContext;

    /// <summary>
    /// 构造函数，获取上下文
    /// </summary>
    /// <param name="contexts"></param>
    public InitSystem(Contexts contexts) {
        mGameContext = contexts.game;
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public void Initialize()
    {
        mGameContext.CreateEntity().AddHelloECS("Hello ECS Entitas……");
    }
}
