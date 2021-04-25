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
    public TextMeshProUGUI breadText;
    public int moneyNeededMed = 10000;
    public int moneyNeededHigh = 50000;

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
        if(moneyInt > moneyNeededMed)
        {
            breadText.text = "Well done, Ensign! But you can always do better!";
        }

        if (moneyInt > moneyNeededHigh)
        {
            breadText.text = "Excellent job, Ensign!";
        }
    }
}
