using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;


public class NormalAttack:IBattle
{
    public NormalAttack(BattleControl battleControl):base(battleControl)
    {

    }
    public override void StartBattle(GameObject gameObject,CharacterController characterController)
    {
        mGameObject = gameObject;
        m_Timer = mGameObject.GetComponent<MonsterDamage>().AttackSpeed;      
        mCharacterController = characterController;
        AttackDistance= mGameObject.GetComponent<MonsterDamage>().AttackDistance;
        
    }

    public override void UpdateBattle()
    {
        m_Timer += Time.deltaTime;
        Vector3 target = mGameObject.GetComponent<MonsterDamage>().mGameObject.transform.position;
        target.y = mGameObject.transform.position.y;
        mGameObject.transform.LookAt(target);
        if (Vector3.Distance(mGameObject.transform.position, mGameObject.GetComponent<MonsterDamage>().mGameObjectChild.transform.position)<= mGameObject.GetComponent<MonsterDamage>().AttackDistance)
        {
            mGameObject.GetComponent<Animator>().SetBool("Walk", false);
            if (m_Timer > mGameObject.GetComponent<MonsterDamage>().AttackSpeed)
            {
                float x = Random.Range(0, 2);
                if (x==1.0f)
                {
                    mGameObject.GetComponent<Animator>().SetTrigger("NormalAttack");
                }
                else
                {
                    mGameObject.GetComponent<Animator>().SetTrigger("SecondAttack");
                }

               
                m_Timer = 0;
            }
        }
        else
        {
            mGameObject.GetComponent<Animator>().SetBool("Walk", true);
            if (mGameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Run"))
            {
                mCharacterController.SimpleMove(mGameObject.transform.forward * mGameObject.GetComponent<MonsterDamage>().MoveSpeed);
            }                  
        }
       
    }

    public override void EndBattle()
    {
        
        
    }
}
