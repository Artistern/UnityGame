using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DamageAndATK : MonoBehaviour
{
    protected  Animator mAnimator;

    protected int Hurt = 0;

    protected bool isDead = false;

    void Awake()
    {
        mAnimator = this.GetComponent<Animator>();
    }

    //void Start()
    //{
    //    mAnimator = this.GetComponent<Animator>();
    //}

    /// <summary>
    /// 设置伤害动作
    /// </summary>
    public void SetDamage()
    {
        if (mAnimator.GetCurrentAnimatorStateInfo(0).IsName("COMBOATTACK01"))
        {

        }
        else
        {
            mAnimator.SetTrigger("Damage");
        }

        
    }
    /// <summary>
    /// 得到伤害的方法
    /// </summary>
    /// <param name="Damage"></param>
    public void GetDamage(int Damage)
    {
        Hurt = Damage;
    }
    /// <summary>
    /// 得到是否死亡的消息
    /// </summary>
    /// <returns></returns>
    public bool GetIsDead()
    {
        return isDead;
    }
}
