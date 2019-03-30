using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    private Animator mAnimator;

    private int speedID = Animator.StringToHash("SpeedZ");

    private int SpeedXID = Animator.StringToHash("SpeedX");
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        mAnimator.SetFloat(speedID,Input.GetAxis("Vertical")*0.96f);
        mAnimator.SetFloat(SpeedXID,Input.GetAxis("Horizontal")*61f);
    }
}
