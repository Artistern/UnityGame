using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class StartScene:ISceneState
{
    private CanvasGroup mCanvasGroup;

    private AudioSource mAudioSource;

    private bool isEnter=false;
    private Button mButton;
    private Button mButtonOver;
    public StartScene(SceneStateController controller) : base("StartScene", controller) { }

    public override void StateStart()
    {
        mCanvasGroup = GameObject.FindGameObjectWithTag("GameStart").GetComponent<CanvasGroup>();
        mButton = GameObject.FindGameObjectWithTag("GameButton").GetComponent<Button>();
        mAudioSource = GameObject.FindGameObjectWithTag("GameButton").GetComponent<AudioSource>();
        mButtonOver = GameObject.FindGameObjectWithTag("GameQuit").GetComponent<Button>();
        mButton.onClick.AddListener(ShowButton);
        mButtonOver.onClick.AddListener(QuitGame);
        mCanvasGroup.alpha = 0;
    }

    public override void StateUpdate()
    {
        //Debug.Log("进程开始");
        if (mCanvasGroup.alpha<0.9)
        {
            mCanvasGroup.alpha = Mathf.Lerp(mCanvasGroup.alpha, 1, Time.deltaTime);
        }
        else
        {
            mCanvasGroup.alpha = 1;
        }
    }

    private void ShowButton()
    {
        mAudioSource.Play();
        isEnter = true;
        mController.SetScene(new FirstScene(mController));
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
