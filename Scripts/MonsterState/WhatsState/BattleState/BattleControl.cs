using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class BattleControl
{
    private IBattle mIBattle;

    public void SetBattleState(IBattle Ibattle,GameObject gameObject,CharacterController characterController)
    {
        mIBattle = Ibattle;
        mIBattle.StartBattle(gameObject,characterController);
    }
    public void UpdateBattleState()
    {
        mIBattle.UpdateBattle();
    }
}
