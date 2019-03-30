using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStateShow:MonoBehaviour
{
    public Slider mHpSlider;
    public Slider mSpSlider;
    public Slider mMpSlider;

    public static float TempHp;
    public static float TempSp;
    public static float TempMp;
    private float Speed = 10.0f;
    private CanvasGroup mCanvasGroup;

    public static float HpLevel = 0;
    public static float MpLevel = 0;
    public static float SpLevel = 0;

    public Text BloodBottleCount;
    public GameObject BloodBottle;

    public Text Soul;
    public Text Ap;
    private static PlayerStateShow instance=null;

    public static PlayerStateShow Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        HpLevel = PlayerManager.Instance.BloodLevel;
        MpLevel = PlayerManager.Instance.MpLevel;
        SpLevel = PlayerManager.Instance.SpLevel;

        TempHp = PlayerManager.Instance.PlayerBlood;
        TempMp = PlayerManager.Instance.SkillBarMax;
        TempSp = PlayerManager.Instance.TempStrength;

        mCanvasGroup = this.GetComponent<CanvasGroup>();
        if (instance)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            DestroyImmediate(gameObject);
        }
        else if (SceneManager.GetActiveScene().name == "GameOver")
        {
            //this.gameObject.SetActive(false);
            DestroyImmediate(gameObject);
        }
        else
        {
            BloodBottleCount.text = PlayerManager.Instance.BloodBottleCount.ToString();
            if (BloodBottleCount.text=="0")
            {
                BloodBottleCount.text = "";
                BloodBottle.SetActive(false);
            }
            else
            {
                BloodBottle.SetActive(true);
            }

            //this.gameObject.SetActive(true);
            Soul.text = PlayerManager.Instance.Exp.ToString();
            //Ap.text = PlayerManager.Instance.SkillCount.ToString();
            if (GameCoreManager.Instance != null)
            {
                Ap.text = GameCoreManager.Instance.TowerCount.ToString();
            }
            else
            {
                Ap.text = "1";
            }



            if (HpLevel < PlayerManager.Instance.BloodLevel)
            {
                TempHp = PlayerManager.Instance.PlayerBlood;
                HpLevel = PlayerManager.Instance.BloodLevel;
            }

            if (MpLevel < PlayerManager.Instance.MpLevel)
            {
                TempMp = PlayerManager.Instance.SkillBarMax;
                MpLevel = PlayerManager.Instance.MpLevel;
            }

            if (SpLevel < PlayerManager.Instance.SpLevel)
            {
                TempSp = PlayerManager.Instance.TempStrength;
                SpLevel = PlayerManager.Instance.SpLevel;
            }

            mHpSlider.value = Mathf.Lerp(mHpSlider.value, PlayerManager.Instance.PlayerBlood / TempHp, Time.deltaTime * Speed);
            mSpSlider.value = Mathf.Lerp(mSpSlider.value, PlayerManager.Instance.PlayerStrength / TempSp, Time.deltaTime * Speed);
            mMpSlider.value = Mathf.Lerp(mMpSlider.value, PlayerManager.Instance.SkillBar / TempMp, Time.deltaTime * Speed);
            if (NpcManControl.isTalk == true)
            {
                if (mCanvasGroup.alpha < 0.0001f)
                {
                    mCanvasGroup.alpha = 0;
                }
                mCanvasGroup.alpha = Mathf.Lerp(mCanvasGroup.alpha, 0, Time.deltaTime * Speed);
                mCanvasGroup.blocksRaycasts = false;

            }
            else
            {
                if (mCanvasGroup.alpha > 0.9999f)
                {
                    mCanvasGroup.alpha = 1;
                }
                mCanvasGroup.alpha = Mathf.Lerp(mCanvasGroup.alpha, 1, Time.deltaTime * Speed);
                mCanvasGroup.blocksRaycasts = true;

            }
        }

       
    }

}
