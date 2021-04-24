using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject obstacle;

    public void SpawnObstacle()
    {
        Vector3 point = (Random.insideUnitCircle).normalized;
        var obst = Instantiate(obstacle, transform.position + point + new Vector3(0f, 0f, 0.1f), Quaternion.identity);
        obst.transform.Rotate(new Vector3(0f, 0f, 90f + Mathf.Rad2Deg * Mathf.Atan2(transform.position.y - point.y, transform.position.x - point.x)));
        obst.transform.Translate(Vector3.up * 0.12f);
        obst.transform.SetParent(transform);
    }
}
