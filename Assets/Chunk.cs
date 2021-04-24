using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public GameObject wallPrefab;
    public GameObject spawnTriggerBox;
    public GameObject spawnDestroyBox;
    public float spacing = 2f;
    public float maxRandomOffset = 0.3f;
    public int number = 10;

    private void Start()
    {
        SpawnWalls();
    }

    public float GetChunkLength(bool withPadding)
    {
        if(withPadding == false)
        {
            return spacing * number;
        } else
        {
            return (spacing * number) + (2 * spacing);
        }
        
    }

    private void SpawnWalls()
    {
        for (int x = 0; x < number; x++)
        {
            var newWall = Instantiate(wallPrefab, transform.position + new Vector3(Random.Range(-maxRandomOffset, maxRandomOffset), Random.Range(-maxRandomOffset, maxRandomOffset), spacing * x), Quaternion.identity);
            newWall.transform.SetParent(transform);
            newWall.GetComponent<Wall>().SpawnObstacle();
            if(Random.Range(0, 100) + GameController.instance.distance/4 > 85)
            {
                newWall.GetComponent<Wall>().SpawnGold();
            }

            if (Random.Range(0, 100) + GameController.instance.distance / 4 > 100)
            {
                newWall.GetComponent<Wall>().SpawnAmethyst();
            }

            if (Random.Range(0, 100) + GameController.instance.distance / 4 > 105)
            {
                newWall.GetComponent<Wall>().SpawnDiamond();
            }


        }

        var triggerBox = Instantiate(spawnTriggerBox, transform.position + new Vector3(0f, 0f, spacing * number/4), Quaternion.identity);
        triggerBox.transform.SetParent(transform);

        var destroyBox = Instantiate(spawnDestroyBox, transform.position + new Vector3(0f, 0f, GetChunkLength(true)), Quaternion.identity);
        destroyBox.transform.SetParent(transform);
        destroyBox.GetComponent<SpawnDestroyBox>().SetChunk(this);
    }

}
