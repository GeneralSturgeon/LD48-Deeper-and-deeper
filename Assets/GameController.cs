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
    private int currentHealth;
    [HideInInspector]
    public int currentEnergy;
    public Slider energySlider;
    public Slider healthSlider;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI distanceText;
    private float distance = 0f;
    


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
    }


    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        healthSlider.value = currentHealth;
        if(currentHealth <= 0)
        {
            Death();
        }
    }

    public void Heal (int heal)
    {
        currentHealth += heal;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthSlider.value = currentHealth;
    }

    public void UseEnergy(int energy)
    {
        currentEnergy -= energy;
        if(currentEnergy < 0)
        {
            currentEnergy = 0;
        }
        energySlider.value = currentEnergy;
    }

    private void Death()
    {
        Debug.Log("You died");
    }

    private void FixedUpdate()
    {
        UpdateDistanceText();
    }


    private void UpdateDistanceText()
    {
        if(FindObjectOfType<PlayerController>() != null)
        {
            distance = FindObjectOfType<PlayerController>().transform.position.z / 14f;
            distanceText.text = FormatDistance(distance) + "km";
        }
        
    }

    public string FormatDistance(float distance)
    {
        if(distance < 0f)
        {
            return string.Format("{0:00}.{1:0}", 0, 0);
        } else
        {
            int kilometers = (int)distance;
            int meters = (int)(10 * (distance - kilometers));
            return string.Format("{0:00}.{1:0}", kilometers, meters);
        }
        
    }
}
