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

    public void AddTea()
    {
        // Instantiate the prefab as an in-game object
        GameObject newItem = Instantiate(teaStatus, theStack.transform);

        // For some reason it gets set to x=-1020 and stuff, let's just fix that!
        newItem.GetComponent<RectTransform>().anchoredPosition = new Vector2(-67, -76);
    }
}