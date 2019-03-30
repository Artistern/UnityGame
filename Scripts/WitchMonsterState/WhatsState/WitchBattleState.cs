using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class WitchBattleState:IStateWicth
{
    private WitchBattleControl mBattleControl;
    public WitchBattleState(WitchControl monsterControl) : base(monsterControl)
    {
        mBattleControl = new WitchBattleControl();
    }
    public override void StartState(GameObject gameObject, CharacterController characterController)
    {
        mGameObject = gameObject;
        mCharacterController = characterController;
        mBattleControl.SetBattleState(new WitchNormalAttack(mBattleControl), mGameObject, mCharacterController);
        MonsterHelpManager.Instance.ResgisterMonsters(mGameObject);
    }
    public override void UpdateState()
    {
        //if (MonsterDamage.IsPlayer == false)//如果玩家不在范围内就回到待机状态
        if (PlayerManager.Instance.PlayerBlood>0)
        {
            if (mGameObject.GetComponent<MonsterDamage>().IsPlayer)
            {
                mBattleControl.UpdateBattleState();
            }
            else if (mGameObject.GetComponent<MonsterDamage>().IsPlayer == false)
            {
                MonsterHelpManager.Instance.RemoveMonsterList(mGameObject);//退出状态，注销
                mMonsterControl.SetMonsterState(new WitchStand(mMonsterControl), mGameObject, mCharacterController);
            }
        }else if (PlayerManager.Instance.PlayerBlood<=0)
        {
            mMonsterControl.SetMonsterState(new WitchStand(mMonsterControl),mGameObject,mCharacterController);
        }


        if (mGameObject.GetComponent<MonsterDamage>().Blood <= 0)//如果自身死亡，就指向死亡状态
        {       
            mMonsterControl.SetMonsterState(new WitchDeadState(mMonsterControl), mGameObject, mCharacterController);
        }
        if (MonsterHelpManager.Instance.mMonsterDamageList.Count > 0&& mGameObject.GetComponent<MonsterDamage>().Blood>0)
        {
            MonsterHelpManager.Instance.RemoveMonsterList(mGameObject);//退出状态，注销
            mMonsterControl.SetMonsterState(new WitchOutBattleRestore(mMonsterControl), mGameObject, mCharacterController);
        }
    }
    public override void EndState()
    {
        Debug.Log("结束");
        //MonsterHelpManager.Instance.ResgisterMonsters(mGameObject);
    }
}
