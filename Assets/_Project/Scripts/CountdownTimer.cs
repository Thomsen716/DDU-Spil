using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining = 60f;
    public TextMeshProUGUI timerText;

    private bool timerFinished = false;

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining = 0;

            if (!timerFinished)
            {
                timerFinished = true;
                TimerFinished();
            }
        }

        timerText.text = Mathf.Ceil(timeRemaining).ToString();
    }

    void TimerFinished()
    {
        Debug.Log("Time's Up!");
    }
}