using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ISceneState
{
    private string mSceneName;
    protected SceneStateController mController;
    public ISceneState(string SceneName, SceneStateController controller)
    {
        mSceneName = SceneName;
        mController = controller;
    }
    public string SceneName()
    {
        return mSceneName;
    }
    /// <summary>
    /// 每次进入状态使用
    /// </summary>
    public virtual void StateStart() { }
    /// <summary>
    /// 每次状态结束使用
    /// </summary>
    public virtual void StateEnd() { }
    /// <summary>
    /// 更新状态的行为
    /// </summary>
    public virtual void StateUpdate() { }
}

