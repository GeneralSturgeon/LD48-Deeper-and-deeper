using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{

    private Toggle toggle;
    public AudioSource clickSound;

    private void Start()
    {
        toggle = FindObjectOfType<Toggle>();
        if(toggle != null)
        {
            toggle.isOn = Manager.instance.tutorialOn;
        }
    }
    public void OnClick()
    {
        clickSound.Play();
        FindObjectOfType<PanelController>().Fade(1);
    }

    public void ToggleTutorial()
    {
        clickSound.Play();
        Manager.instance.tutorialOn = toggle.isOn;
    }
}
