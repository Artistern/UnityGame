using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class SpeakStateControl
{
    private TalkManager mTalkManager;
    private bool isFirstRun = true;

    public void SetSpeakGroup(TalkManager Tmanager)
    {
        mTalkManager = Tmanager;
        if (isFirstRun == true)
        {
            mTalkManager.StartXml();
            isFirstRun = false;
        }
        else
        {
            isFirstRun = true;
        }
    }

    public void ShowSpeak()
    {
        if (isFirstRun == true)
        {
            mTalkManager.StartXml();
            isFirstRun = false;
        }

        mTalkManager.UpdateXml();
    }
}
