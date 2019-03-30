using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    private static PlayerDead instance = null;
    public static PlayerDead Instance
    {
        get { return instance; }
    }

    private bool isDead = false;

    public float Blood;
    public float Mp;
    public float Sp;
    public float Soul;
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
