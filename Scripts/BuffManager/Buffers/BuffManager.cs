using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class BuffManager
{
    protected float AwakeTimer;
    public bool isOver = false;
    public bool isStateOver = false;
    protected float Temp;
    protected string Content;
    protected bool isEndShow = false;
    public BuffManager(float awakeTimer,float temp,string nameContent)
    {
        Temp = temp;
        AwakeTimer = awakeTimer;
        Content = nameContent;
    }

    public virtual void  SendMessage(float x)
    { 

    }

    public virtual void DeleBuff()
    {

    }
}

