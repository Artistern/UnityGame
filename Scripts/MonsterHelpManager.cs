using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
/// <summary>
/// 用于监听场景怪物的信息
/// 目前主要监听血量
/// </summary>
public class MonsterHelpManager:MonoBehaviour
{
    private static MonsterHelpManager instance = null;
    public List<MonsterDamage> mMonsterDamageList;
    public List<GameObject> mMonsterGameObjectList;
    private GameObject mGameObject;

    public static MonsterHelpManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        mMonsterDamageList=new List<MonsterDamage>();
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void ResgisterList(MonsterDamage monsterDamage)
    {
        mMonsterDamageList.Add(monsterDamage);
    }
    /// <summary>
    /// 注册怪物
    /// </summary>
    /// <param name="monster"></param>
    public void ResgisterMonsters(GameObject monster)
    {
        mMonsterGameObjectList.Add(monster);
    }

    public void UpdateList()
    {
        foreach (MonsterDamage monsterDamage in mMonsterDamageList)
        {
            if (monsterDamage.Blood<=500)
            {
                mGameObject = monsterDamage.gameObject;
            }
        }
    }

    public void RemoveList(MonsterDamage monsterDamage)
    {
        mMonsterDamageList.Remove(monsterDamage);
    }
    /// <summary>
    /// 移除怪物
    /// </summary>
    public void RemoveMonsterList(GameObject monster)
    {
        mMonsterGameObjectList.Remove(monster);
    }

    public void Clear()
    {
        mMonsterGameObjectList.Clear();
    }

    public void ClearMonster()
    {
        mMonsterDamageList.Clear();
    }
}

