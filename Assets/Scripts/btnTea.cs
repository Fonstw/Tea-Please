using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnTea : MonoBehaviour
{
    public enum teaType { green = 1, black, white, oolong, puEhr, herbal = 0 }

    // UI.Text object holding the player's script thingy mess-up
    public Text playerRiches;
    // The tea's properties
    public string teaName;
    public double teaPrice, teaDose, teaTime, teaImpress;
    public int teaEffect;
    public teaType myType;

    public void AddTea()
    {
        CompetitorClass player = playerRiches.GetComponent<CompetitorClass>();

        // Let the player script figure out how to make me
        player.MakeTea(teaName, teaPrice, teaDose, teaTime, teaImpress, teaEffect, (int)myType);
    }
}
