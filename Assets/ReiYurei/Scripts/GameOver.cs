using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private SoundsManager sounds;
    public GameObject panel;

    public void OnEnable()
    {
        Timer.OnTimerEndHandler += OnGameOver;
        sounds = SoundsManager.Instance;
    }

    public void OnGameOver()
    {
        panel.SetActive(true);
        Timer.OnTimerEndHandler -= OnGameOver;
        sounds._SFXSource.PlayOneShot(sounds._Sfx[8]);
        sounds._MusicSource.Stop();
    }

    public void Retry()
    {
        SceneManager.LoadScene("Gameplay_Scene");
        sounds._SFXSource.PlayOneShot(sounds._Sfx[9]);
        Timer.OnTimerEndHandler -= OnGameOver;
    }


    public void MainMenu()
    {
        SceneManager.LoadScene("Menu_Scene");
        sounds._SFXSource.PlayOneShot(sounds._Sfx[9]);
        Timer.OnTimerEndHandler -= OnGameOver;

    }
}
