using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDestroyBox : MonoBehaviour
{
    private Chunk thisChunk;


    public void SetChunk(Chunk chunk)
    {
        thisChunk = chunk;
    }
    public void DestroyChunk()
    {
        Destroy(thisChunk.gameObject);
    }
}
