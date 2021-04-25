using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextHolder : MonoBehaviour
{
    public static TextHolder instance;

    public string[] tutorialStrings;
    public string[] wittyStrings;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    public string GetTutorialString(int index)
    {
        return tutorialStrings[index];
    }

    public string GetRandomWittynessString()
    {
        return wittyStrings[Random.Range(0, wittyStrings.Length)];
    }

    public string FormatDistance(float distance)
    {
        if (distance < 0f)
        {
            return string.Format("{0:00}.{1:0}", 0, 0);
        }
        else
        {
            int kilometers = (int)distance;
            int meters = (int)(10 * (distance - kilometers));
            return string.Format("{0:00}.{1:0}", kilometers, meters);
        }

    }
}
