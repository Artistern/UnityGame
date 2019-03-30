using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeColor : MonoBehaviour
{
    public static ChangeColor _instance;
    /// <summary>
    /// 头部
    /// </summary>
    public SkinnedMeshRenderer headMeshRenderer;
    public Mesh[] headMeshArray;
    public int headIndex = 0;
    /// <summary>
    /// 手部
    /// </summary>
    public SkinnedMeshRenderer handMeshRenderer;
    public Mesh[] handMeshArray;
    public int handIndex = 0;

    public SkinnedMeshRenderer[] bodyColor;
    public Color purple;

    private int ColorIndex = -1;
    [HideInInspector]
    public Color[] ColorMesh;

    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        ColorMesh = new Color[] { Color.blue, Color.cyan, Color.green, purple, Color.red };
        DontDestroyOnLoad(this.gameObject);
    }
    /// <summary>
    /// 头部的改变
    /// </summary>
    public void OnHeadMeshNext()
    {
        headIndex++;
        headIndex %= headMeshArray.Length;
        headMeshRenderer.sharedMesh = headMeshArray[headIndex];
    }
    /// <summary>
    /// 手部的改变
    /// </summary>
    public void OnHandMeshNext()
    {
        handIndex++;
        handIndex %= handMeshArray.Length;
        handMeshRenderer.sharedMesh = handMeshArray[handIndex];
    }

    public void OnChangeColorBlue()
    {
        ColorIndex = 0;
        OnChangeColor(Color.blue);
    }
    public void OnChangeColorCyan()
    {
        ColorIndex = 1;
        OnChangeColor(Color.cyan);
    }
    public void OnChangeColorGreen()
    {
        ColorIndex = 2;
        OnChangeColor(Color.green);
    }
    public void OnChangeColorPurple()
    {
        ColorIndex = 3;
        OnChangeColor(purple);
    }
    public void OnChangerColorRed()
    {
        ColorIndex = 4;
        OnChangeColor(Color.red);
    }
    private void save()
    {
        PlayerPrefs.SetInt("headIndex", headIndex);
        PlayerPrefs.SetInt("handIndex", handIndex);
        PlayerPrefs.SetInt("ColorIndex", ColorIndex);
    }
    public void OnChangeColor(Color c)
    {
        foreach (SkinnedMeshRenderer color in bodyColor)
        {
            color.material.color = c;
        }
    }

    public void OnPlayButton()
    {
        save();
        //SceneManager.LoadScene(1);
        //SceneManager.CreateScene("newScene");
        SceneManager.LoadScene("SampleScene");
    }
}
