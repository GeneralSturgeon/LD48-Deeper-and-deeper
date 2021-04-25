using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public int health = 1;
    public GameObject deathPS;
    public GameObject[] drops;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Projectile"))
        {
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
        
        if(Random.Range(0, 8) == 0)
        {
            Drop();
        }

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

    private void Drop()
    {
        var rand = Random.Range(0, 12);

        switch (rand)
        {

            case 0:
                var gem = Instantiate(drops[0], transform.position, Quaternion.identity);
                gem.GetComponent<Rigidbody>().AddForce(new Vector3(-transform.position.x, -transform.position.y, 0f).normalized * 20f);
                gem.GetComponent<Rigidbody>().AddTorque(new Vector3(0f, 0f, 15f));
                break;

            case 1:
                var gem1 = Instantiate(drops[0], transform.position, Quaternion.identity);
                gem1.GetComponent<Rigidbody>().AddForce(new Vector3(-transform.position.x, -transform.position.y, 0f).normalized * 20f);
                gem1.GetComponent<Rigidbody>().AddTorque(new Vector3(0f, 0f, 15f));
                break;

            case 2:
                var gem2 = Instantiate(drops[0], transform.position, Quaternion.identity);
                gem2.GetComponent<Rigidbody>().AddForce(new Vector3(-transform.position.x, -transform.position.y, 0f).normalized * 20f);
                gem2.GetComponent<Rigidbody>().AddTorque(new Vector3(0f, 0f, 15f));
                break;

            case 3:
                var gem3 = Instantiate(drops[1], transform.position, Quaternion.identity);
                gem3.GetComponent<Rigidbody>().AddForce(new Vector3(-transform.position.x, -transform.position.y, 0f).normalized * 20f);
                gem3.GetComponent<Rigidbody>().AddTorque(new Vector3(0f, 0f, 15f));
                break;

            case 4:
                var gem4 = Instantiate(drops[1], transform.position, Quaternion.identity);
                gem4.GetComponent<Rigidbody>().AddForce(new Vector3(-transform.position.x, -transform.position.y, 0f).normalized * 20f);
                gem4.GetComponent<Rigidbody>().AddTorque(new Vector3(0f, 0f, 15f));
                break;

            case 5:
                var gem5 = Instantiate(drops[1], transform.position, Quaternion.identity);
                gem5.GetComponent<Rigidbody>().AddForce(new Vector3(-transform.position.x, -transform.position.y, 0f).normalized * 20f);
                gem5.GetComponent<Rigidbody>().AddTorque(new Vector3(0f, 0f, 15f));
                break;

            case 6:
                var gem6 = Instantiate(drops[2], transform.position, Quaternion.identity);
                gem6.GetComponent<Rigidbody>().AddForce(new Vector3(-transform.position.x, -transform.position.y, 0f).normalized * 20f);
                gem6.GetComponent<Rigidbody>().AddTorque(new Vector3(0f, 0f, 15f));
                break;

            case 7:
                var gem7 = Instantiate(drops[2], transform.position, Quaternion.identity);
                gem7.GetComponent<Rigidbody>().AddForce(new Vector3(-transform.position.x, -transform.position.y, 0f).normalized * 20f);
                gem7.GetComponent<Rigidbody>().AddTorque(new Vector3(0f, 0f, 15f));
                break;

            case 8:
                var gem8 = Instantiate(drops[2], transform.position, Quaternion.identity);
                gem8.GetComponent<Rigidbody>().AddForce(new Vector3(-transform.position.x, -transform.position.y, 0f).normalized * 20f);
                gem8.GetComponent<Rigidbody>().AddTorque(new Vector3(0f, 0f, 15f));
                break;

            case 9:
                var gem9 = Instantiate(drops[3], transform.position, Quaternion.identity);
                gem9.GetComponent<Rigidbody>().AddForce(new Vector3(-transform.position.x, -transform.position.y, 0f).normalized * 20f);
                gem9.GetComponent<Rigidbody>().AddTorque(new Vector3(0f, 0f, 15f));
                break;

            case 10:
                var gem10 = Instantiate(drops[3], transform.position, Quaternion.identity);
                gem10.GetComponent<Rigidbody>().AddForce(new Vector3(-transform.position.x, -transform.position.y, 0f).normalized * 20f);
                gem10.GetComponent<Rigidbody>().AddTorque(new Vector3(0f, 0f, 15f));
                break;

            case 11:
                var gem11 = Instantiate(drops[4], transform.position, Quaternion.identity);
                gem11.GetComponent<Rigidbody>().AddForce(new Vector3(-transform.position.x, -transform.position.y, 0f).normalized * 20f);
                gem11.GetComponent<Rigidbody>().AddTorque(new Vector3(0f, 0f, 15f));
                break;

            default:
                break;
        }
    }
}
