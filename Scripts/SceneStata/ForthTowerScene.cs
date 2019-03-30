using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class ForthTowerScene:ISceneState
{
    private float Blood;
    public ForthTowerScene(SceneStateController controller) : base("ForthScene", controller)
    {

    }

    public override void StateStart()
    {
        GameCoreManager.Instance.TowerCount = 4;
        MonsterHelpManager.Instance.ClearMonster();
        MonsterHelpManager.Instance.Clear();
        Blood = PlayerManager.Instance.PlayerBlood;
        CuteCount.isOver = false;
    }

    public override void StateUpdate()
    {
        if (PlayerManager.Instance.PlayerBlood <= 0)
        {
            if (PlayerManager.Instance.isRecall == true)
            {
                mController.SetScene(new ForthTowerScene(mController));
                PlayerManager.Instance.PlayerBlood = Blood;
            }
        }
        if (CuteCount.isOver == true)
        {
            mController.SetScene(new FifthTowerScene(mController));
        }
    }

    public override void StateEnd()
    {

    }
}

