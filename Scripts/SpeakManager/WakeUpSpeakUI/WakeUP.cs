using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUP : MonoBehaviour
{
    private GameObject UISpeak;

    private bool isFinish;
    void Start()
    {
        Debug.Log("Start");
        UISpeak = Instantiate(Resources.Load<GameObject>("Prefabs/SpeakUI/Canvas"));
        this.gameObject.AddComponent<Show>();
        isFinish = false;
    }
    void Update()
    {
        if (TalkManager.isEnd==true&&isFinish==false)
        {
            Destroy(this.UISpeak);
            Destroy(this.GetComponent<Show>());
            isFinish = true;
        }
    }
}
