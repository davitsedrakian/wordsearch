using NaughtyAttributes;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float timeRemaining;
    private bool timerIsRunning = false;
    [SerializeField] private int countdownTime;
    
    [Button]
    public void StartTimer()
    {
        ResetTimer(countdownTime);
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
        LevelManager.instance.LevelFailed();
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