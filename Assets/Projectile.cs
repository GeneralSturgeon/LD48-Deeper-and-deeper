using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject hitPS;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            var PS = Instantiate(hitPS, transform.position, Quaternion.identity);
            Destroy(PS, 1f);
            Destroy(gameObject);
        }
    }
}
