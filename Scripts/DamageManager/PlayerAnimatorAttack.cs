using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 关于角色攻击的动画以及判定
/// </summary>
public class PlayerAnimatorAttack : MonoBehaviour
{
    private Animator mAnimator=null;
    public float AttackTime = 1.0f;
    private BoxCollider mBoxCollider;

    /// <summary>
    /// 攻击距离
    /// </summary>
    public float AttackDistance = 2.0f;

    private float Temp = 0;
    public float SpecialAttackTimer = 3.0f;
    private float T_timer = 0;
    private IDamage mIDamage;
    public float SkillCut = 80;
    //动画状态信息
    private AnimatorStateInfo mStateInfo;
    //定义状态常量值，前面不要带层名啊，否则无法判断动画状态
    private const string IdleState = "Idle";
    private const string WalkState = "Run";
    private const string Attack1State = "Attack1";
    private const string Attack2State = "Attack2";
    private const string Attack3State = "Attack3";
    private float TempCirt = 0;

    //定义玩家连击次数
    private int mHitCount = 0;

    private int TempCount;
    private float TempTimer = 0;

    void Awake()
    {
        mBoxCollider = this.GetComponent<BoxCollider>();
        mBoxCollider.enabled = false;
        Temp = AttackTime;
        T_timer = SpecialAttackTimer;
        TempCount = 0;
        mHitCount = 0;
        //获取动画组件
        mAnimator = GetComponent<Animator>();
        //获取状态信息
        mStateInfo = mAnimator.GetCurrentAnimatorStateInfo(0);

        TempTimer = 0.018f;
    }
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R)&&PlayerManager.Instance.BloodBottleCount>0)
        {
            PlayerManager.Instance.BloodBottleCount -= 1;
            PlayerManager.Instance.PlayerBlood += PlayerStateShow.TempHp*0.5f;
        }

        mStateInfo = mAnimator.GetCurrentAnimatorStateInfo(0);
        //如果玩家处于攻击状态，且攻击已经完成，则返回到Idle状态
        if (!(mStateInfo.IsName(IdleState)||mStateInfo.IsName(WalkState)))
        {
            if ((Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D))&&mStateInfo.normalizedTime>=0.8f)
            {
                mAnimator.SetInteger("ActionID", 0);
                mHitCount = 0;
            }else if (mStateInfo.normalizedTime >= 1.0f)
            {
                mAnimator.SetInteger("ActionID", 0);
                mHitCount = 0;
            }
            else if(mStateInfo.IsName("Damage"))
            {
                mAnimator.SetInteger("ActionID", 0);
                mHitCount = 0;
            }
        }
        if (NpcManControl.isTalk==false)
        {
            if (LevelUpNpc.isSpeak==false)
            {
                //如果按下鼠标左键，则开始攻击
                if (Input.GetMouseButtonDown(0) && PlayerManager.Instance.PlayerStrength >= 0)
                {

                    Attack();
                }

                if (mStateInfo.IsName(WalkState) || mStateInfo.IsName(IdleState))
                {
                    if (Input.GetKeyDown(KeyCode.Q) && PlayerManager.Instance.SkillBar >= PlayerManager.Instance.SpecialAttackStrength)
                    {
                        mAnimator.SetTrigger("ComboaAttack");
                    }
                }
            }
        }

        if ((PlayerManager.Instance.PlayerBlood<=0)&&(TempCount == 0))
        {
            TempCount = TempCount + 1;
            mAnimator.SetTrigger("Dead");
        }
    }

    void Attack()
    {
        //获取状态信息
        mStateInfo = mAnimator.GetCurrentAnimatorStateInfo(0);

        //如果玩家处于Idle状态且攻击次数为0，则玩家按照攻击招式1攻击，否则按照攻击招式2攻击，否则按照攻击招式3攻击
        if (mHitCount == 0&&!mStateInfo.IsName("Damage"))
        {
            mAnimator.SetInteger("ActionID", 1);
            if (PlayerManager.Instance.PlayerStrength < PlayerManager.Instance.NormalAttackStrength)
            {
                return;
            }
            mHitCount = 1;
            //mAnimator.SetTrigger("StartAttack");

        }
        else if (mStateInfo.IsName(Attack1State) && mHitCount == 1 && mStateInfo.normalizedTime >= 0.3F&&!mStateInfo.IsName("Damage") )
        {
            mAnimator.SetInteger("ActionID", 2);
            //mAnimator.SetTrigger("SecondAttack");
            if (PlayerManager.Instance.PlayerStrength < PlayerManager.Instance.NormalAttackStrength)
            {
                return;
            }
            mHitCount = 2;

        }
        else if (mStateInfo.IsName(Attack2State) && mHitCount == 2 && mStateInfo.normalizedTime >= 0.4F && !mStateInfo.IsName("Damage"))
        { 
            mAnimator.SetInteger("ActionID", 3);
            //mAnimator.SetTrigger("ThirdAttack");
            if (PlayerManager.Instance.PlayerStrength < PlayerManager.Instance.NormalAttackStrength)
            {
                return;
            }
            mHitCount = 3;
        }
    }

    /// <summary>
    /// 在这里普通攻击会使用到（开始）
    /// </summary>
    void NormalAttack()
    {
        PlayerManager.Instance.PlayerStrength -= PlayerManager.Instance.NormalAttackStrength;
        mBoxCollider.size=new Vector3(AttackDistance,1, AttackDistance);
        mBoxCollider.enabled = true;
        mIDamage = new BaseDamage();      ;
       
    }
    /// <summary>
    /// 在这里普通攻击结束
    /// </summary>
    void NormalAttackEnd()
    {
        mBoxCollider.enabled = false;
    }

    void SecondAttackStart()
    {
       
        mBoxCollider.size = new Vector3(AttackDistance, 1, AttackDistance);
        mBoxCollider.enabled = true;
        mIDamage = new BaseDamage();
        PlayerManager.Instance.Crit_Rate = 100; 
    }

    void SecondAttackEnd()
    {
        mBoxCollider.enabled = false;
       
    }
    void ThirdAttackStart()
    {
        mBoxCollider.size = new Vector3(AttackDistance, 1, AttackDistance);
        mBoxCollider.enabled = true;
        mIDamage = new BaseDamage();
        PlayerManager.Instance.Crit_Rate = 100;
    }

    void ThirdAttackEnd()
    {
        mBoxCollider.enabled = false;
    }
    void ForthAttackStart()
    {
       
        mBoxCollider.size = new Vector3(AttackDistance, 1, AttackDistance);
        mBoxCollider.enabled = true;
        mIDamage = new BaseDamage();
        PlayerManager.Instance.Crit_Rate = 100;
    }

    void ForthAttackEnd()
    {
        mBoxCollider.enabled = false;
        PlayerManager.Instance.Crit_Rate = TempCirt;
    }
    void FirstAttackStart()
    {
        PlayerManager.Instance.SkillBar -= PlayerManager.Instance.SpecialAttackStrength;
        mBoxCollider.size = new Vector3(AttackDistance, 1, AttackDistance);
        mBoxCollider.enabled = true;
        mIDamage = new BaseDamage();
        TempCirt = PlayerManager.Instance.Crit_Rate;
        PlayerManager.Instance.Crit_Rate = 100;

    }

    void FirstAttackEnd()
    {
        mBoxCollider.enabled = false;
    }
    /// <summary>
    /// 这里可以算所有触发攻击的效果
    /// </summary>
    /// <param name="collider"></param>
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag=="Monster")
        {
            int x = mIDamage.Calculate_Damage(PlayerManager.Instance.AttackMin, PlayerManager.Instance.AttackMax,
                PlayerManager.Instance.Crit_Rate, PlayerManager.Instance.CritDamage);
            PlayerManager.Instance.SkillBar += PlayerManager.Instance.AttackRiseSkill;
            collider.GetComponent<DamageAndATK>().SetDamage();
            collider.GetComponent<DamageAndATK>().GetDamage(x);
            //GameObject.Instantiate(Resources.Load<GameObject>("HitMonster"), collider.transform, false);
            GameObject.Instantiate(Resources.Load<GameObject>("HitMonster"), collider.transform.position+Vector3.up,
                Quaternion.identity);
        }
    }
}
