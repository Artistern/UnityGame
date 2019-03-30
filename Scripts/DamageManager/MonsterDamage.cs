using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// 对怪物属性的定义以及操作
/// </summary>
public class MonsterDamage : DamageAndATK
{
    public float DefencePer = 0.16f;//设置减伤
    public int MagicValue = 200; //魔力值
    public int TempMagicValue; //保存的魔力值
    public int TempBlood; //保存最开始的血量
    public int Blood = 2000; //血量
    public int Strength = 100; //体力
    public int NormalAttackMin = 90; //最低伤害
    public int NormalAttackMax = 130; //最高伤害
    public int CritDamage = 120; //暴击伤害提升
    public int CritRate = 10; //暴击率
    public float AttackDistance = 2.0f; //攻击距离
    public bool IsPlayer = false;
    /// <summary>
    /// 灵魂数
    /// </summary>
    public float SoulCount;
    /// <summary>
    /// 玩家
    /// </summary>
    public GameObject mGameObject;
    public GameObject mGameObjectChild;
    public float MoveSpeed = 2.0f; //移动速度
    public float AttackSpeed = 1.5f; //攻击速度
    public float NeedHelp;
    private bool isNeed = false;
    private float RiseMagic;
    private bool TempBool = false;

    void Start()
    {
        TempMagicValue = MagicValue;
        TempBlood = Blood;
        NeedHelp = Blood * 0.2f;
        GameCoreManager.Instance.ResgisterList(this.gameObject);
        TempBool = false;
    }

    void Update()
    {
        RiseMagic += Time.deltaTime;
        if (Hurt!=0)
        {
            float temp = Hurt * (1 - DefencePer);
            Hurt = (int) temp;
            GameObject game = Instantiate(Resources.Load<GameObject>("GameObject"),this.transform);
            game.GetComponent<DamagePopup>().Value = Hurt;
            Blood = Blood - Hurt;
            Hurt = 0;
        }
        else if(Blood<=0)
        {
            TempBool = true;
            Blood = 0;
            isDead = true;
        }
        else
        {
            isDead = false;
        }
        if (Blood<=NeedHelp&& isNeed==false)
        {
            MonsterHelpManager.Instance.ResgisterList(this.gameObject.GetComponent<MonsterDamage>());//在这里注册一个血量低于20%的对象
            isNeed = true;
        }else if (Blood >= TempBlood)
        {
            MonsterHelpManager.Instance.RemoveList(this.gameObject.GetComponent<MonsterDamage>());//在这里删除一个血量高于20%的对象
            isNeed = false;
        }

        if (Blood>=TempBlood)
        {
            Blood = TempBlood;
        }

        //恢复魔力,简单版
        if (MagicValue != TempMagicValue&& RiseMagic>=2.0f)
        {
            MagicValue += 8;
            RiseMagic = 0;
        }

        if (TempBool==true)
        {
            GameCoreManager.Instance.RemoveList(this.gameObject);
            TempBool = false;
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            mGameObject = collider.gameObject;
            if (mGameObjectChild==null)
            {
                //Debug.Log("空");
                foreach (Transform o in collider.gameObject.transform)
                {
                    if (o.tag == "boby")
                    {
                        mGameObjectChild = o.gameObject;
                        break;
                    }
                }
            }           
            IsPlayer = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            IsPlayer = false;
        }
    }
}