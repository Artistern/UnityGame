using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class IStateMonster:MonoBehaviour
{
    protected MonsterControl mMonsterControl;
    protected GameObject mGameObject;
    protected CharacterController mCharacterController;
    protected float Girvate = 10.0f;
    protected Vector3 Target = Vector3.zero;
    protected Vector3 mTarget=Vector3.zero;
    protected Vector3 Temp=Vector3.zero;
    protected Vector3 TargetPos = Vector3.zero;
    protected Vector3 targerMov=Vector3.zero;
    protected float Radiu = 4.0f;
    protected float m_Timer = 0;
    protected float FixLookDistance;
    protected BattleControl mBattleControl;

    public IStateMonster(MonsterControl monsterControl)
    {
        mMonsterControl = monsterControl;
    }

    /// <summary>
    /// 设置开始状态
    /// </summary>
    public virtual void StartState(GameObject gameObject,CharacterController characterController)
    {

    }
    /// <summary>
    /// 设置更新状态
    /// </summary>
    public virtual void UpdateState()
    {

    }
    /// <summary>
    /// 状态结束的操作
    /// </summary>
    public virtual void EndState()
    {

    }
}

