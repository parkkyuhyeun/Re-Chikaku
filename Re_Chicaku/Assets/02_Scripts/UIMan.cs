using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMan : MonoBehaviour
{
    [SerializeField] private BGMManager bgmManager;
    [SerializeField] private Player playerScript;

    [SerializeField] GameObject player;
    [SerializeField] TextMeshProUGUI currentScore_Txt;
    [SerializeField] TextMeshProUGUI bestScore_Txt;
    [SerializeField] TextMeshProUGUI overScore_Txt;
    [SerializeField] GameObject overUI;
    [SerializeField] GameObject settingUI;

    private int currentScore = 0;
    private int bestScore = 0;
    private int checkScore = 0;

    public bool isOpened;

    private void Start()
    {
        currentScore = 0;
        checkScore = 0;

        isOpened = false;
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
            currentScore_Txt.text = $"{currentScore} M";
            overScore_Txt.text = $"{currentScore} M";
            checkScore = currentScore;
        }

        if(currentScore > bestScore)
        {
            bestScore = currentScore;
            bestScore_Txt.text = $"{bestScore} M";
        }
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Restart()
    {
        StartCoroutine(Res());
    }

    public void Settings()
    {
        settingUI.SetActive(true);
        playerScript.gameStop = true;
        Time.timeScale = 0;
        isOpened = true;
    }

    public void CloseTap()
    {
        settingUI.SetActive(false);
        playerScript.gameStop = false;
        Time.timeScale = 1;
        isOpened = false;
    }

    IEnumerator Res()
    {
        yield return new WaitForSeconds(0.3f);
        bgmManager.MainBGM();
        player.transform.position = new Vector3(-30f, 0f, -1f);
        player.SetActive(true);
        currentScore_Txt.text = "0 M";
        checkScore = 0;
        currentScore = 0;

        overUI.SetActive(false);
    }
}
