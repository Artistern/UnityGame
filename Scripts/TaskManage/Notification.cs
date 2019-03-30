using UnityEngine;
using System.Collections;
using System;

public class Notification :MonoBehaviour
{

    private static Notification instance = null;

    public static Notification Instance
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

    void Start()
    {
        TaskManager.Instance.getEvent += getPrintInfo;
        TaskManager.Instance.finishEvent += finishPrintInfo;
        TaskManager.Instance.rewardEvent += rewardPrintInfo;
        TaskManager.Instance.cancelEvent += cancelPrintInfo;
    }

    public void getPrintInfo(System.Object sender, TaskEventArgs e)
    {
        print("接受任务" + e.taskID);
    }

    public void finishPrintInfo(System.Object sender, TaskEventArgs e)
    {
        print("完成任务" + e.taskID);
    }

    public void rewardPrintInfo(System.Object sender, TaskEventArgs e)
    {
        print("奖励物品" + e.id + "数量" + e.amount);
    }

    public void cancelPrintInfo(System.Object sender, TaskEventArgs e)
    {
        print("取消任务" + e.taskID);
    }
}
