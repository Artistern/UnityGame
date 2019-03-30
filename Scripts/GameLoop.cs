using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameLoop : MonoBehaviour
{
    private static GameLoop instance = null;

    public static GameLoop Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public SceneStateController controller;

    private GameObject mGameObject;
    // Start is called before the first frame update
    void Start()
    {
        mGameObject= GameObject.Instantiate(Resources.Load<GameObject>("BlackGround"));
        mGameObject.SetActive(false);
        controller = new SceneStateController();
        controller.SetScene(new StartScene(controller), true);
        DontDestroyOnLoad(mGameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (NpcManControl.isTalk==false&& !(SceneManager.GetActiveScene().name=="StartScene"))
        {
            if (LevelUpNpc.isSpeak==false)
            {
                Cursor.visible = false;
            }
            else
            {
                Cursor.visible = true;
            }
        }

            
        else
        {
            Cursor.visible = true;
        }


        controller.StateUpdate();
        if(controller.isLoad)//是否加载完
        {
            mGameObject.SetActive(true);
        }
        else
        {
            mGameObject.SetActive(false);
        }
    }
}

