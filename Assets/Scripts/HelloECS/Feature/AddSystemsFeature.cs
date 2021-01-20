
/// <summary>
/// 用于添加需要的系统 System
/// </summary>
public class AddSystemsFeature : Feature
{
    // "AddSystemsFeature" 名字自取
    public AddSystemsFeature(Contexts contexts):base("AddSystemsFeature") {
        // 添加系统
        Add(new HelloECSSystem(contexts));
        Add(new InitSystem(contexts));
    }
}
