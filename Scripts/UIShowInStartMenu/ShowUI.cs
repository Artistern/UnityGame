using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowUI : MonoBehaviour
{
    public CanvasGroup mCanvasGroup;

    public float ShowSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        mCanvasGroup.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (mCanvasGroup.alpha<1)
        {
            mCanvasGroup.alpha = Mathf.Lerp(mCanvasGroup.alpha, 1, Time.deltaTime * ShowSpeed);
        }
    }
}
