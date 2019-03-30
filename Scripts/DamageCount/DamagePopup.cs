using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    private Vector3 mTarget;//目标位置

    private Vector3 mScreen;//屏幕坐标

    public int Value;//数值显示

    public float ContentWidth=400;//宽度
    public float ContentHeight = 200;//高度
    private Vector2 mPoint;
    public float FreeTime = 1.5f;//销毁时间

    // Start is called before the first frame update
    void Start()
    {
        mTarget = transform.position;
        mScreen = Camera.main.WorldToScreenPoint(mTarget);
        mPoint=new Vector2(mScreen.x,Screen.height-mScreen.y);
        StartCoroutine("Free");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up*0.5f*Time.deltaTime);
        mTarget = transform.position+Vector3.up*2;
        mScreen = Camera.main.WorldToScreenPoint(mTarget);
        mPoint=new Vector2(mScreen.x,Screen.height-mScreen.y);
    }

    void OnGUI()
    {
        GUIStyle forntStyle=new GUIStyle();
        forntStyle.normal.background = null;
        forntStyle.normal.textColor=new Color(1,0,0);
        forntStyle.fontSize = 20;
        GUI.Label(new Rect(mPoint.x,mPoint.y,ContentWidth,ContentHeight), Value.ToString(),forntStyle);
    }

    IEnumerator Free()
    {
        yield return  new WaitForSeconds(FreeTime);
        Destroy(this.gameObject);
    }
}
