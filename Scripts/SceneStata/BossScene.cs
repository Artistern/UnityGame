using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class BossScene:ISceneState
{
    private float Blood;
    public BossScene(SceneStateController controller) : base("BossScene", controller)
    {
    }

    public override void StateStart()
    {
        GameCoreManager.Instance.TowerCount = 6;
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
                mController.SetScene(new BossScene(mController));
                PlayerManager.Instance.PlayerBlood = Blood;
            }
        }
        if (CuteCount.isOver == true)
        {
            mController.SetScene(new GameOver(mController));
        }
    }

    public override void StateEnd()
    {

    }
}
