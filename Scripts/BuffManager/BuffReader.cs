using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// buff管理器
/// </summary>
public class BuffReader
{
    public List<BuffManager> mBuffManageList=new List<BuffManager>();
    /// <summary>
    /// 注册一个buff
    /// </summary>
    public void ResgisterBuff(BuffManager buff)
    {
        mBuffManageList.Add(buff);
    }
    /// <summary>
    /// 使用buff的update方法
    /// </summary>
    public void UpdateBuff(float x)
    {
        for (int i=0;i< mBuffManageList.Count;i++)
        {
            mBuffManageList[i].SendMessage(x);
            if (mBuffManageList[i].isStateOver==true)
            {
                mBuffManageList[i].DeleBuff();//这里是移除效果
            }
            if (mBuffManageList[i].isOver==true)
            {
                RemoveBuff(mBuffManageList[i]);//这里就把buff从列表里面移除
                if (mBuffManageList.Count == 0)
                {
                    break;
                }
            }
        }
    }
    /// <summary>
    /// 移除一个buff
    /// </summary>
    private void RemoveBuff(BuffManager buff)
    {
        mBuffManageList.Remove(buff);
    }
}

