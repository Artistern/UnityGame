using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class WitchCallMonsterState:IStateWicth
{
    public WitchCallMonsterState(WitchControl witchControl):base(witchControl)
    {

    }

    public override void StartState(GameObject gameObject, CharacterController characterController)
    {
        mGameObject = gameObject;
        mCharacterController = characterController;
    }

    public override void UpdateState()
    {
        
    }

    public override void EndState()
    {
        
    }
}

