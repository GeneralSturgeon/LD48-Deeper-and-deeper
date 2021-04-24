using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public int health = 1;
    public GameObject deathPS;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
            health--;
            if(health <= 0)
            {
                Death();
            }
        }
    }

    private void Death()
    {
        var ps = Instantiate(deathPS, transform.position, Quaternion.identity);
        Destroy(ps, 3f);
        Destroy(gameObject);
    }

    public void Hit()
    {
        health -= 3;
        if (health <= 0)
        {
            Death();
        }
    }
}
