using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{

    public Image coverImg;

    public float fadeTime = 1f;
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
            tick += Time.deltaTime;
            Debug.Log(tick);
            coverImg.color = Color.Lerp(origColor, fadeOutColor, tick * (1 / fadeTime));
            if (tick >= fadeTime)
            {
                Manager.instance.GoToScene(nextSceneIndex);
            }
        }

        if(isFadingIn)
        {
            tickIn += Time.deltaTime;
            coverImg.color = Color.Lerp(fadeOutColor, fadeInColor, tickIn * (1/fadeTime));
            if (tickIn >= fadeTime)
            {
                isFadingIn = false;
            }
        }
    }
}

