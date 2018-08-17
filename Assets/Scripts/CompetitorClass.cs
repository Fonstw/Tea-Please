using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CompetitorClass : MonoBehaviour
{
    // The object to hold the stack
    public GameObject theStack;
    public bool playerStatus;
    private Text moneyDisplay;

    public double money = 60;
    public List<int> passiveSkills = new List<int>();

    public double impressiveness { get; private set; }
    public double overDose { get; private set; }
    public int[] currentEffects { get; private set; }

    public const double winCondition = 60;
    public const double loseCondition = 20;
    private const int numberOfEffects = 1;

    void Start()
    {
        impressiveness = 0;
        overDose = 0;
        currentEffects = new int[numberOfEffects];

        moneyDisplay = GetComponent<Text>();
        moneyDisplay.text = money.ToString();
    }

    void Update()
    {
        if (currentEffects[0] > 0)   // Silver Needle
        {
            money += (1 + 1 / 3);
            currentEffects[0]--;
        }
    }

    public void MakeTea(string teaName, double teaPrice, double teaDose, double teaTime, double teaImpress, int teaEffect, int teaType)
    {
        // G. Orwell "All are equal, but some are more equal than others."
        if (passiveSkills.Contains(1))
        {
            if (teaImpress < 4)
                teaPrice++;
            else
                teaPrice--;
        }

        // G. Orwell "A Nice Cup of Tea"
        if (passiveSkills.Contains(2))
        {
            if (teaType == 2)   // Black
                teaTime++;
            else   // Everything else
            {
                teaImpress -= 2;

                if (teaImpress < 0)
                    teaImpress = 0;
            }
        }

        if (money >= teaPrice && theStack.GetComponent<stackBehaviour>().AddTea(teaName, teaDose, teaTime, teaImpress, teaEffect))
        {
            money -= teaPrice;

        }
    }

    public void Pay(double amount)
    {
        money -= amount;
    }

    // The first key of effectGain is the index of the effect, the second key of effectGain is the duration of the effect
    public void GainEffects(double impressGain, double doseGain, int[] effectGain)
    {
        impressiveness += impressGain;

        if (impressiveness >= winCondition)
        {
            print("A winner is you");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);   // Restarts the game
        }
        else
        {
            overDose += doseGain;

            if (overDose >= loseCondition)
            {
                print("YOU DIED");
                Application.Quit();
            }
            else if (currentEffects[effectGain[0]] < effectGain[1])
                currentEffects[effectGain[0]] = effectGain[1];
        }
    }
}
