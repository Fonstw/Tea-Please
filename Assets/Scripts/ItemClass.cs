using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemClass : MonoBehaviour
{
    // Pubic thingies
    public int identifier { get; private set; }
    public string itemName { get; private set; }
    public double time { get; private set; }
    public double dose { get; private set; }
    public double impress { get; private set; }

    // MYY THINGIES HISSSS
    private double timer;
    private bool run = false;

    void Update()
    {
        if (run)
        {
            // Count down by substracting amount of seconds elapsed between frames
            timer -= Time.deltaTime;

            // Done counting down?
            if (timer <= 0)
            {
                // Do overdosing and impressing things
                GetComponentInParent<stackBehaviour>().RemoveTea(identifier);
                Destroy(gameObject);
            }
        }
    }

    // So, this is kind of like a constructor because I'm lost on how to do this otherwise...
    public void MakeMe(int newID, string newName, double newTime, double newDose, double newImpress)
    {
        identifier = newID;
        itemName = newName;
        time = newTime; timer = newTime; run = true;
        dose = newDose;
        impress = newImpress;

        GetComponentInChildren<Text>().text = itemName;
    }
}
