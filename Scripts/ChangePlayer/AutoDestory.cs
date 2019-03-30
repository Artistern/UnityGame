using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestory : MonoBehaviour
{
    public float exitTime = 1.0f;

    private void Start()
    {
        Destroy(this.gameObject,exitTime);
    }
}
