using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager: MonoBehaviour
{
    public EnemySpawn[] MonsterSpawnArray;
    public EnemySpawn[] BossSpawnArray;

    public List<GameObject> enemyList = new List<GameObject>();

    public static SpawnManager _instance;

    //private Text GameOver;
    public GameObject GameOver;

    private GameObject BossBlood;
    //private float Count = 0;

    //public static bool isClear = false;

    //private float temp = 0;

    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        BossBlood = GameObject.FindGameObjectWithTag("BossBlood");
        BossBlood.SetActive(false);
        StartCoroutine(SpwanEnemy());
        //GameOver = GameObject.FindGameObjectWithTag("GameOver").GetComponentInChildren<Text>();
    }

    private void Update()
    {
        if (enemyList.Count != 0)
        {
            //foreach (GameObject s in enemyList)
            //{
            //    if (s.activeSelf == false)
            //    {
            //        enemyList.Remove(s);
            //    }
            //}
            for (int i=0;i<enemyList.Count;i++)
            {
                if (enemyList[i].activeSelf==false)
                {
                    Destroy(enemyList[i]);
                    enemyList.Remove(enemyList[i]);
                    //Destroy(enemyList[i],1);
                    //Count = i;
                }
            }
            //Debug.Log(Count);
        }
    }

    IEnumerator SpwanEnemy()
    {
        foreach (EnemySpawn s in MonsterSpawnArray)
        {
            //s.Spawn().GetComponent<SoulMonster>().index = Count;
            //Count += 1;
            enemyList.Add(s.Spawn());
        }

        //foreach (EnemySpawn s in MonsterSpawnArray)
        //{
        //    Debug.Log(s.Spawn().GetComponent<SoulMonster>().index);
        //}

        while (enemyList.Count>0)//如果不为空，那么就一直不进行下面的程序
        {
            yield return new WaitForSeconds(0.2f);
        }
        BossBlood.SetActive(true);
        foreach (EnemySpawn s in BossSpawnArray)
        {
            //s.Spawn().GetComponent<SoulMonster>().index = Count;
            //Count += 1;
            enemyList.Add(s.Spawn());
        }

        while (enemyList.Count > 0)//如果不为空，那么就一直不进行下面的程序
        {
            yield return new WaitForSeconds(0.2f);
        }

        //Debug.Log("结束");
        //GameOver=GameObject.FindGameObjectWithTag("GameOver");
        GameOver.SetActive(true);
        BossBlood.SetActive(false);
        GameObject Sign= GameObject.Instantiate(Resources.Load<GameObject>("GameOverSign"));
        Sign.transform.position=new Vector3(0.879f,4.87f,-0.299f);
    }
}
