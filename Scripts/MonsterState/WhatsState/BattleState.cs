using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// 怪物战斗逻辑
/// </summary>
public class BattleState:IStateMonster
{
    private BattleControl mBattleControl;
    public BattleState(MonsterControl monsterControl):base(monsterControl)
    {
        mBattleControl=new BattleControl();
    }
    public override void StartState(GameObject gameObject, CharacterController characterController)
    {
        mGameObject = gameObject;
        mCharacterController = characterController;
        mBattleControl.SetBattleState(new NormalAttack(mBattleControl), mGameObject, mCharacterController);
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
                mMonsterControl.SetMonsterState(new Stand(mMonsterControl), mGameObject, mCharacterController);
            }

        }else if (PlayerManager.Instance.PlayerBlood<=0)
        {
            mMonsterControl.SetMonsterState(new Stand(mMonsterControl), mGameObject, mCharacterController);
        }
        if (mGameObject.GetComponent<MonsterDamage>().Blood <= 0)//如果自身死亡，就指向死亡状态
        {

            mMonsterControl.SetMonsterState(new DeadState(mMonsterControl), mGameObject, mCharacterController);
        }
    }
    public override void EndState()
    {
        
    }
}

