using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManControl : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController mCharacterController;
    private Vector3 Target=Vector3.zero;
    private float Gravity = 10.0f;
    private GameObject mGameObject;
    public GameObject UISpeak;
    private bool isFinish=true;
    public  GameObject ChangeScene;
    public static bool isTalk = false;
    void Awake()
    {
        mCharacterController = this.GetComponent<CharacterController>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!mCharacterController.isGrounded)
        {
            Target.y -= Gravity * Time.deltaTime;
        }
        mCharacterController.SimpleMove(Target);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.name=="Girl")
        {
            mGameObject = GameObject.Instantiate(Resources.Load<GameObject>("TalkButton"),collider.gameObject.transform,false);      
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.name == "Girl")
        {
            if (Input.GetKeyDown(KeyCode.E)&&isFinish==true)
            {
                Destroy(mGameObject);
                isTalk = true;
                TalkManager.isEnd = false;
                UISpeak = Instantiate(Resources.Load<GameObject>("Prefabs/SpeakUI/Canvas"));
                this.gameObject.AddComponent<Show>();
                isFinish = false;           
            }
            if (TalkManager.isEnd == true && isFinish == false)
            {
                PlayerManager.Instance.BloodBottleCount += 5;
                isTalk = false;
                Destroy(this.UISpeak.gameObject);
                Destroy(this.GetComponent<Show>());
                isFinish = true;
                if (ChangeScene==null)
                {
                    ChangeScene= GameObject.Instantiate(Resources.Load<GameObject>("GameOverSign"));
                }
            }
        }
        
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.name=="Girl")
        {
            isTalk = false;
            isFinish = true;
            if (UISpeak!=null)
            {
                Destroy(this.UISpeak.gameObject);
            }
            Destroy(this.GetComponent<Show>());
            Destroy(mGameObject);
        }
    }

}
