using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;


public class Stand:IStateMonster
{
    public Stand(MonsterControl monsterControl):base(monsterControl)
    {

    }
    /// <summary>
    /// 闲置状态初始化
    /// </summary>
    /// <param name="gameObject"></param>
    /// <param name="characterController"></param>
    public override void StartState(GameObject gameObject, CharacterController characterController)
    {
        m_Timer = 0;
        mGameObject = gameObject;
        mCharacterController = characterController;
        mGameObject.GetComponent<Animator>().SetBool("Walk",false);
    }
    /// <summary>
    /// 闲置状态更新
    /// </summary>
    public override void UpdateState()
    {
        m_Timer += Time.deltaTime;
        if (m_Timer>=3.0f)
        {
            float m = Random.Range(1, 30);
            if (m >= 15)
            {
                mMonsterControl.SetMonsterState(new Automatic_Patrol(mMonsterControl), mGameObject, mCharacterController);
            }
            m_Timer = 0;
        }
        //Debug.Log(PlayerCheck.IsPlayer);
        if (MonsterHelpManager.Instance.mMonsterGameObjectList.Count != 0&& PlayerManager.Instance.PlayerBlood > 0)
        {
            mMonsterControl.SetMonsterState(new MonsterBeCalledState(mMonsterControl), mGameObject, mCharacterController);
        }
        if (mGameObject.GetComponent<MonsterDamage>().IsPlayer&&PlayerManager.Instance.PlayerBlood>0)
        {
            mMonsterControl.SetMonsterState(new BattleState(mMonsterControl), mGameObject, mCharacterController);
        }
        if (mGameObject.GetComponent<MonsterDamage>().Blood <= 0)//如果自身死亡，就指向死亡状态
        {
            mMonsterControl.SetMonsterState(new DeadState(mMonsterControl), mGameObject, mCharacterController);
        }
    }
}

