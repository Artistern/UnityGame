using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 主要负责游戏进程的管理
/// </summary>
public class GameCoreManager:MonoBehaviour
{

    public int TowerCount = 0;//层数
    public List<GameObject> MonsterList;
    public bool isOver = false;
    private GameObject mGameObject;
    private GameObject m_GameOject;
    private bool isRestart = false;
    private static GameCoreManager instance = null;

    public static GameCoreManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        MonsterList = new List<GameObject>();
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);  
    }

    void Start()
    {
        
        TowerCount = 1;
    }

    public void Update()
    {
        if (PlayerManager.Instance.PlayerBlood<=0)
        {
            MonsterList.Clear();
            isRestart = true;
        }

        if (MonsterList.Count==0&& isRestart==false&& !(SceneManager.GetActiveScene().name == "GameOver"))
        {
            if (!(SceneManager.GetActiveScene().name == "StartScene"))
            {
                if (!(SceneManager.GetActiveScene().name == "FirstScene"))
                {
                    isOver = true;
                    if (mGameObject == null)
                    {
                        PlayerManager.Instance.SkillCount += 1;
                        //TowerCount += 1;
                        mGameObject = GameObject.Instantiate(Resources.Load<GameObject>("GameOverSign"));
                        m_GameOject = GameObject.Instantiate(Resources.Load<GameObject>("Sphere"));
                    }
                }
                
            }
        }
        else
        {
            isOver = false;
        }

        //if (PlayerManager.Instance.PlayerBlood<=0)
        //{
        //    MonsterList.Clear();
        //}
    }


    public void ResgisterList(GameObject monsterGameObject)
    {
        isRestart = false;
        MonsterList.Add(monsterGameObject);
    }

    public void RemoveList(GameObject monsterGameObject)
    {
        MonsterList.Remove(monsterGameObject);
    }

    public void Clear()
    {
        MonsterList.Clear();
    }
}

