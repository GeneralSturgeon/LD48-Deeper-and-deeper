using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mineable : MonoBehaviour
{
    public GameObject minePS;
    public float moneyToAdd = 10f;
    private GameObject currentPS;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("BeamCollider"))
        {
            currentPS = Instantiate(minePS, other.gameObject.transform.position, Quaternion.identity);
            currentPS.transform.SetParent(other.transform);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("BeamCollider"))
        {
            GameController.instance.AddMoney(moneyToAdd * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("BeamCollider"))
        {
            
            if(currentPS != null)
            {
                Destroy(currentPS);
            }
        }
    }
}
