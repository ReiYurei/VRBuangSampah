using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float s_gameTimer;
    public float s_warnTimer;
    private SoundsManager sounds;

    //public float gameTimer;
    [SerializeField] private TMPro.TextMeshProUGUI timerText; //MANUALLY PUT
    public bool TimerTicking;
    private bool giveWarn;

    public delegate void TimerAction();
    public static event TimerAction OnTimerEndHandler;

    private string minutes;
    private string seconds;

    void Start()
    {
        sounds = SoundsManager.Instance;
        TimerTicking = false;
        GuidePage.OnGuideRead += StartTimer;
        minutes = Mathf.Floor(s_gameTimer / 60).ToString("00");
        seconds = Mathf.Floor(s_gameTimer % 60).ToString("00");
    }
    void Update()
    {
        
        if (s_gameTimer < 0)
        {
            TimerTicking = false;
            timerText.text = $" -- : -- ";
            timerText.gameObject.SetActive(false);
            if (OnTimerEndHandler != null)
            {
                OnTimerEndHandler();
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
        if (s_gameTimer <= s_warnTimer && giveWarn == true)
        {
            Warn();
        }

    }
    public void StartTimer()
    {
        TimerTicking = true;
        giveWarn = true;
        GuidePage.OnGuideRead -= StartTimer;
    }

    private void Warn()
    {
        sounds._SFXSource.PlayOneShot(sounds._Sfx[7]);
        giveWarn = false;
    }

}
