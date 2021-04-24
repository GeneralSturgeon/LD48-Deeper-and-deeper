using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float vertical;
    private float horizontal;
    private float speedbreak;
    public float breakAmount = 0.5f;
    public float sideSpeed;
    public float speed;
    [SerializeField]
    private Rigidbody rb;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if(Input.GetKey(KeyCode.Space))
        {
            speedbreak = breakAmount;
        } else
        {
            speedbreak = 1f;
        }
    }

    private void FixedUpdate()
    {
        var dir = ((new Vector3(horizontal, 0f, 0f) + new Vector3(0f, vertical, 0f)) * sideSpeed + new Vector3(0f, 0f, speed * speedbreak)) * Time.fixedDeltaTime;
        rb.AddForce(dir);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Hit wall");
        }
    }
}
