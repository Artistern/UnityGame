using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;


public class FirstChoice:TalkManager
{
    private SpeakStateControl mSpeakStateControl;
    private GameObject mGameObject;
    private GameObject mChoiceOne;
    private GameObject mChoiceTwo;
    public FirstChoice(SpeakStateControl speakState)
    {
        mSpeakStateControl = speakState;
    }
    public override void ShowMessage()
    {
        if (mGameObject==null)
        {
            mGameObject = GameObject.Instantiate(Resources.Load<GameObject>("Chioce"));
            mChoiceOne = GameObject.FindGameObjectWithTag("ChioceO");
            mChoiceTwo = GameObject.FindGameObjectWithTag("ChioceT");
            mChoiceOne.GetComponent<Button>().onClick.AddListener(TurnYes);
            mChoiceTwo.GetComponent<Button>().onClick.AddListener(TurnNo);
        }
    }

    public override void StartXml()
    {
        ShowMessage();
        
    }

    public override void UpdateXml()
    {
        
    }

    public void TurnYes()
    {
        MonoBehaviour.Destroy(mGameObject);
        mSpeakStateControl.SetSpeakGroup(new YouAnswerYes(mSpeakStateControl));
    }

    public void TurnNo()
    {
        MonoBehaviour.Destroy(mGameObject);
        mSpeakStateControl.SetSpeakGroup(new YouAnswer(mSpeakStateControl));
    }
}

