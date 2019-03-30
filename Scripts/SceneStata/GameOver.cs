using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class GameOver:ISceneState
{
    private CanvasGroup mCaCanvasGroup;
    public GameOver(SceneStateController controller) : base("GameOver", controller)
    {
    }

    public override void StateStart()
    {
        //UnityEngine.Debug.Log("战斗关卡");
        mCaCanvasGroup = GameObject.FindGameObjectWithTag("BateShow").GetComponent<CanvasGroup>();
        mCaCanvasGroup.alpha = 0;
    }

    public override void StateUpdate()
    {
        //UnityEngine.Debug.Log(CuteCount.isOver);
        //if (CuteCount.isOver == true)
        //{
        //    mController.SetScene(new StartScene(mController));
        //    //UnityEngine.GameObject.Instantiate(UnityEngine.Resources.Load<UnityEngine.GameObject>("Bate"));
        //}
        if (mCaCanvasGroup.alpha < 0.9)
        {
            mCaCanvasGroup.alpha = Mathf.Lerp(mCaCanvasGroup.alpha, 1, Time.deltaTime);
        }
        else
        {
            mCaCanvasGroup.alpha = 1;
            if (Input.anyKeyDown)
            {
                mController.SetScene(new StartScene(mController));
            }
        }
       
    }

    public override void StateEnd()
    {

    }
}

