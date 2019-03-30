using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UnityEngine;


public class PlayerDamage:DamageAndATK
{
    void Update()
    {
        //显示受击伤害
        if (Hurt!=0)
        {
            GameObject mGameObject = GameObject.Instantiate(Resources.Load<GameObject>("GameObject"),transform);
            mGameObject.GetComponent<DamagePopup>().Value = Hurt;
            PlayerManager.Instance.PlayerBlood = PlayerManager.Instance.PlayerBlood - Hurt;
            Hurt = 0;
        }
        else if(PlayerManager.Instance.PlayerBlood<=0)
        {
            //Debug.Log("玩家死亡");
            isDead = true;
        }
        else
        {
            isDead = false;
        }
    }
}
