using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;


public class DeadState:IStateMonster
{
    private bool isDead = false;
    public DeadState(MonsterControl monsterControl):base(monsterControl)
    {

    }

    public override void StartState(GameObject gameObject, CharacterController characterController)
    {
        mGameObject = gameObject;
        mCharacterController = characterController;
    }

    public override void UpdateState()
    {
        if (isDead==false)
        {
            MonsterHelpManager.Instance.RemoveList(mGameObject.GetComponent<MonsterDamage>());
            mGameObject.GetComponent<Animator>().SetTrigger("Dead");
            PlayerManager.Instance.Exp += (int)Random.Range(mGameObject.GetComponent<MonsterDamage>().SoulCount-10, mGameObject.GetComponent<MonsterDamage>().SoulCount+10);
            mCharacterController.enabled = false;
            isDead = true;
        }
    }

    public override void EndState()
    {
        
    }
}

