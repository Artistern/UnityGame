﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;


public class Mouse:TalkManager
{
    private Text NPCTalk;

    private Text NPC;

    private Image NPCImage;

    public List<NPCSpeak> SkillMenuLsList = new List<NPCSpeak>();

    private SpeakStateControl mSpeakStateControl;

    private Vector3 Move=Vector3.zero;
    private float time = 0;
    public Mouse(SpeakStateControl speakState)
    {
        mSpeakStateControl = speakState;
    }

    public override void ShowMessage()
    {
        TextAsset tryTextAsset = Resources.Load("NPCSpeaker/MoveMouse") as TextAsset;
        XmlDocument xmlDocument = new XmlDocument();
        if (tryTextAsset == null)
        {
            Debug.LogError("没有读取到文件");
        }
        else
        {
            xmlDocument.LoadXml(tryTextAsset.text);
        }
        XmlNode SkillsNode = xmlDocument.FirstChild;
        XmlNodeList SkillNodeList = SkillsNode.ChildNodes;
        foreach (XmlNode skills in SkillNodeList)
        {
            NPCSpeak skillMenu = new NPCSpeak();
            XmlNodeList fieldNodeList = skills.ChildNodes;
            foreach (XmlNode skill in fieldNodeList)
            {
                if (skill.Name == "role")
                {
                    skillMenu.Name = skill.InnerText;
                }
                else if (skill.Name == "detail")
                {
                    skillMenu.Speak = skill.InnerText;
                }
            }
            SkillMenuLsList.Add(skillMenu);
        }
    }
    public override void StartXml()
    {
        ShowMessage();
        NPCTalk = GameObject.FindGameObjectWithTag("Speak").GetComponent<Text>();//获取对话
        NPC = GameObject.FindGameObjectWithTag("Speaker").GetComponent<Text>();//获取人物名字
        NPCImage = GameObject.FindGameObjectWithTag("NPCImage").GetComponent<Image>();//获取人物贴图
        NPCTalk.text = this.SkillMenuLsList[0].Speak;//获取对话内容
        NPC.text = this.SkillMenuLsList[0].Name;//或缺人物名字
        Sprite Image = Resources.Load<Sprite>("Image/" + this.SkillMenuLsList[0].Name);
        NPCImage.sprite = Image;
        this.SkillMenuLsList.Remove(this.SkillMenuLsList[0]);
        Move = Input.mousePosition;
        NpcManControl.isTalk = false;
    }

    public override void UpdateXml()
    {
        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    if (this.SkillMenuLsList.Count != 0)
        //    {
        //        NPC.text = this.SkillMenuLsList[0].Name;
        //        NPCTalk.text = this.SkillMenuLsList[0].Speak;
        //        NPCImage.sprite = Resources.Load<Sprite>("Image/" + this.SkillMenuLsList[0].Name);
        //        this.SkillMenuLsList.Remove(this.SkillMenuLsList[0]);
        //    }
        //    else
        //    {
        //        mSpeakStateControl.SetSpeakGroup(new Attack(mSpeakStateControl));
        //        //isEnd = true;
        //    }
        //}
        if (Move!=Input.mousePosition)
        {
            time += UnityEngine.Time.deltaTime;
            if (time>=3)
            {
                NpcManControl.isTalk = true;
                mSpeakStateControl.SetSpeakGroup(new Attack(mSpeakStateControl));
            }
        }

        //Move = Input.mousePosition;
        //Debug.Log(Input.mousePosition);
    }
}

