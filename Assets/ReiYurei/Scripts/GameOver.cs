using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject panel;
    public void OnEnable()
    {
        Timer.OnTimerEndHandler += OnGameOver;
    }


    public void OnGameOver()
    {
        panel.SetActive(true);
        Timer.OnTimerEndHandler -= OnGameOver;

    }

    public void Retry()
    {
        SceneManager.LoadScene("Gameplay_Scene");
        Timer.OnTimerEndHandler -= OnGameOver;
    }


    public void MainMenu()
    {
        SceneManager.LoadScene("Menu_Scene");
        Timer.OnTimerEndHandler -= OnGameOver;

    }
}
