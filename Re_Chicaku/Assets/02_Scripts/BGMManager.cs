using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    private AudioSource audioSource;

    private Scene scene;

    [SerializeField] public AudioClip titleBGM;
    [SerializeField] public AudioClip mainBGM;
    [SerializeField] public AudioClip gameoverBGM;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        scene = SceneManager.GetActiveScene();
        BGM();
    }

    private void BGM()
    {
        if(scene.name == "StartScene")
        {
            TitleBGM();
        }
        else if(scene.name == "GameView")
        {
            MainBGM();
        }
    }
    public void TitleBGM()
    {
        audioSource.clip = titleBGM;
        audioSource.Play();
    }
    public void GameoverBGM()
    {
        audioSource.clip = gameoverBGM;
        audioSource.Play();
    }
    public void MainBGM()
    {
        audioSource.clip = mainBGM;
        audioSource.Play();
    }
}
