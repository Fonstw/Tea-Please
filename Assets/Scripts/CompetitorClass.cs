using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompetitorClass
{
    public double impressiveness { get; private set; }
    public double overDose { get; private set; }
    public double money { get; private set; }
    public List<int> passiveSkills { get; private set; }
    public List<int> currentEffects { get; private set; }

    public const double winCondition = 60;
    public const double loseCondition = 20;

    public CompetitorClass(double startingMoney/*, List<int> characterSkills*/)
    {
        impressiveness = 0;
        overDose = 0;
        money = startingMoney;
        passiveSkills = new List<int>();
        currentEffects = new List<int>();

        //passiveSkills = characterSkills;
    }

    public void Pay(double amount)
    {
        money -= amount;
    }

    public void GainEffects(double impressGain, double doseGain, int effectGain)
    {
        impressiveness += impressGain;

        if (impressiveness >= winCondition)
        {
            Debug.Log("A winner is you");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);   // Restarts the game
        }
        else
        {
            overDose += doseGain;

            if (overDose >= loseCondition)
            {
                Debug.Log("YOU DIED");
                Application.Quit();
            }
            else if (!currentEffects.Contains(effectGain))
                currentEffects.Add(effectGain);
        }
    }

    public void HandleEffects()
    {
        // applies/handles all current active effects
        // decreases duration, removes effects accordingly
    }
}
