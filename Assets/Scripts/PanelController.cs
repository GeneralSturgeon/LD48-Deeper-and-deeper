using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{

    public Image coverImg;

    private float fadeTime = 1f;
    public Color fadeOutColor;
    private Color origColor;
    private float tick = 0f;
    private bool isFadingOut = false;
    public bool isFadingIn = true;
    private float tickIn = 0f;
    public Color fadeInColor;

    private int nextSceneIndex;



    private void Awake()
    {
        origColor = coverImg.color;
    }

    public void Fade(int nextScene)
    {
        nextSceneIndex = nextScene;
        isFadingOut = true;
    }

    private void Update()
    {
        if(isFadingOut)
        {
            tick += Time.deltaTime/2;
            Debug.Log(tick);
            coverImg.color = Color.Lerp(origColor, fadeOutColor, tick);
            if (tick >= fadeTime)
            {
                Debug.Log("next Scene");
            }
        }

        if(isFadingIn)
        {
            tickIn += Time.deltaTime / 2;
            coverImg.color = Color.Lerp(fadeOutColor, fadeInColor, tickIn);
            if (tickIn >= fadeTime)
            {
                isFadingIn = false;
            }
        }
    }
}

