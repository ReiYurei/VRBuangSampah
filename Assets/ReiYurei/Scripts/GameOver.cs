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
	sounds = SoundsManager.Instance;
        Timer.OnTimerEndHandler += OnGameOver;
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
        Timer.OnTimerEndHandler -= OnGameOver;
        sounds._SFXSource.PlayOneShot(sounds._Sfx[9]);
    }


    public void MainMenu()
    {	
        SceneManager.LoadScene("Menu_Scene");
        Timer.OnTimerEndHandler -= OnGameOver;
        sounds._SFXSource.PlayOneShot(sounds._Sfx[9]);
    }
}
