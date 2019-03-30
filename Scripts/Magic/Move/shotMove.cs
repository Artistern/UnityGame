using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class shotMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float MoveSpeed = 10.0f;
    private GameObject Monster;

    private Vector3 Target;

    public void setSpeed(float Speed)
    {
        MoveSpeed = Speed;
    }

    void Start()
    {
        Target = PlayerManager.Instance.mPlayer.transform.position;
        this.transform.LookAt(Target);
        //Debug.Log(Monster.name);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime* MoveSpeed);
        StartCoroutine(DestoryThis());
    }

     public void SetGameObject(GameObject mGameObject)
    {
        Monster = mGameObject;
    }

    IEnumerator DestoryThis()
    {
       yield return new WaitForSeconds(10);
       Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag=="Player")
        {
            // Debug.Log("触碰到");
            GameObject.Instantiate(Resources.Load<GameObject>("MagicSwordHitRed"), Monster.GetComponent<MonsterDamage>().mGameObjectChild.transform.position+Vector3.up,Quaternion.identity);
            Monster.GetComponent<MonsterDamage>().mGameObjectChild.GetComponent<PlayerDamage>().SetDamage();
            BaseCalc mBaseCalc = new FirstCalcMethod();//后期可以从这里改变伤害的计算方法
            Monster.GetComponent<MonsterDamage>().mGameObjectChild.GetComponent<PlayerDamage>().GetDamage(mBaseCalc.DamageCalc(Monster.GetComponent<MonsterDamage>().NormalAttackMax, Monster.GetComponent<MonsterDamage>().NormalAttackMin, Monster.GetComponent<MonsterDamage>().CritDamage, Monster.GetComponent<MonsterDamage>().CritRate));
            Destroy(this.gameObject);
        }
    }
}
