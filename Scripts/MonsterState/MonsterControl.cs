using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class MonsterControl
{
    private IStateMonster mIStateMonster;
    /// <summary>
    /// 设置状态切换的方法
    /// </summary>
    public void SetMonsterState(IStateMonster IsceneState,GameObject gameObject,CharacterController characterController)
    {
        mIStateMonster = IsceneState;
        mIStateMonster.StartState(gameObject,characterController);
    }
    /// <summary>
    /// 设置状态更新，并且检查条件
    /// </summary>
    public void SetMonsterUpdate()
    {
        mIStateMonster.UpdateState();
    }
}

