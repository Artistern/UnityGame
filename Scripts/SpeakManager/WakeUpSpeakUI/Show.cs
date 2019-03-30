using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Show : MonoBehaviour
{
    //private TalkManager xml;
    private SpeakStateControl mSpeakStateControl;
    void Start()
    {
        mSpeakStateControl = new SpeakStateControl();
        mSpeakStateControl.SetSpeakGroup(new LilithWelcome(mSpeakStateControl));
    }

    // Update is called once per frame
    void Update()
    {
       mSpeakStateControl.ShowSpeak();
    }
}
