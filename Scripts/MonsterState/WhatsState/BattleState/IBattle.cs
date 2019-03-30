using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class IBattle : MonoBehaviour
{
    protected BattleControl mBattleControl;
    protected GameObject mGameObject;
    protected CharacterController mCharacterController;
    protected float AttackDistance = 0;
    protected float m_Timer=0;

    public IBattle(BattleControl battleControl)
    {
        mBattleControl = battleControl;
    }
    /// <summary>
    /// 战斗开始的初始化
    /// </summary>
    public virtual void StartBattle(GameObject gameObject,CharacterController characterController)
    {

    }
    /// <summary>
    /// 战斗更新
    /// </summary>
    public virtual void UpdateBattle()
    {

    }
    /// <summary>
    /// 战斗结束的判断
    /// </summary>
    public virtual void EndBattle()
    {

    }
}
