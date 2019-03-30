using UnityEngine;
using System.Collections;
using System;
/// <summary>
/// 提供一个检查类
/// </summary>
public class MesManager:MonoBehaviour
{

    private static MesManager instance = null;

    public static MesManager Instance
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

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public event EventHandler<TaskEventArgs> checkEvent;

    public void Check(TaskEventArgs e)
    {
        checkEvent(this, e);
    }
}
