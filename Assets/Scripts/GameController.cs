using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public int maxHealth = 24;
    public int maxEnergy = 24;
    private float currentHealth;
    [HideInInspector]
    public float currentEnergy;
    public float energyRegen = 1f;
    public Slider energySlider;
    public Slider healthSlider;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI distanceText;
    public float distance = 0f;
    public float currentMoney = 0f;

    private float tick = 0f;
    public float updateTime = 0.2f;

    public Animator screenAnim;
    public TextMeshProUGUI interactionText;
    public bool tutorialOn = true;
    private int tutorialTicks = 0;
    public AudioSource[] mouseSounds;
    public AudioSource dyingSound;
    public Animator healthFlashanim;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        currentEnergy = maxEnergy;
        currentHealth = maxHealth;
        Random.InitState(Mathf.FloorToInt(Time.realtimeSinceStartup));
        tutorialOn = Manager.instance.tutorialOn;
    }

    private void Start()
    {
        InitTutorial();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<PanelController>().Fade(0);
        }

    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        healthSlider.value = currentHealth;
        if(currentHealth < maxHealth/4)
        {
            dyingSound.Play();
            healthFlashanim.SetBool("IsFlashing", true);
        }
        if(currentHealth <= 0)
        {
            Death();
        }
    }

    public void Heal (float heal)
    {
        currentHealth += heal;

        if (currentHealth > maxHealth / 4)
        {
            dyingSound.Stop();
            healthFlashanim.SetBool("IsFlashing", false);
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthSlider.value = currentHealth;
    }

    public void UseEnergy(float energy)
    {
        currentEnergy -= energy;
        if(currentEnergy < 0)
        {
            currentEnergy = 0;
        }
        energySlider.value = currentEnergy;
    }

    public void RegainEnergy(float energy)
    {
        currentEnergy += energy;
        if (currentEnergy > maxEnergy)
        {
            currentEnergy = maxEnergy;
        }
        energySlider.value = currentEnergy;
    }

    private void Death()
    {
        FindObjectOfType<PlayerController>().Death();
        FindObjectOfType<PanelController>().Fade(2);
    }

    private void FixedUpdate()
    {
        UpdateDistanceText();

        tick += Time.deltaTime;

        if (tick > updateTime)
        {
            tick = 0;
            OnTick();
        }
    }


    private void UpdateDistanceText()
    {
        if(FindObjectOfType<PlayerController>() != null)
        {
            distance = FindObjectOfType<PlayerController>().transform.position.z / 14f;
            distanceText.text = TextHolder.instance.FormatDistance(distance) + "km";
            Manager.instance.distance = distance;
        }
        
    }

    private void OnTick()
    {
        RegainEnergy(energyRegen);
        if(tutorialOn)
        {
            tutorialTicks++;
            if(tutorialTicks == 50)
            {
                interactionText.text = TextHolder.instance.GetTutorialString(1);
                mouseSounds[Random.Range(0, mouseSounds.Length)].Play();
            }

            if (tutorialTicks == 125)
            {
                interactionText.text = TextHolder.instance.GetTutorialString(2);
                mouseSounds[Random.Range(0, mouseSounds.Length)].Play();
            }

            if (tutorialTicks == 200)
            {
                interactionText.text = TextHolder.instance.GetTutorialString(3);
                mouseSounds[Random.Range(0, mouseSounds.Length)].Play();
            }

            if (tutorialTicks == 300)
            {
                interactionText.text = TextHolder.instance.GetTutorialString(4);
                mouseSounds[Random.Range(0, mouseSounds.Length)].Play();
            }

            if (tutorialTicks == 400)
            {
                interactionText.text = TextHolder.instance.GetTutorialString(5);
                mouseSounds[Random.Range(0, mouseSounds.Length)].Play();
            }

            if (tutorialTicks == 500)
            {
                interactionText.text = TextHolder.instance.GetTutorialString(6);
                mouseSounds[Random.Range(0, mouseSounds.Length)].Play();
            }

            if (tutorialTicks == 600)
            {
                interactionText.text = TextHolder.instance.GetTutorialString(7);
                mouseSounds[Random.Range(0, mouseSounds.Length)].Play();
            }

            if(tutorialTicks == 700)
            {
                screenAnim.SetBool("enabled", false);
            }

            if (tutorialTicks == 900)
            {
                screenAnim.SetBool("enabled", true);
                interactionText.text = TextHolder.instance.GetTutorialString(8);
                mouseSounds[Random.Range(0, mouseSounds.Length)].Play();
            }

            if (tutorialTicks == 1000)
            {
                interactionText.text = TextHolder.instance.GetTutorialString(9);
                mouseSounds[Random.Range(0, mouseSounds.Length)].Play();
            }

            if (tutorialTicks == 1100)
            {
                screenAnim.SetBool("enabled", false);
                tutorialOn = false;
                FindObjectOfType<CommentController>().EnableComments();
            }
        }
        
        
    }

    public void AddMoney(float money)
    {
        currentMoney += money;
        var moneyInt = (int)currentMoney;
        moneyText.text = string.Format("{0:00000000}", moneyInt) + "$";
        Manager.instance.money = currentMoney;
    }

    private void InitTutorial()
    {
        

        if(tutorialOn)
        {
            screenAnim.SetBool("enabled", true);
            interactionText.text = TextHolder.instance.GetTutorialString(0);
            mouseSounds[Random.Range(0, mouseSounds.Length)].Play();
        }

    }

    public void ActivateScreen(string comment)
    {
        screenAnim.SetBool("enabled", true);
        interactionText.text = comment;
        mouseSounds[Random.Range(0, mouseSounds.Length)].Play();
    }

    public void DeactivateScreen()
    {
        screenAnim.SetBool("enabled", false);
    }
}


