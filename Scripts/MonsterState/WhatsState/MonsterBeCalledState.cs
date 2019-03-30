using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class MonsterBeCalledState : IStateMonster
{
    public MonsterBeCalledState(MonsterControl monsterControl):base(monsterControl)
    {

    }

    public override void StartState(GameObject gameObject, CharacterController characterController)
    {
        mGameObject = gameObject;
        mCharacterController = characterController;
        //mGameObject.GetComponent<Animator>().SetBool("Walk",false);
    }

    public override void UpdateState()
    {
        //从监听器那里知道了法师正在被攻击，下面是走向法师的方法，并且在途中检测是否遇到玩家，如果遇到，就转移到战斗状态
        if (MonsterHelpManager.Instance.mMonsterGameObjectList.Count == 0)
        {
            mMonsterControl.SetMonsterState(new Stand(mMonsterControl), mGameObject, mCharacterController);
        }
        else
        {
            //mGameObject.transform.LookAt(MonsterHelpManager.Instance.mMonsterGameObjectList[0].gameObject.transform);
            mGameObject.transform.LookAt(MonsterHelpManager.Instance.mMonsterGameObjectList[0].GetComponent<MonsterDamage>().mGameObjectChild.transform);
            mGameObject.GetComponent<Animator>().SetBool("Walk", true);
            if (mGameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Run"))
            {
                mCharacterController.SimpleMove(mGameObject.transform.forward * mGameObject.GetComponent<MonsterDamage>().MoveSpeed);
            }
            if (mGameObject.GetComponent<MonsterDamage>().IsPlayer)
            {
                //mGameObject.GetComponent<Animator>().SetBool("Walk", true);
                mMonsterControl.SetMonsterState(new BattleState(mMonsterControl), mGameObject, mCharacterController);
            }
        }
        
    }

    public override void EndState()
    {
        
    }
}

