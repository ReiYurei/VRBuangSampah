using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static float s_gameTimer;
    public float gameTimer;
    [SerializeField] private TMPro.TextMeshProUGUI timerText; //MANUALLY PUT
    public static bool TimerTicking;

    private string minutes;
    private string seconds;

    void Start()
    {
        s_gameTimer = gameTimer;
        minutes = Mathf.Floor(s_gameTimer / 60).ToString("00");
        seconds = Mathf.Floor(s_gameTimer % 60).ToString("00");
    }
    void Update()
    {
        if (TimerTicking == true)
        {
            s_gameTimer -= Time.deltaTime;
        }
        minutes = Mathf.Floor(s_gameTimer / 60).ToString("00");
        seconds = Mathf.Floor(s_gameTimer % 60).ToString("00");
        timerText.text = $"{minutes} : {seconds}";
    }
}
