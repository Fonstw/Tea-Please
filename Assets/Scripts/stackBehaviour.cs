using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stackBehaviour : MonoBehaviour
{
    public int maxSize = 4;
    private List<classTea> actualStack = new List<classTea>();

    public bool AddTea(classTea newTea)
    {
        // Limit the stack and tell if it worked
        if (GetStackSize() < maxSize)
        {
            actualStack.Add(newTea);
            return true;
        }
        else
            return false;
    }

    public int GetStackSize()
    {
        return actualStack.Count;
    }
}
