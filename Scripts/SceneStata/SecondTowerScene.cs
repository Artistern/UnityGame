using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class SecondTowerScene : ISceneState
{
    private float Blood;
    public SecondTowerScene(SceneStateController controller) : base("SecondScene", controller)
    {
        
    }

    public override void StateStart()
    {
        GameCoreManager.Instance.TowerCount = 2;
        CuteCount.isOver = false;
        Blood = PlayerManager.Instance.PlayerBlood;
    }

    public override void StateUpdate()
    {
        if (PlayerManager.Instance.PlayerBlood <= 0)
        {
            if (PlayerManager.Instance.isRecall == true)
            {
                mController.SetScene(new SecondTowerScene(mController));
                PlayerManager.Instance.PlayerBlood = Blood;
            }
        }

        if (CuteCount.isOver == true)
        {
            mController.SetScene(new ThirdTowerScene(mController));
        }
    }

    public override void StateEnd()
    {
        
    }
}
