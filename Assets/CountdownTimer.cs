using NaughtyAttributes;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float timeRemaining;
    private bool timerIsRunning = false;
    
    [Button]
    public void StartTimer()
    {
        ResetTimer(120);
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                OnTimerEnd();
            }
        }
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
        timeToDisplay = Mathf.Clamp(timeToDisplay, 0, float.MaxValue);
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }

    void OnTimerEnd()
    {
        Debug.Log("Timer has ended!");
    }

    public void ResetTimer(float newTimeInSeconds)
    {
        timeRemaining = newTimeInSeconds;
        UpdateTimerDisplay(timeRemaining);
        timerIsRunning = true;
    }

    public void ResetTimerToOneMinute()
    {
        ResetTimer(60);
    }
}