using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFade : MonoBehaviour
{
    public SpriteRenderer rend;
    public Color farColor;
    private Color origColor;
    private Transform player;
    [Range(5f, 25f)]
    public float colorShiftRange = 12f;
    private void Awake()
    {
        origColor = rend.color;
        rend.color = farColor;
    }

    private void Start()
    {

        if (FindObjectOfType<PlayerController>() != null)
        {
            player = FindObjectOfType<PlayerController>().transform;
        }
        else
        {
            Debug.Log("Could not find player");
        }
    }

    private void FixedUpdate()
    {
        var distZ = Mathf.Abs(transform.position.z - player.position.z) / colorShiftRange;
        rend.color = Color.Lerp(origColor, farColor, distZ);

    }
}
