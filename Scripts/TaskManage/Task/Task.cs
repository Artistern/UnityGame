using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


public class Task
{
    public TaskItem taskItem;//对应的UI面板

    public string taskID;//任务ID
    public string taskName;//任务名字
    public string caption;//任务描述   
    public List<TaskCondition> taskConditions = new List<TaskCondition>();
    public List<TaskReward> taskRewards = new List<TaskReward>();

    //根据taskNum读取xml,实现初始化
    public Task(string taskID)
    {
        this.taskID = taskID;//这里会传来一个任务id
        XElement xe = TaskManager.Instance.rootElement.Element(taskID);//在这里确定一个这里传来的是在xml根节点下面的那些元素
        taskName = xe.Element("taskName").Value;
        caption = xe.Element("caption").Value;

        IEnumerable<XElement> a = xe.Elements("conditionID");
        IEnumerator<XElement> b = xe.Elements("conditionTargetAmount").GetEnumerator();

        IEnumerable<XElement> c = xe.Elements("rewardID");
        IEnumerator<XElement> d = xe.Elements("rewardAmount").GetEnumerator();

        foreach (var s in a)
        {
            b.MoveNext();//将枚举数推进到集合的下一个元素。
            TaskCondition tc = new TaskCondition(s.Value, 0, int.Parse(b.Current.Value));
            taskConditions.Add(tc);//将条件写入条件类
        }

        foreach (var s in c)
        {
            d.MoveNext();
            TaskReward tr = new TaskReward(s.Value, int.Parse(d.Current.Value));
            taskRewards.Add(tr);//将奖励写入奖励类
        }
    }
    //判断条件是否满足
    public void Check(TaskEventArgs e)
    {
        TaskCondition tc;
        for (int i = 0; i < taskConditions.Count; i++)
        {
            tc = taskConditions[i];
            if (tc.id == e.id)
            {
                tc.nowAmount += e.amount;
                if (tc.nowAmount < 0) tc.nowAmount = 0;
                if (tc.nowAmount >= tc.targetAmount)
                    tc.isFinish = true;
                else
                    tc.isFinish = false;

                taskItem.Modify(e.id, tc.nowAmount);//用来显示当前的进度
            }
        }

        for (int i = 0; i < taskConditions.Count; i++)
        {
            if (!taskConditions[i].isFinish)
            {
                taskItem.Finish(false);//用来显示关闭按钮的状态
                return;
            }
        }
        taskItem.Finish(true);
        e.taskID = taskID;
        TaskManager.Instance.FinishTask(e);
    }

    //获取奖励
    public void Reward()
    {
        TaskEventArgs e = new TaskEventArgs();
        e.taskID = taskID;
        TaskManager.Instance.GetReward(e);
    }

    //取消任务
    public void Cancel()
    {
        TaskEventArgs e = new TaskEventArgs();
        e.taskID = taskID;
        TaskManager.Instance.CancelTask(e);
    }
}

