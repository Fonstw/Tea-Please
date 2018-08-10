using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stackBehaviour : MonoBehaviour
{
    private List<classTea> actualStack = new List<classTea>();

    public void AddTea(classTea newTea)
    {
        actualStack.Add(newTea);
    }

    public int GetStackSize()
    {
        return actualStack.Count;
    }
}
