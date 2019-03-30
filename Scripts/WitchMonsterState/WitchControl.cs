using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class WitchControl
{
    private IStateWicth mIStateWicth;
    /// <summary>
    /// 设置状态切换的方法
    /// </summary>
    public void SetMonsterState(IStateWicth IstateWicth, GameObject gameObject, CharacterController characterController)
    {
        mIStateWicth = IstateWicth;
        mIStateWicth.StartState(gameObject, characterController);
    }
    /// <summary>
    /// 设置状态更新，并且检查条件
    /// </summary>
    public void SetMonsterUpdate()
    {
        mIStateWicth.UpdateState();
    }
}

