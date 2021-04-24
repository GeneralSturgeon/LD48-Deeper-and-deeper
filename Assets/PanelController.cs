using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{

    public Image coverImg;

    private float fadeTime = 1f;
    public Color fadeColor;
    public Color origColor;
    private float tick = 0f;
    private bool isFading = false;

    private void Awake()
    {
        origColor = coverImg.color;
    }

    public void Fade()
    {
        isFading = true;
    }

    private void Update()
    {
        if(isFading)
        {
            tick += Time.deltaTime/2;
            coverImg.color = Color.Lerp(origColor, fadeColor, tick);
            if (tick >= fadeTime)
            {
                Debug.Log("next Scene");
            }
        }
    }
}

