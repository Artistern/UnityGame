using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class WitchOutBattleRestore:IStateWicth
{
    public WitchOutBattleRestore(WitchControl monsterControl) : base(monsterControl)
    {

    }
    /// <summary>
    /// 闲置状态初始化
    /// </summary>
    /// <param name="gameObject"></param>
    /// <param name="characterController"></param>
    public override void StartState(GameObject gameObject, CharacterController characterController)
    { 
        mGameObject = gameObject;
        mCharacterController = characterController;
    }

    public override void UpdateState()
    {
        if (mGameObject.GetComponent<MonsterDamage>().Blood <= 0)//如果自身死亡，就指向死亡状态
        {
            mMonsterControl.SetMonsterState(new WitchDeadState(mMonsterControl), mGameObject, mCharacterController);
        }
        else if (mGameObject.GetComponent<MonsterDamage>().MagicValue>0)
        {
            mGameObject.GetComponent<Animator>().SetTrigger("Buff");
            if (mGameObject.GetComponent<MonsterDamage>().Blood <= 0)//如果自身死亡，就指向死亡状态
            {
                mMonsterControl.SetMonsterState(new WitchDeadState(mMonsterControl), mGameObject, mCharacterController);
            }
            if (MonsterHelpManager.Instance.mMonsterDamageList.Count == 0)
            {
                mMonsterControl.SetMonsterState(new WitchBattleState(mMonsterControl), mGameObject, mCharacterController);
            }else
            {
                mGameObject.transform.LookAt(MonsterHelpManager.Instance.mMonsterDamageList[0].gameObject.transform);
            }
        }else
        {
        mMonsterControl.SetMonsterState(new WitchBattleState(mMonsterControl), mGameObject, mCharacterController);
        }
    }
    public override void EndState()
    {
        Debug.Log("结束");
    }
}

