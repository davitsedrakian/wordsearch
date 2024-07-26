using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserIntefaceManager : MonoBehaviour
{

    [SerializeField] private MenuCanvas menuCanvas;
    [SerializeField] private GameCanvas gameCanvas;
    
    [SerializeField] private WinCanvas winCanvas;
    [SerializeField] private LoseCanvas loseCanvas;

    private void Start()
    {
        // menuCanvas.GetComponent<Canvas>().enabled = true;
    }

    public void InitializeGameplayCanvas(string[] words)
    {
        gameCanvas.InitializeWordViews(words);
    }

    public void CompleteWord(int id)
    {
        gameCanvas.CompleteWord(id);
    }

    public void ShowWinCanvas()
    {
        gameCanvas.enabled = false;
        menuCanvas.enabled = false;
        
        winCanvas.gameObject.SetActive(true);
    }

    public void ShowGameplayCanvas()
    {
        menuCanvas.gameObject.SetActive(false);
        gameCanvas.gameObject.SetActive(true);
    }

    public void ShowLoseCanvas()
    {
        gameCanvas.enabled = false;
        menuCanvas.enabled = false;
        
        loseCanvas.gameObject.SetActive(true);
    }
}
