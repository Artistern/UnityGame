using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject prefabs;

    public GameObject Spawn()
    {
        return GameObject.Instantiate(prefabs, transform.position, transform.rotation) as GameObject;

        //return enemy;
    }
}
