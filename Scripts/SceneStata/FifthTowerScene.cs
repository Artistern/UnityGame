using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class FifthTowerScene:ISceneState
{
    private float Blood;
    public FifthTowerScene(SceneStateController controller) : base("FifthScene", controller)
    {

    }

    public override void StateStart()
    {
        GameCoreManager.Instance.TowerCount = 5;
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
                mController.SetScene(new FifthTowerScene(mController));
                PlayerManager.Instance.PlayerBlood = Blood;
            }
        }
        if (CuteCount.isOver == true)
        {
            mController.SetScene(new BossScene(mController));
        }
    }

    public override void StateEnd()
    {

    }
}
