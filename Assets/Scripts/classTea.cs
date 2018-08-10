using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class classTea
{
    // Constructor
    public classTea(string newName, double newPrice, double newDose, double newTime, double newImpress)
    {
        teaName = newName;
        price = newPrice;
        overDose = newDose;
        preparingTime = newTime;
        impressiveness = newImpress;
    }

    // Auto-generated get/set mess
    public string teaName { get; private set;  }

    public double price { get; private set;  }

    public double overDose { get; private set;  }

    public double preparingTime { get; private set; }

    public double impressiveness { get; private set;  }
}
