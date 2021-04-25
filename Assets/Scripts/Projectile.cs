using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject hitPS;
    public AudioSource hitSound;
    public SpriteRenderer rend;
    public SphereCollider coll;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            var PS = Instantiate(hitPS, transform.position, Quaternion.identity);
            Destroy(PS, 1f);
            hitSound.Play();
            coll.enabled = false;
            rend.enabled = false;
            Destroy(gameObject, 1f);
        }
    }
}
