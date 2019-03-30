using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneStateController
{
    private ISceneState mState;

    private AsyncOperation mAo;

    private bool mIsRunStart = false;

    public  bool isLoad = false;
    /// <summary>
    /// 切换状态的方法
    /// </summary>
    public void SetScene(ISceneState state, bool isFirtAwake = false)
    {
        if (mState != null)
        {
            mState.StateEnd();//让上一个场景清理
        }
        mState = state;
        if (!isFirtAwake)//如果不是第一次打开场景
        {
            mAo = SceneManager.LoadSceneAsync(mState.SceneName());
            mIsRunStart = false;
        }
        else//如果是第一次打开场景
        {
            mState.StateStart();
            mIsRunStart = true;
        }

    }
    public void StateUpdate()
    {
        //正在加载
        if (mAo != null && mAo.isDone == false)
        {
            //Debug.Log("正在加载，请等待");
            isLoad = true;
            return;
        }

        isLoad = false;
        //加载完成,首先运行开始方法
        if (mAo != null && mAo.isDone == true && mIsRunStart == false)
        {
            mState.StateStart();
            mIsRunStart = true;
        }
        //运行之后就执行运行方法
        if (mState != null)
        {
            mState.StateUpdate();
        }
    }
}

