using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class BattleScene : ISceneState
{
    private float Blood;
    public BattleScene(SceneStateController controller) : base("BattleScene", controller)
    {
    }

    public override void StateStart()
    {
        GameCoreManager.Instance.TowerCount = 1;
        CuteCount.isOver = false;
        Blood = PlayerManager.Instance.PlayerBlood;
    }

    public override void StateUpdate()
    {
        if (PlayerManager.Instance.PlayerBlood<=0)
        {
            if (PlayerManager.Instance.isRecall==true)
            {
                mController.SetScene(new BattleScene(mController));
                PlayerManager.Instance.PlayerBlood = Blood;
            }
        }

        if (CuteCount.isOver == true)
        {
            mController.SetScene(new SecondTowerScene(mController));
        }
    }

    public override void StateEnd()
    {

    }
}
