using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnTea : MonoBehaviour
{
    // The object to hold the stack
    public GameObject theStack;
    // The tea's properties
    public string teaName;
    public double teaPrice, teaDose, teaTime, teaImpress;

    public void AddTea()
    {
        // Tell the stack to add an item with my info
        if (theStack.GetComponent<stackBehaviour>().AddTea(teaName, teaDose, teaTime, teaImpress))
        {
            // If the tea was actually ordered, take the money for it
        }
    }
}
