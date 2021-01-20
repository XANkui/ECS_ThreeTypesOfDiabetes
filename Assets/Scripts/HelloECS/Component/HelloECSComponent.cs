using Entitas;


/// <summary>
/// HelloECSComponent 组件继承 IComponent
/// 注入属性为 Game （目前 Entitas 只有  Game，Input）
/// </summary>
[Game]
public class HelloECSComponent : IComponent
{
    // 变量
    public string message;
}
