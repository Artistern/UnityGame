using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeveUp : MonoBehaviour
{
    public Text Ap;
    public Text RealHp;
    public Text MaxHp;
    public Text RealSp;
    public Text MaxSp;
    public Text RealMp;
    public Text MaxMp;

    public Text Hp;
    public Text Mp;
    public Text Sp;

    private float SkillCount;
    private float HpLevel;
    private float MpLevel;
    private float SpLevel;

    private float TempHp;
    private float TempMp;
    private float TempSp;
    private float TempAp;
    void Start()
    {
        SkillCount = PlayerManager.Instance.SkillCount;
        HpLevel = PlayerManager.Instance.BloodLevel;
        MpLevel = PlayerManager.Instance.MpLevel;
        SpLevel = PlayerManager.Instance.SpLevel;

        TempHp = HpLevel;
        TempMp = MpLevel;
        TempSp = SpLevel;
        TempAp = SkillCount;

        Hp.text = TempHp.ToString();
        Mp.text = TempMp.ToString();
        Sp.text = TempSp.ToString();
    }
    void Update()
    {
        Ap.text = TempAp.ToString();
        RealHp.text = PlayerManager.Instance.PlayerBlood.ToString();
        MaxHp.text = PlayerStateShow.TempHp.ToString();
        RealSp.text = PlayerManager.Instance.PlayerStrength.ToString();
        MaxSp.text = PlayerStateShow.TempSp.ToString();
        RealMp.text = PlayerManager.Instance.SkillBarMax.ToString();
        MaxMp.text = PlayerStateShow.TempMp.ToString();

        //Hp.text = PlayerManager.Instance.BloodLevel.ToString();
        //Mp.text = PlayerManager.Instance.MpLevel.ToString();
        //Sp.text = PlayerManager.Instance.SpLevel.ToString();
    }

    /// <summary>
    /// 升级血量
    /// </summary>
    public void ClickToUpHp()
    {
        if (TempHp < 4&& TempAp >= 1)
        {
            TempHp += 1;
            Hp.text = TempHp.ToString();
            //PlayerManager.Instance.BloodLevel += 1;
            //PlayerManager.Instance.PlayerBlood =
            //    PlayerManager.Instance.PlayerBlood + PlayerManager.Instance.BloodLevel * 300;
            TempAp -= 1;
            //PlayerManager.Instance.SkillCount -= 1;
        }
    }
    /// <summary>
    /// 升级技能值
    /// </summary>
    public void ClickToUpMp()
    {
        if (TempMp < 4 && TempAp >= 1)
        {
            TempMp += 1;
            Mp.text = TempMp.ToString();
            //PlayerManager.Instance.MpLevel += 1;
            //PlayerManager.Instance.SkillBarMax =
            //    PlayerManager.Instance.SkillBarMax + PlayerManager.Instance.MpLevel * 5;
            TempAp -= 1;
            //PlayerManager.Instance.SkillCount -= 1;
        }
    }
    /// <summary>
    /// 升级体力值
    /// </summary>
    public void ClickToUpSp()
    {
        if (TempSp< 4 && TempAp >= 1)
        {
            TempSp += 1;
            Sp.text = TempSp.ToString();
            //PlayerManager.Instance.SpLevel += 1;
            //PlayerManager.Instance.TempStrength =
            //    PlayerManager.Instance.TempStrength + PlayerManager.Instance.SpLevel * 3;
            TempAp -= 1;
            //PlayerManager.Instance.SkillCount -= 1;
        }
    }
    /// <summary>
    /// 应用技能点
    /// </summary>
    public void ButtonClick()
    {
        SkillCount = TempAp;
        HpLevel = TempHp;
        MpLevel = TempMp;
        SpLevel = TempSp;
        PlayerManager.Instance.SkillCount =SkillCount;
        if (TempHp!= PlayerManager.Instance.BloodLevel)
        {
            PlayerManager.Instance.BloodLevel = TempHp;
            PlayerManager.Instance.PlayerBlood =
                // PlayerStateShow.TempHp + PlayerManager.Instance.BloodLevel * 300;
                //PlayerStateShow.TempHp + 300;
                1200 + 300 * PlayerManager.Instance.BloodLevel;
        }

        if (TempMp!= PlayerManager.Instance.MpLevel)
        {
            PlayerManager.Instance.MpLevel = TempMp;
            PlayerManager.Instance.SkillBarMax =
                //PlayerManager.Instance.SkillBarMax + PlayerManager.Instance.MpLevel * 5;
                //PlayerManager.Instance.SkillBarMax + 5;
                80 + 5 * PlayerManager.Instance.MpLevel;
        }

        if (TempSp!= PlayerManager.Instance.SpLevel)
        {
            PlayerManager.Instance.SpLevel = TempSp;
            PlayerManager.Instance.TempStrength =
                //PlayerManager.Instance.TempStrength + PlayerManager.Instance.SpLevel * 3;
                //PlayerManager.Instance.TempStrength + 3;
                100 + 3 * PlayerManager.Instance.SpLevel;
        }
    }

    public void DeleteClick()
    {
        TempAp = SkillCount;
        //PlayerManager.Instance.SkillCount = SkillCount;
        TempHp = HpLevel;
        Hp.text = TempHp.ToString();

        TempMp = MpLevel;
        Mp.text = TempMp.ToString();

        TempSp = SpLevel;
        Sp.text = TempSp.ToString();
    }

    /// <summary>
    /// 关闭窗口
    /// </summary>
    public void Cancel()
    {
        LevelUpNpc.isSpeak = false;
        Destroy(this.gameObject);
    }
}
