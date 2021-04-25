using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CutsceneController : MonoBehaviour
{
    public float lenght = 5f;

    private float tick = 0f;
    public PanelController panel;

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI distanceText;

    private void Update()
    {
        tick += Time.deltaTime;
        if(tick >= lenght)
        {
            Manager.instance.ResetProgress();
            panel.Fade(0);
        }
    }

    private void Start()
    {
        var moneyInt = (int)Manager.instance.money;
        moneyText.text = "Income: " + moneyInt.ToString() + "$";
        distanceText.text = "Depth: " + TextHolder.instance.FormatDistance(Manager.instance.distance) + "km";
    }
}
