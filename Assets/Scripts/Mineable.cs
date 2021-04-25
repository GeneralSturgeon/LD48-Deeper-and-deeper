using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mineable : MonoBehaviour
{
    public bool addLife;
    public bool addMoney;
    public bool addEnergy;
    public GameObject minePS;
    public float moneyToAdd = 10f;
    public float lifeToAdd = 10f;
    public float energyToAdd = 10f;
    private GameObject currentPS;
    public AudioSource beamHitSound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("BeamCollider"))
        {
            currentPS = Instantiate(minePS, other.gameObject.transform.position, Quaternion.identity);
            currentPS.transform.SetParent(other.transform);
            beamHitSound.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("BeamCollider"))
        {
            if(addMoney)
            {
                GameController.instance.AddMoney(moneyToAdd * Time.deltaTime);
            }

            if (addEnergy)
            {
                GameController.instance.RegainEnergy(moneyToAdd * Time.deltaTime);
            }

            if (addLife)
            {
                GameController.instance.Heal(moneyToAdd * Time.deltaTime);
            }

        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("BeamCollider"))
        {
            
            if (currentPS != null)
            {
                Destroy(currentPS);
            }
        }
        beamHitSound.Stop();
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(1))
        {
            beamHitSound.Stop();
        }
    }
}
