using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class TaskReward
{
    public string id;//奖励id
    public int amount = 0;//奖励数量

    public TaskReward(string id, int amount)
    {
        this.id = id;
        this.amount = amount;
    }
}
