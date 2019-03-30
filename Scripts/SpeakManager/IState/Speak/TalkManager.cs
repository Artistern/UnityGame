using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class TalkManager
{
    public static bool isEnd = false;
    /// <summary>
    /// 具体解析步骤，需要在使用前调用
    /// </summary>
    public virtual void ShowMessage()
    {
        
    }
    /// <summary>
    /// 设置开始
    /// </summary>
    public virtual void StartXml()
    {
    }
    /// <summary>
    /// 设置调用每个对话的逻辑
    /// </summary>
    public virtual void UpdateXml()
    {
    }
    /// <summary>
    /// 设置对话结束之后的逻辑
    /// </summary>
    public virtual void EndXml()
    {
    }
}

