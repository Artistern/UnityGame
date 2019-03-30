using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryCamera : MonoBehaviour
{
    //玩家组件
    public Transform playerPostition;
    //摄像机朝哪里看
    public Transform LookAtPlace;
    //设置选装速度
    public float rotationSpeed = 10.0f;
    //设置是否旋转
    private bool isRotation = false;
    //摄像机和玩家的距离
    public float distance = 10.0f;
    //手动调节视角距离的灵敏度
    public float sensive = 5.0f;
    //最小缩放角度
    public float mixDistance = 1.5f;
    //最大缩放角度
    public float maxDistance = 10.0f;
    //镜头移动速度（自动）
    public float moveSpeed = 3.0f;
    void Start()
    {

        distance = Vector3.Distance(transform.position, playerPostition.position);

        maxDistance = distance + maxDistance;
    }


    private void LateUpdate()
    {
        if (NpcManControl.isTalk==false)
        {
            if (LevelUpNpc.isSpeak==false)
            {
                RotationView();
            }

            
        }
        ScrollView();
        pushCamera();
    }
    /// <summary>
    /// 鼠标滚轮控制镜头缩放
    /// </summary>
    private void ScrollView()
    {
        float distance = Vector3.Distance(transform.position, playerPostition.position);

        Vector3 stopPositionMax = transform.position;
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            transform.position = transform.position - transform.forward * sensive * Time.deltaTime;
        }

        Vector3 stopPositionMix = transform.position;
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {

            transform.position = transform.position + transform.forward * sensive * Time.deltaTime;

            //mainCamera.fieldOfView = mainCamera.fieldOfView + sensive;
        }

        if (distance < mixDistance)
        {
            transform.position = stopPositionMix;
            //Debug.Log("最小距离");
        }
        else if (distance > maxDistance)
        {
            transform.position = stopPositionMax;
            transform.position = transform.position + transform.forward * Time.deltaTime;
        }


    }
    /// <summary>
    /// 鼠标右键控制摄像机旋转
    /// </summary>
    private void RotationView()
    {
        Test();
        //if (Input.GetMouseButtonDown(1))
        //{
        //    isRotation = true;
        //}
        //if (Input.GetMouseButtonUp(1))
        //{
        //    isRotation = false;
        //}
    }
    /// <summary>
    /// 通过射线检测，自动推动摄像机
    /// </summary>
    private void pushCamera()
    {
        Vector3 dir = LookAtPlace.position - transform.position;
        //Debug.Log(dir);
        Ray ray = new Ray(transform.position, dir);
        RaycastHit hit;
        bool isCollider = Physics.Raycast(ray, out hit);
        //Debug.DrawRay(ray.origin, ray.direction * 100, Color.blue);
        if (isCollider)
        {
            if (hit.collider.gameObject.tag != "Player")
            {
                if (isSeePlayer() == false)
                {
                    transform.position = Vector3.Lerp(transform.position, transform.position + transform.forward, Time.deltaTime * moveSpeed);
                    //transform.position += transform.forward * Time.deltaTime * AutoSensive;
                }
              
            }
            else if(hit.collider.gameObject.tag == "Player")
            {
                
            }
        }

    }
    /// <summary>
    /// 射线检测看键
    /// </summary>
    /// <returns></returns>
    private bool isSeePlayer()
    {
        Vector3 dir = LookAtPlace.position - transform.position;
        //Ray ray = mainCamera.ScreenPointToRay(playerPostition.position);
        Ray ray = new Ray(transform.position, dir);
        RaycastHit hit;
        bool isCollider = Physics.Raycast(ray, out hit);
        //Debug.DrawRay(ray.origin, ray.direction * 100, Color.blue);
        if (isCollider)
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                return true;
            }
            else if (hit.collider.gameObject.tag == "Wall")
            {
                return false;
            }
        }
        return true;
    }

    private void Test()
    {
        transform.RotateAround(playerPostition.position, playerPostition.up, rotationSpeed * Input.GetAxis("Mouse X"));//围捞角色滑动 左右

        Vector3 originalPos = transform.position;
        Quaternion originalRotation = transform.rotation;

        transform.RotateAround(playerPostition.position, transform.right, -rotationSpeed * Input.GetAxis("Mouse Y"));//上下 (会影响到的属性一个是Position,一个是rotation)
        //限制上下滑动的度数大小
        float x = transform.eulerAngles.x;
        if (x < 10 || x > 70)//当超出范围之后，我们将属性归位，让旋转无效
        {
            transform.position = originalPos;
            transform.rotation = originalRotation;

        }
    }
}

