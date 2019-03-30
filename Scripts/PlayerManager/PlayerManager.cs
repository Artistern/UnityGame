using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 这个是玩家的基本数值
/// </summary>
public class PlayerManager : MonoBehaviour
{
    public GameObject mPlayer;
    public float TempStrength;
    private float T_timer = 0;
    private GameObject mGameObject=null;
    private static PlayerManager instance = null;

    public static PlayerManager Instance
    {
        get { return instance; }
    }


    void Awake()
    {
        TempStrength = PlayerStrength;
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        mPlayer=GameObject.FindWithTag("Player");
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    /// <summary>
    /// 血量等级
    /// </summary>
    public float BloodLevel = 0;
    /// <summary>
    /// 体力等级
    /// </summary>
    public float SpLevel = 0;
    /// <summary>
    /// 魔力等级
    /// </summary>
    public float MpLevel = 0;
    /// <summary>
    /// 定义玩家的血量
    /// </summary>
    public float PlayerBlood = 1200;
    /// <summary>
    /// 定义玩家的体力
    /// </summary>
    public float PlayerStrength = 100;
    /// <summary>
    /// 定义技能槽
    /// </summary>
    public float SkillBar = 0;
    /// <summary>
    /// 技能槽最大值
    /// </summary>
    public float SkillBarMax = 100;
    /// <summary>
    /// 普通攻击消耗的气力值
    /// </summary>
    public float NormalAttackStrength = 30;
    /// <summary>
    /// 重击消耗体力值
    /// </summary>
    public float SpecialAttackStrength = 40;
    /// <summary>
    /// 跳劈消耗气力值
    /// </summary>
    public float JumpAttackStrength = 50;
    /// <summary>
    /// 奔跑消耗气力值
    /// </summary>
    public float RunStrengthCut = 10;
    /// <summary>
    /// 每秒恢复的气力值
    /// </summary>
    public float StengthRestore = 30;
    /// <summary>
    /// 防御值
    /// </summary>
    public float Defense = 0;
    /// <summary>
    /// 攻击最小值
    /// </summary>
    public float AttackMin = 91;
    /// <summary>
    /// 攻击最大值
    /// </summary>
    public float AttackMax = 104;
    /// <summary>
    /// 暴击率
    /// </summary>
    public float Crit_Rate = 5;
    /// <summary>
    /// 暴击伤害
    /// </summary>
    public float CritDamage = 150;
    /// <summary>
    /// 每次攻击都会回收一定的怒气值
    /// </summary>
    public float AttackRiseSkill = 20;
    /// <summary>
    /// 获得的经验值
    /// </summary>
    public float Exp = 0;
    /// <summary>
    /// 技能点
    /// </summary>
    public float SkillCount = 0;

    /// <summary>
    /// 血瓶数量
    /// </summary>
    public float BloodBottleCount = 0;

    public bool isRecall = false;
    private CanvasGroup mCanvasGroup;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SkillBar>=SkillBarMax)
        {
            SkillBar = SkillBarMax;
        }
        else if(SkillBar<=0)
        {
            SkillBar = 0;
        }

        //T_timer += Time.deltaTime;
        if (PlayerStrength< TempStrength)
        {
            PlayerStrength = Mathf.Lerp(PlayerStrength, PlayerStrength + StengthRestore, 2.0f*Time.deltaTime);
            //PlayerStrength += StengthRestore;
            // T_timer = 0;
        }

        if (PlayerStrength < 0)
        {
            PlayerStrength = 0;
        }else if (PlayerStrength>=TempStrength)
        {
            PlayerStrength = TempStrength;
        }

        if (mPlayer==null)
        {
            mPlayer = GameObject.FindWithTag("Player");
        }
        if (PlayerBlood<=0)
        {
            if (mGameObject==null)
            {
                mGameObject= GameObject.Instantiate(Resources.Load<GameObject>("GameOver/Dead"));
                mCanvasGroup = mGameObject.GetComponent<CanvasGroup>();
                mCanvasGroup.alpha = 0;
            }
            PlayerBlood = 0;
            mCanvasGroup.alpha = Mathf.Lerp(mCanvasGroup.alpha, 1, 2.5f*Time.deltaTime);
            if (mCanvasGroup.alpha > 0.999)
            {
                mCanvasGroup.alpha = 1;
                //Debug.Log("传递");
                isRecall = true;
            }
        }
        else
        {
            isRecall = false;
            if (mGameObject != null)
            {
                Destroy(mGameObject);
            }
        }
    }
}
