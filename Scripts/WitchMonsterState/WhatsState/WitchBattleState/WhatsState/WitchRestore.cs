using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class WitchRestore:IWitchBattle
{
    public WitchRestore(WitchBattleControl battleControl) : base(battleControl)
    {

    }

    public override void StartBattle(GameObject gameObject, CharacterController characterController)
    {
        mGameObject = gameObject;
        mCharacterController = characterController;
    }

    public override void UpdateBattle()
    {
        mGameObject.GetComponent<Animator>().SetTrigger("Buff");
        if (MonsterHelpManager.Instance.mMonsterDamageList.Count == 0)
        {
            mBattleControl.SetBattleState(new WitchNormalAttack(mBattleControl), mGameObject, mCharacterController);
            return;
        }
        mGameObject.transform.LookAt(MonsterHelpManager.Instance.mMonsterDamageList[0].gameObject.transform);
    }

    public override void EndBattle()
    {
       
    }
}

