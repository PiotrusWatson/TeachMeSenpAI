using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ProfitScore : MonoBehaviour
{
    public int profitScore;
    public TextMeshProUGUI profitScoreText;


    private void Start()
    {
        profitScoreText.SetText("Profit: " + profitScore);
    }

    /* Decreases the profit score
     * checks if you are no longer making a profit
     * will cause game over if this occurs*/
    public void applyFine (int fineAmount)
    {
        profitScore -= fineAmount;

        profitScoreText.SetText("Profit: " + profitScore);

        if (profitScore < 0)
        {
            Debug.Log("GAME OVER!!! NO PROFIT!!!");
        }
    }
}
