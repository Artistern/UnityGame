using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Automatic_Patrol_Witch:IStateWicth
{
    public Automatic_Patrol_Witch(WitchControl monsterControl) : base(monsterControl)
    {

    }

    /// <summary>
    /// 移动状态开始初始化
    /// </summary>
    public override void StartState(GameObject gameObject, CharacterController characterController)
    {
        FixLookDistance = 0;
        TargetPos = Vector3.zero;
        m_Timer = 0;
        mGameObject = gameObject;
        mCharacterController = characterController;
        targerMov = mGameObject.transform.position;
    }
    /// <summary>
    /// 移动状态更新
    /// </summary>
    public override void UpdateState()
    {
        if (!mCharacterController.isGrounded)
        {
            Target.y -= Girvate * Time.deltaTime;
            Temp = mGameObject.transform.position;
            mTarget = Temp;
        }
        else
        {
            if (targerMov.x == mGameObject.transform.position.x && targerMov.z == mGameObject.transform.position.z)
            {
                float x = Random.Range(mTarget.x - Radiu, mTarget.x + Radiu);
                float y = Random.Range(mTarget.z - Radiu, mTarget.z + Radiu);

                TargetPos = new Vector3(x, mGameObject.transform.position.y, y);

                mGameObject.transform.LookAt(TargetPos);
            }

            if (TargetPos != Vector3.zero)
            {
                if (Vector3.Distance(TargetPos, mGameObject.transform.position) > 0.5f)//这里是开始行走的过程
                {
                    if (FixLookDistance < Vector3.Distance(TargetPos, mGameObject.transform.position))
                    {
                        mGameObject.transform.LookAt(TargetPos);
                    }
                    mGameObject.GetComponent<Animator>().SetBool("Walk", true);
                    mCharacterController.SimpleMove(mGameObject.transform.forward * mGameObject.GetComponent<MonsterDamage>().MoveSpeed);
                    FixLookDistance = Vector3.Distance(TargetPos, mGameObject.transform.position);
                }
                else//这里是结束行走的过程
                {
                    mGameObject.GetComponent<Animator>().SetBool("Walk", false);
                    targerMov = mGameObject.transform.position;
                    TargetPos = Vector3.zero;
                    //EndState();
                    mMonsterControl.SetMonsterState(new WitchStand(mMonsterControl), mGameObject, mCharacterController);
                }
            }

        }
        //Debug.Log(PlayerCheck.IsPlayer);
        if (mGameObject.GetComponent<MonsterDamage>().IsPlayer&&PlayerManager.Instance.PlayerBlood>0)
        {
            mGameObject.GetComponent<Animator>().SetBool("Walk", true);
            mMonsterControl.SetMonsterState(new WitchBattleState(mMonsterControl), mGameObject, mCharacterController);
        }

        if (mGameObject.GetComponent<MonsterDamage>().Blood <= 0)//如果自身死亡，就指向死亡状态
        {
            mMonsterControl.SetMonsterState(new WitchDeadState(mMonsterControl), mGameObject, mCharacterController);
        }
        if (MonsterHelpManager.Instance.mMonsterDamageList.Count > 0)
        {
            mMonsterControl.SetMonsterState(new WitchOutBattleRestore(mMonsterControl), mGameObject, mCharacterController);
        }
    }
    public override void EndState()
    {
        Debug.Log("结束");
    }
}
