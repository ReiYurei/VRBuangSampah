using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    public float score;
    [SerializeField] private TMPro.TextMeshProUGUI scoreText; //MANUALLY PUT
    public TMPro.TextMeshProUGUI finalScore;
    private void Start()
    {
        Timer.OnTimerEndHandler += HideText;

    }
    public void Update()
    {

        var text = Mathf.Floor(score).ToString("0000000");
        if (score >= 0)
        {
            scoreText.text = text;
            finalScore.text = text;

        }
        else if (score < 0)
        {
            scoreText.text = $"{text}";
            finalScore.text = $"{text}";
        }
    }

    public void HideText()
    {
        scoreText.gameObject.SetActive(false);
        Timer.OnTimerEndHandler -= HideText;
    }
}
