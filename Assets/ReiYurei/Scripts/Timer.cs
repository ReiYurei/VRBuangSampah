using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float s_gameTimer;
    //public float gameTimer;
    [SerializeField] private TMPro.TextMeshProUGUI timerText; //MANUALLY PUT
    public bool TimerTicking;

    public delegate void TimerAction();
    public static event TimerAction OnTimerEnd;

    private string minutes;
    private string seconds;

    void Start()
    {
        //s_gameTimer = gameTimer;
        minutes = Mathf.Floor(s_gameTimer / 60).ToString("00");
        seconds = Mathf.Floor(s_gameTimer % 60).ToString("00");
    }
    void Update()
    {
        if (s_gameTimer < 0)
        {
            TimerTicking = false;
            timerText.text = $" -- : -- ";
            if (OnTimerEnd != null)
            {
                OnTimerEnd();
            }

            return;
        }
        else if (TimerTicking == true)
        {
            s_gameTimer -= Time.deltaTime;
            minutes = Mathf.Floor(s_gameTimer / 60).ToString("00");
            seconds = Mathf.Floor(s_gameTimer % 60).ToString("00");
            timerText.text = $"{minutes} : {seconds}";
        }
        
    }
}
