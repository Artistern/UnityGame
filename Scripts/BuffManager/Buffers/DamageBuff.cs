using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class DamageBuff:BuffManager
{
    private float Max;
    private float Min;
    public DamageBuff(float temp):base(30.0f,temp,"增伤：伤害提升20%")
    {
        //GameObject mGameObject = GameObject.Instantiate(Resources.Load<GameObject>("ChestAppearYellow"),PlayerManager.Instance.mPlayer.transform.position+Vector3.down,Quaternion.identity);
        Max = PlayerManager.Instance.AttackMax;
        Min = PlayerManager.Instance.AttackMin;
        PlayerManager.Instance.AttackMax += PlayerManager.Instance.AttackMax * 0.2f;
        PlayerManager.Instance.AttackMin += PlayerManager.Instance.AttackMin * 0.2f;
        GameObject mBuffShow = GameObject.Instantiate(Resources.Load<GameObject>("BuffStartShow"),
            PlayerManager.Instance.mPlayer.transform.position+Vector3.down, Quaternion.identity);
        mBuffShow.GetComponent<BuffShow>().Value = Content;
    }

    public override void SendMessage(float x)
    {
        if (x>=AwakeTimer+Temp)
        {
            isStateOver = true;
        }

        if (x>=(AwakeTimer + Temp)*1.5)
        {
            isOver = true;
        }
    }

    public override void DeleBuff()
    {
        PlayerManager.Instance.AttackMax = Max;
        PlayerManager.Instance.AttackMin = Min;
        if (isEndShow==false)
        {
            GameObject mBuffShow = GameObject.Instantiate(Resources.Load<GameObject>("BuffStartShow"),
                PlayerManager.Instance.mPlayer.transform.position + Vector3.down, Quaternion.identity);
            mBuffShow.GetComponent<BuffShow>().Value = "增伤：退出";
            isEndShow = true;
        }
    }
}

