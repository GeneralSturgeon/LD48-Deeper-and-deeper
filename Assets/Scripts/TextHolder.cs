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
    }

    public string GetTutorialString(int index)
    {
        return tutorialStrings[index];
    }

    public string GetRandomWittynessString()
    {
        return wittyStrings[Random.Range(0, wittyStrings.Length)];
    }
}
