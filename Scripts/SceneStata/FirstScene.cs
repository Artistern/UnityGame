using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
///引导关卡
/// </summary>
public class FirstScene:ISceneState
{
    private float Blood;
    public FirstScene(SceneStateController controller) : base("FirstScene", controller)
    {
       
    }

    public override void StateStart()
    {
        TalkManager.isEnd = false;
        NpcManControl.isTalk = false;
        Blood = PlayerManager.Instance.PlayerBlood;
        CuteCount.isOver = false;
        //UnityEngine.Debug.Log("战斗关卡");
    }

    public override void StateUpdate()
    {
        if (PlayerManager.Instance.PlayerBlood<=0)
        {
            if (PlayerManager.Instance.isRecall == true)
            {
                mController.SetScene(new FirstScene(mController));
                PlayerManager.Instance.PlayerBlood = Blood;
            }
        }

        //UnityEngine.Debug.Log(CuteCount.isOver);
        if (CuteCount.isOver == true)
        {
            mController.SetScene(new BattleScene(mController));
        }
    }

    public override void StateEnd()
    {

    }
}

