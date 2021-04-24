using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkController : MonoBehaviour
{
    public static ChunkController instance;

    public GameObject chunkPrefab;
    [HideInInspector]
    public Vector3 currentSpawnPoint = new Vector3(0f, 0f, 0f);


    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        } else
        {
            instance = this;
        }
    }
    private void Start()
    {
        SpawnChunk();
    }

    public void SpawnChunk()
    {
        var newChunk = Instantiate(chunkPrefab, currentSpawnPoint, Quaternion.identity);

        // Get spawn point for next chunk
        currentSpawnPoint += new Vector3(0f, 0f, newChunk.GetComponent<Chunk>().GetChunkLength(false));
    }
}
