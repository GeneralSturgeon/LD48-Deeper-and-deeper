﻿using System.Collections;
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
    public float kickbackForce = 50f;
    public int fireEnergyCost = 1;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private SphereCollider col;
    public LayerMask mask;
    private Vector3 hitPos;
    public Transform projectileSpawn;
    public GameObject projectile;
    public float projectileForce;
    public GameObject beam;
    private GameObject currentBeam;
    private const int damageFromWall = 6;
    public GameObject beamCollider;
    private GameObject currentBeamCollider;

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

        if(Input.GetMouseButtonDown(0))
        {
            if(GameController.instance.currentEnergy >= fireEnergyCost)
            {
                GameController.instance.UseEnergy(fireEnergyCost);
                Fire();
            }
            
        }

        if(Input.GetMouseButtonDown(1))
        {
            InitializeBeam();
        }

        if(Input.GetMouseButton(1))
        {
            UpdateBeam();
        }

        if(Input.GetMouseButtonUp(1))
        {
            DestroyBeam();
        }
    }

    private void FixedUpdate()
    {
        var dir = ((new Vector3(horizontal, 0f, 0f) + new Vector3(0f, vertical, 0f)) * sideSpeed + new Vector3(0f, 0f, speed * speedbreak)) * Time.fixedDeltaTime;
        rb.AddForce(dir);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("SpawnTriggerBox"))
        {
            other.GetComponent<SpawnTriggerBox>().SpawnNext();
            Debug.Log("Spawned");
        }

        if (other.gameObject.CompareTag("SpawnDestroyBox"))
        {
            other.GetComponent<SpawnDestroyBox>().DestroyChunk();
            Debug.Log("Destroyed");
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            var dir = new Vector3(0f, 0f, transform.position.z - 1f) - transform.position;
            rb.AddForce(dir * kickbackForce);
            CameraShake.instance.Shake(0.2f, 0.04f, 1f);
            GameController.instance.TakeDamage(damageFromWall);
            if(other.gameObject.GetComponent<Destructable>() != null)
            {
                other.gameObject.GetComponent<Destructable>().Hit();
            }
        }
    }

    private void Fire()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, mask))
        {
            hitPos = hit.point;
        }

        var proj = Instantiate(projectile, transform.position, Quaternion.identity);
        //proj.transform.LookAt(hitPos);
        var dir = (hitPos - proj.transform.position).normalized;
        proj.GetComponent<Rigidbody>().AddForce(dir * projectileForce);
        Destroy(proj.gameObject, 2f);
        CameraShake.instance.Shake(0.1f, 0.02f, 1f);

    }

    private void InitializeBeam()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 20f, mask))
        {
            hitPos = hit.point;
        }

        currentBeam = Instantiate(beam, projectileSpawn.position, Quaternion.identity);
        currentBeam.GetComponent<LineRenderer>().SetPosition(0, projectileSpawn.position);
        currentBeam.GetComponent<LineRenderer>().SetPosition(1, hitPos);
        currentBeamCollider = Instantiate(beamCollider, hitPos, Quaternion.identity);
    }

    private void UpdateBeam()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 20f, mask))
        {
            hitPos = hit.point;
        }

        if(currentBeam != null)
        {
            currentBeam.GetComponent<LineRenderer>().SetPosition(0, projectileSpawn.position);
            currentBeam.GetComponent<LineRenderer>().SetPosition(1, hitPos);
        }

        currentBeamCollider.GetComponent<Rigidbody>().MovePosition(hitPos);
        
    }

    private void DestroyBeam()
    {
        if(currentBeam != null)
        {
            Destroy(currentBeam);
        }

        if(currentBeamCollider != null)
        {
            Destroy(currentBeamCollider, 0.1f);
        }
        
    }
}
