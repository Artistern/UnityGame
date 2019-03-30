using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpNpc : MonoBehaviour
{
    public static bool isSpeak = false;
    public float Distance;
    public float Speed=1.0f;
    private Vector3 StartPosition;

    private Vector3 EndPosition;

    private float isEnd = -1;

    private GameObject mGameObject;
    // Start is called before the first frame update
    void Start()
    {
        isSpeak = false;
        StartPosition = this.transform.position;
        EndPosition = StartPosition + Vector3.up * Distance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position==EndPosition)
        {
            isEnd = -1;
        }
        else if(transform.position==StartPosition)
        {
            isEnd = 1;
        }
        transform.Translate(transform.up *isEnd* Speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.name=="Girl")
        {
            //Debug.Log("进入");
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.name == "Girl")
        {
            //Debug.Log("进入");
            if (Input.GetKeyDown(KeyCode.E)&&mGameObject==null)
            {
                isSpeak = true;
                mGameObject = 
                GameObject.Instantiate(Resources.Load<GameObject>("LevelUpMenu"));
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.name == "Girl")
        {
            isSpeak = false;
            Destroy(mGameObject);
            //Debug.Log("进入");
        }
    }
}
