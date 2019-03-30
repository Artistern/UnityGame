using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;


public class NPCChoice:TalkManager
{
    private SpeakStateControl mSpeakStateControl;
    private List<ChoiceElement> mChoiceElementList=new List<ChoiceElement>();
    private GameObject Book;
    private Text BookTextFirst;
    private Text BookTextSecond;
    public NPCChoice(SpeakStateControl speakState)
    {
        mSpeakStateControl = speakState;
    }

    public override void StartXml()
    {
        TextAsset textAsset = Resources.Load("NPCChoice/NPCChoice") as TextAsset;
        XmlDocument xmlDocument=new XmlDocument();
        if (textAsset.text==null)
        {
            Debug.LogError("没有找到文件");
        }
        else
        {
            xmlDocument.LoadXml(textAsset.text);
        }

        XmlNode Choice = xmlDocument.FirstChild;//得到choice
        XmlNodeList ChoiceList = Choice.ChildNodes;//得到choice下面的元素表
        foreach (XmlNode choiceChild in ChoiceList)
        {
            ChoiceElement choiceElement = new ChoiceElement();
            XmlNodeList choiceNodeList = choiceChild.ChildNodes;
            foreach (XmlNode temp in choiceNodeList)
            {
                if (temp.Name == "id")
                {
                    int value = Int32.Parse(temp.InnerText);
                    choiceElement.id = value;
                }
                else
                {
                    choiceElement.content = temp.InnerText;
                }
            }

            mChoiceElementList.Add(choiceElement);
        }
        Book = UnityEngine.MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Book"));
        Book.transform.SetParent(GameObject.FindGameObjectWithTag("UI").transform,false);
    }

    public override void UpdateXml()
    {
        if (mChoiceElementList.Count!=0)
        {
            foreach (ChoiceElement chioChoiceElement in mChoiceElementList)
            {
                BookTextFirst = UnityEngine.MonoBehaviour.Instantiate(Resources.Load<Text>("Prefabs/First"));
                BookTextFirst.transform.SetParent(Book.transform,true);
                BookTextFirst.rectTransform.position+=Vector3.up;
                BookTextFirst.text = chioChoiceElement.id + "：" + chioChoiceElement.content + "\n";
            }
            mChoiceElementList.Clear();
        }
        else
        {
            
        }


    }
}

