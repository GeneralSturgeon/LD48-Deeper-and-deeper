using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject gold;
    public GameObject amethyst;
    public GameObject diamond;

    public void SpawnObstacle()
    {

        Spawn();

        if(GameController.instance.distance > Random.Range(0f, 10f))
        {
            Spawn();
        }

        if (GameController.instance.distance > Random.Range(0f, 20f))
        {
            Spawn();
        }

        if (GameController.instance.distance > Random.Range(0f, 30f))
        {
            Spawn();
        }

        if (GameController.instance.distance > Random.Range(0f, 40f))
        {
            Spawn();
        }
    }

    public void SpawnGold()
    {
        Vector3 point = (Random.insideUnitCircle).normalized;
        var obst = Instantiate(gold, transform.position + point + new Vector3(0f, 0f, 0.1f), Quaternion.identity);
        obst.transform.Rotate(new Vector3(0f, 0f, 90f + Mathf.Rad2Deg * Mathf.Atan2(0f - point.y, 0f - point.x)));
        obst.transform.Translate(Vector3.up * 0.1f);
        obst.transform.SetParent(transform);
    }

    public void SpawnAmethyst()
    {
        Vector3 point = (Random.insideUnitCircle).normalized;
        var obst = Instantiate(amethyst, transform.position + point + new Vector3(0f, 0f, 0.1f), Quaternion.identity);
        obst.transform.Rotate(new Vector3(0f, 0f, 90f + Mathf.Rad2Deg * Mathf.Atan2(0f - point.y, 0f - point.x)));
        obst.transform.Translate(Vector3.up * 0.1f);
        obst.transform.SetParent(transform);
    }

    public void SpawnDiamond()
    {
        Vector3 point = (Random.insideUnitCircle).normalized;
        var obst = Instantiate(diamond, transform.position + point + new Vector3(0f, 0f, 0.1f), Quaternion.identity);
        obst.transform.Rotate(new Vector3(0f, 0f, 90f + Mathf.Rad2Deg * Mathf.Atan2(0f - point.y, 0f - point.x)));
        obst.transform.Translate(Vector3.up * 0.1f);
        obst.transform.SetParent(transform);
    }

    private void Spawn()
    {
        Vector3 point = (Random.insideUnitCircle).normalized;
        var obst = Instantiate(obstacles[Random.Range(0, obstacles.Length)], transform.position + point + new Vector3(0f, 0f, 0.1f), Quaternion.identity);
        obst.transform.Rotate(new Vector3(0f, 0f, 90f + Mathf.Rad2Deg * Mathf.Atan2(0f - point.y, 0f - point.x)));
        obst.transform.Translate(Vector3.up * 0.1f);
        obst.transform.SetParent(transform);
    }
}
