using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMan : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] TextMeshProUGUI score_Txt;

    private int currentScore = 0;
    private int bestScore = 0;

    private void Update()
    {
        currentScore = (int)player.transform.position.x / 2;
        ChangeScoreText();
    }

    public void ChangeScoreText()
    {
        if(currentScore > bestScore)
        {
            score_Txt.text = $"Distance traveled\n{currentScore} M";
            bestScore = currentScore;
        }
    }
}
