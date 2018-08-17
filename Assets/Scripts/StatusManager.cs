using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : Singleton<StatusManager>
{
    protected StatusManager() { } // guarantee this will be always a singleton only - can't use the constructor!
    
    public double playerMoney, AIMoney;
    public Text setPlayerText, setAIText;

    // competitors[0]=player, competitors[1]=AI
    private static CompetitorClass[] competitors = new CompetitorClass[2];

    private static Text playerText, AIText;

    void Start()
    {
        // Initialize both competitors with their respective starting money. I would've used arrays and a for-loop if there were much more of them but alas.
        competitors[0] = new CompetitorClass(playerMoney);
        competitors[1] = new CompetitorClass(AIMoney);

        // Make sure I have static Text objects. Again, would've been arrays if there were more players
        playerText = setPlayerText;
        AIText = setAIText;

        // Show inital money amounts
        playerText.text = playerMoney.ToString();
        AIText.text = AIMoney.ToString();
    }

    public static bool HasMoney(bool player, double amount)
    {
        switch (player)
        {
            case true:   // Player
                return amount <= competitors[0].money;
            default:   // Not player / AI
                return amount <= competitors[1].money;
        }
    }

    public static void PayUp(bool player, double amount)
    {
        switch (player)
        {
            case true:   // Player
                //competitors[0].money -= amount;
                competitors[0].Pay(amount);
                playerText.text = competitors[0].money.ToString();
                break;
            default:   // AI
                //competitors[1].money -= amount;
                competitors[1].Pay(amount);
                AIText.text = competitors[1].money.ToString();
                break;
        }
    }
}
