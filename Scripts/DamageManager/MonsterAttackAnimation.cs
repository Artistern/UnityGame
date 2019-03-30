using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 怪物攻击动画，击中效果，以及伤害的传递
/// </summary>
public class MonsterAttackAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AttackA()
    {
        GameObject g = Resources.Load<GameObject>("MagicShot/Sphere");
        g = GameObject.Instantiate(g, this.gameObject.transform.position + Vector3.up + Vector3.forward, Quaternion.identity);
        g.GetComponent<shotMove>().setSpeed(30f);
        g.GetComponent<shotMove>().SetGameObject(this.gameObject);

    }

    void NormalAttack()
    {
        //Debug.Log(PlayerCheck.mGameObject.name);
        if (Vector3.Distance(this.transform.position, this.GetComponent<MonsterDamage>().mGameObjectChild.transform.position)<this.GetComponent<MonsterDamage>().AttackDistance)
        {
            if (!this.GetComponent<MonsterDamage>().mGameObjectChild.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0)
                .IsName("StartAttack"))
            {
                GameObject.Instantiate(Resources.Load<GameObject>("HitMonster"), this.GetComponent<MonsterDamage>().mGameObjectChild.transform.position+Vector3.up,Quaternion.identity

                    );
                this.GetComponent<MonsterDamage>().mGameObjectChild.GetComponent<PlayerDamage>().SetDamage();
                BaseCalc mBaseCalc=new FirstCalcMethod();//后期可以从这里改变伤害的计算方法
                this.GetComponent<MonsterDamage>().mGameObjectChild.GetComponent<PlayerDamage>().GetDamage(mBaseCalc.DamageCalc(this.GetComponent<MonsterDamage>().NormalAttackMax, this.GetComponent<MonsterDamage>().NormalAttackMin, this.GetComponent<MonsterDamage>().CritDamage, this.GetComponent<MonsterDamage>().CritRate));
            }
        }     
    }
    void ReStore()
    {
        //Debug.Log("测试");
        if (MonsterHelpManager.Instance.mMonsterDamageList.Count!=0&&this.GetComponent<MonsterDamage>().MagicValue>=20)
        {
            GameObject.Instantiate(Resources.Load<GameObject>("BasicZoneGreen"), MonsterHelpManager.Instance.mMonsterDamageList[0].transform.position+Vector3.up*0.5f,Quaternion.identity);
            //GameObject.Instantiate(Resources.Load<GameObject>("ReStore"),
                //MonsterHelpManager.Instance.mMonsterDamageList[0].gameObject.transform, false);
                GameObject mGameObject = Resources.Load<GameObject>("ReStore");
                float temp = Random.Range(0.1f, 0.3f);
                mGameObject.GetComponent<ReStorePopup>().Value = (int)(MonsterHelpManager.Instance.mMonsterDamageList[0].GetComponent<MonsterDamage>().TempBlood *
                                                                       temp); ;
                GameObject.Instantiate(mGameObject, MonsterHelpManager.Instance.mMonsterDamageList[0].transform.position + Vector3.up * 0.5f, Quaternion.identity);
                MonsterHelpManager.Instance.mMonsterDamageList[0].GetComponent<MonsterDamage>().Blood +=
                    (int) (MonsterHelpManager.Instance.mMonsterDamageList[0].GetComponent<MonsterDamage>().TempBlood *
                           temp); //加血
                this.GetComponent<MonsterDamage>().MagicValue -= 20;
        }
    }
}
