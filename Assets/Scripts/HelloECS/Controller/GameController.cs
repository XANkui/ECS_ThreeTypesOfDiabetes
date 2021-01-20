using Entitas;
using UnityEngine;

/// <summary>
/// 控制器，挂在在Unity场景中执行的
/// </summary>
public class GameController : MonoBehaviour
{
    private Systems mSystems;
    // Start is called before the first frame update
    void Start()
    {
        // 获取上下文
        var context = Contexts.sharedInstance;
        // "Systems" 名称自取即可
        mSystems = new Feature("Systems").Add(new AddSystemsFeature(context));
        // 初始化
        mSystems.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        // 执行
        mSystems.Execute();
        // 清除
        mSystems.Cleanup();
    }
}
