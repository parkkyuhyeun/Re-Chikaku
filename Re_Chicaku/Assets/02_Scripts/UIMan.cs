using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMan : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] TextMeshProUGUI currentScore_Txt;
    [SerializeField] TextMeshProUGUI bestScore_Txt;

    private int currentScore = 0;
    private int bestScore = 0;
    private int checkScore = 0;

    private void Start()
    {
        currentScore = 0;
        checkScore = 0;
    }

    private void Update()
    {
        currentScore = (int)player.transform.position.x / 2;
        ChangeScoreText();
    }

    public void ChangeScoreText()
    {
        if(currentScore > checkScore)
        {
            currentScore_Txt.text = $"Distance traveled\n{currentScore} M";
            checkScore = currentScore;
        }

        if(currentScore > bestScore)
        {
            bestScore = currentScore;
            bestScore_Txt.text = $"Best Distance\n{bestScore} M";
        }
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
