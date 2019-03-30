using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDress : MonoBehaviour
{
    public SkinnedMeshRenderer headMeshRenderer;
    public SkinnedMeshRenderer handMeshRenderer;
    public SkinnedMeshRenderer[] bodyColor;
    // Start is called before the first frame update
    void Start()
    {
        IniDress();
    }

    void IniDress()
    {
        int headIndex = PlayerPrefs.GetInt("headIndex");
        int handIndex = PlayerPrefs.GetInt("handIndex");
        int ColorIndex = PlayerPrefs.GetInt("ColorIndex");

        headMeshRenderer.sharedMesh = ChangeColor._instance.headMeshArray[headIndex];
        handMeshRenderer.sharedMesh = ChangeColor._instance.handMeshArray[handIndex];

        foreach (SkinnedMeshRenderer m in bodyColor)
        {
            m.material.color = ChangeColor._instance.ColorMesh[ColorIndex];
        }
    }
}
