using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// 怪物战斗Ai的调控管理器
/// 主要负责辅助职业的技能释放时机
/// 后期可能会通过这个实现类似战略的战斗模式
/// </summary>
public class MonsterCalledManager:MonoBehaviour
{
    private static MonsterCalledManager instance = null;

    public static MonsterCalledManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;
    }
}
