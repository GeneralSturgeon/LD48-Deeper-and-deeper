using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gemstone : MonoBehaviour
{
    public bool addLife;
    public bool addMoney;
    public bool addEnergy;
    public float moneyToAdd = 10f;
    public float lifeToAdd = 10f;
    public float energyToAdd = 10f;

    private void Start()
    {
        Destroy(gameObject, 10f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BeamCollider") || other.gameObject.CompareTag("Player"))
        {
            Pickup();
        }
    }

    private void Pickup()
    {
        if (addMoney)
        {
            GameController.instance.AddMoney(moneyToAdd);
        }

        if (addEnergy)
        {
            GameController.instance.RegainEnergy(moneyToAdd);
        }

        if (addLife)
        {
            GameController.instance.Heal(moneyToAdd);
        }

        Destroy(gameObject);
    }
}

