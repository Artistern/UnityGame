using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnityEngine;


public class TaskManager:MonoBehaviour
{
    private static TaskManager instance=null;

    public static TaskManager Instance
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
//****************单例化完成****************************************
    public XElement rootElement;//文件解析类


    public List<Task> TaskList=new List<Task>();//这里存储的是已经接受的任务
    public Dictionary<string, Task> dictionary = new Dictionary<string, Task>();//id,task

    public event EventHandler<TaskEventArgs> getEvent;//接受任务时,更新任务到任务面板等操作
    public event EventHandler<TaskEventArgs> finishEvent;//完成任务时,提示完成任务等操作
    public event EventHandler<TaskEventArgs> rewardEvent;//得到奖励时,显示获取的物品等操作
    public event EventHandler<TaskEventArgs> cancelEvent;//取消任务时,显示提示信息等操作
    void Start()
    {
        MesManager.Instance.checkEvent += CheckTask;//
        rootElement =XElement.Load(Application.dataPath + "/Resources/TaskList/Part_Time_Job.xml");//得到根元素，这里就是最上面的那个元素
    }

    public void GetTask(string taskID)
    {
        if (!dictionary.ContainsKey(taskID))//如果不存在这个id
        {
            Debug.Log(taskID);
            Task t = new Task(taskID);
            dictionary.Add(taskID, t);

            TaskEventArgs e = new TaskEventArgs();
            e.taskID = taskID;
            getEvent(this, e);//这里会调用一种通知方法，当条件满足，那么就会通知检查方法
        }
    }

    public void CheckTask(System.Object sender, TaskEventArgs e)
    {
        foreach (KeyValuePair<string, Task> kv in dictionary)
        {
            kv.Value.Check(e);
        }
    }

    public void FinishTask(TaskEventArgs e)
    {
        finishEvent(this, e);
    }

    public void GetReward(TaskEventArgs e)
    {
        if (dictionary.ContainsKey(e.taskID))
        {
            Task t = dictionary[e.taskID];
            for (int i = 0; i < t.taskRewards.Count; i++)
            {
                TaskEventArgs a = new TaskEventArgs();
                a.id = t.taskRewards[i].id;
                a.amount = t.taskRewards[i].amount;
                a.taskID = e.taskID;
                rewardEvent(this, a);
            }
        }
        dictionary.Remove(e.taskID);
    }

    public void CancelTask(TaskEventArgs e)
    {
        if (dictionary.ContainsKey(e.taskID))
        {
            cancelEvent(this, e);
            dictionary.Remove(e.taskID);
        }
    }
}

