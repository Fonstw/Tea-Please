using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnTea : MonoBehaviour
{
    // The object added to the stack
    public GameObject teaStatus;
    // The object to hold the stack
    public GameObject theStack;
    // The tea's properties
    private classTea myTea;   // Most original variable name since the invention of tea
    public string teaName;
    public double teaPrice, teaDose, teaTime, teaImpress;

    void Start()
    {
        myTea = new classTea(teaName, teaPrice, teaDose, teaTime, teaImpress);
    }

    public void AddTea()
    {
        // For easier typing
        int stackSize = theStack.GetComponent<stackBehaviour>().GetStackSize();

        // Instantiate the prefab as an in-game object
        GameObject newItem = Instantiate(teaStatus, theStack.transform);

        // Set its actual UI position (I think... I hope!)
        newItem.GetComponent<RectTransform>().anchoredPosition = new Vector2(-67, -(76 + 60 * stackSize));

        // Add the actual tea object to the actual list that is the stack
        theStack.GetComponent<stackBehaviour>().AddTea(myTea);
    }
}