using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Animator animator;

    private CharacterController coll;

    public float speed = 1f;//移动速度

    public float grivate = 10.0f;//重力

    private Vector3 target = Vector3.zero;//移动目标

    private Vector3 vector;//计算角度的准备

    public Transform child;//子物体的位置

    private float Timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponentInChildren<CharacterController>();

    }

    private void Update()
    {
       
    }
    void LateUpdate()
    {
        ChangeRotation();
        coll = this.GetComponent<CharacterController>();
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        PlayerAnimation();
        if (coll.isGrounded)
        {
            //isJump = false;
            target = new Vector3(x, 0, y);
            target = transform.TransformDirection(target);
            target *= speed;
            float h = Camera.main.transform.rotation.eulerAngles.y;
            target = Quaternion.Euler(0, h, 0) * target;
        }
        target.y -= grivate * Time.deltaTime;
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Run") || !coll.isGrounded)
        {
            coll.Move(target * Time.deltaTime);
        }

        if (!coll.isGrounded)
        {
            Timer += Time.deltaTime;
            //Debug.Log("不在地面");
            if (Timer>=1.0f)
            {
                PlayerManager.Instance.PlayerBlood = 0;
                Timer = 0;
            }
        }
    }
    /// <summary>
    /// 播放移动动作的方法
    /// </summary>
    private void PlayerAnimation()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Walk",true);
        }
        else
        {
            animator.SetBool("Walk",false);
        }
    }
    /// <summary>
    /// 控制转向的方法
    /// </summary>
    private void ChangeRotation()
    {
        float h = Camera.main.transform.rotation.eulerAngles.y;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        vector = new Vector3(x, 0, y);
        vector = Quaternion.Euler(0, h, 0) * vector;
        float angle = Vector3.Angle(Vector3.right, vector);//按键旋转角度
        if (vector.z < 0)
        {
            angle = -angle;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
            {
                child.rotation = Quaternion.AngleAxis(90 - angle, Vector3.up);
            }
        }
    }
}
