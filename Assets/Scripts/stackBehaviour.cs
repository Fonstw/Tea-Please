using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stackBehaviour : MonoBehaviour
{
    public GameObject itemPrefab;
    public int maxSize = 4;
    private GameObject[] actualStack;

    void Start()
    {
        actualStack = new GameObject[maxSize];
    }

    public bool AddTea(string newName, double newDose, double newTime, double newImpress, int newEffect)
    {
        // For legibility
        int index = FindFirstEmpty();

        // Check if there's any spot left
        if (index != -1)
        {
            // Let's instantiate it into a new object so that we can easily modify it in code
            GameObject newTea = Instantiate(itemPrefab);
            // Put in in me
            newTea.transform.SetParent(transform, false);
            // Set it's actual location on screen... I hope.
            newTea.GetComponent<RectTransform>().anchoredPosition = new Vector2(-124, -126 - index*60);
            // Fill in item's data
            newTea.GetComponent<ItemClass>().MakeMe(index, newName, newDose, newTime, newImpress, newEffect);

            // Now that it's all set up, let's actually keep track of it!
            actualStack[index] = newTea;

            // Tell that it worked!
            return true;
        }
        else
            // Tell that it didn't work...
            return false;
    }

    public void RemoveTea(int place)
    {
        actualStack[place] = null;
    }

    private int FindFirstEmpty()
    {
        // Go through the array of objects
        for (int e=0; e<maxSize; e++)
        {
            // As soon as you hit an empty one...
            if (actualStack[e] == null)
                // ...tell where you found it!
                return e;
        }

        // Still nothing? Return an impossible number to tell them it won't do!
        return -1;
    }
}
