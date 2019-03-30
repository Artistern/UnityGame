using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;


public class WitchDeadState:IStateWicth
{
    private bool isDead = false;
    public WitchDeadState(WitchControl monsterControl) : base(monsterControl)
    {

    }

    public override void StartState(GameObject gameObject, CharacterController characterController)
    {
        mGameObject = gameObject;
        mCharacterController = characterController;
    }

    public override void UpdateState()
    {
        if (isDead == false)
        {
            MonsterHelpManager.Instance.RemoveMonsterList(mGameObject);
            MonsterHelpManager.Instance.RemoveList(mGameObject.GetComponent<MonsterDamage>());
            mGameObject.GetComponent<Animator>().SetTrigger("Dead");
            mCharacterController.enabled = false;
            PlayerManager.Instance.Exp += (int)Random.Range(mGameObject.GetComponent<MonsterDamage>().SoulCount - 10, mGameObject.GetComponent<MonsterDamage>().SoulCount + 10);
            isDead = true;
        }
    }

    public override void EndState()
    {
        Debug.Log("结束");
    }
}

