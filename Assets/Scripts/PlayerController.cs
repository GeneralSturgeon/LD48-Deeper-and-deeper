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
    private float sideSpeedMultiplier = 1f;
    public float speed;
    public float kickbackForce = 50f;
    public float fireEnergyCost = 1;
    public float beamEnergyCost = 1.2f;
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
    private const int damageFromWall = 3;
    public GameObject beamCollider;
    private GameObject currentBeamCollider;
    private bool isAlive = true;
    public AudioSource laserSound;
    public AudioSource beamSound;
    public AudioSource noEnergySound;
    public AudioSource crashSound;
    public AudioSource retroBoosterSound;

    private void Start()
    {
        if (GameController.instance.tutorialOn)
        {
            speedbreak = 0.1f;
            sideSpeedMultiplier = 0.05f;
        }
        else
        {
            speedbreak = 1f;
            sideSpeedMultiplier = 1f;
        }
    }
    void Update()
    {
        if(isAlive)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                speedbreak = breakAmount;
                GameController.instance.energyRegen = 0f;
                retroBoosterSound.pitch = 0.8f;
                retroBoosterSound.Play();

            }

            if(Input.GetKey(KeyCode.Space))
            {
                CameraShake.instance.Shake(0.1f, 0.02f, 1f);
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                speedbreak = 1f;
                retroBoosterSound.pitch = 1.2f;
                retroBoosterSound.Play();
                if (currentBeam == null)
                {
                    GameController.instance.energyRegen = 0.05f;
                }
                
            }


            if (Input.GetMouseButtonDown(0))
            {
                if (GameController.instance.currentEnergy >= fireEnergyCost)
                {
                    GameController.instance.UseEnergy(fireEnergyCost);
                    Fire();
                    laserSound.Play();
                } else
                {
                    noEnergySound.Play();
                }

            }

            if (Input.GetMouseButtonDown(1))
            {
                if (GameController.instance.currentEnergy >= beamEnergyCost)
                {
                    InitializeBeam();
                    GameController.instance.energyRegen = 0f;
                    beamSound.Play();
                } else
                {
                    noEnergySound.Play();
                }
            }

            if (Input.GetMouseButton(1))
            {
                if (GameController.instance.currentEnergy >= beamEnergyCost * Time.deltaTime)
                {
                    UpdateBeam();
                } else
                {
                    DestroyBeam();
                    noEnergySound.Play();
                }
                
            }

            if (Input.GetMouseButtonUp(1))
            {
                DestroyBeam();
            }
        }
        
    }

    private void FixedUpdate()
    {
        var dir = ((new Vector3(horizontal, 0f, 0f) + new Vector3(0f, vertical, 0f)) * sideSpeed * sideSpeedMultiplier + new Vector3(0f, 0f, speed * speedbreak)) * Time.fixedDeltaTime;
        rb.AddForce(dir);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("SpawnTriggerBox"))
        {
            other.GetComponent<SpawnTriggerBox>().SpawnNext();
            speed += 5f;
        }

        if (other.gameObject.CompareTag("SpawnDestroyBox"))
        {
            other.GetComponent<SpawnDestroyBox>().DestroyChunk();
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            var dir = new Vector3(0f, 0f, transform.position.z - 1f) - transform.position;
            rb.AddForce(dir * kickbackForce);
            CameraShake.instance.Shake(0.2f, 0.04f, 1f);
            GameController.instance.TakeDamage(damageFromWall);
            crashSound.Play();
            if(other.gameObject.GetComponent<Destructable>() != null)
            {
                other.gameObject.GetComponent<Destructable>().Hit();
            }
        }

        if(other.gameObject.CompareTag("TutorialSpeedUp"))
        {
            speedbreak = 1f;
            sideSpeedMultiplier = 1f;
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

        if(currentBeamCollider != null)
        {
            currentBeamCollider.GetComponent<Rigidbody>().MovePosition(hitPos);
        }

        GameController.instance.UseEnergy(beamEnergyCost);
        CameraShake.instance.Shake(0.2f, 0.04f, 1f);
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

        if(!Input.GetKey(KeyCode.Space))
        {
            GameController.instance.energyRegen = 0.05f;
        }

        beamSound.Stop();
       

    }

    public void Death()
    {
        isAlive = false;
        rb.useGravity = true;
        speed /= 4;
        rb.AddTorque(20f, 0f, 0f);
    }
}
