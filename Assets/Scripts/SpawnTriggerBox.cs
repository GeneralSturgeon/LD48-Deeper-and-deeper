using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTriggerBox : MonoBehaviour
{
    public void SpawnNext()
    {
        ChunkController.instance.SpawnChunk();
        Destroy(gameObject);
    }
}
