using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public float lenght = 5f;

    private float tick = 0f;
    public PanelController panel;

    private void Update()
    {
        tick += Time.deltaTime;
        if(tick >= lenght)
        {
            panel.Fade(0);
        }
    }
}
