using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ProfitScore : MonoBehaviour
{
    public int profitScore;
    public TextMeshProUGUI profitScoreText;

    public static bool win = false;

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
            SceneManager.LoadScene(2);

        }
    }
}
