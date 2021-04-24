using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public GameObject wallPrefab;
    public float spacing = 2f;
    public float maxRandomOffset = 0.3f;
    public int number = 10;

    private void Start()
    {
        for (int x = 0; x < number; x++)
        {
            var newWall = Instantiate(wallPrefab, transform.position + new Vector3(Random.Range(-maxRandomOffset, maxRandomOffset), Random.Range(-maxRandomOffset, maxRandomOffset), spacing * x), Quaternion.identity);
            newWall.transform.SetParent(transform);
        }
        
    }

}
