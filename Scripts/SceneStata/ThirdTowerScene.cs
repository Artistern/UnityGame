using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class ThirdTowerScene:ISceneState
{
    private float Blood;
    public ThirdTowerScene(SceneStateController controller) : base("ThirdScene", controller)
    {

    }

    public override void StateStart()
    {

        GameCoreManager.Instance.TowerCount = 3;
        MonsterHelpManager.Instance.ClearMonster();
        MonsterHelpManager.Instance.Clear();
        CuteCount.isOver = false;
        Blood = PlayerManager.Instance.PlayerBlood;
    }

    public override void StateUpdate()
    {
        if (PlayerManager.Instance.PlayerBlood <= 0)
        {
            if (PlayerManager.Instance.isRecall == true)
            {
                mController.SetScene(new ThirdTowerScene(mController));
                PlayerManager.Instance.PlayerBlood = Blood;
            }
        }
        if (CuteCount.isOver == true)
        {
            mController.SetScene(new ForthTowerScene(mController));
        }
    }

    public override void StateEnd()
    {

    }
}

