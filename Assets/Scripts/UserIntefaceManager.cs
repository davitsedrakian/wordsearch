using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserIntefaceManager : MonoBehaviour
{

    [SerializeField] private MenuCanvas menuCanvas;
    [SerializeField] private GameCanvas gameCanvas;
    
    [SerializeField] private WinCanvas winCanvas;
    [SerializeField] private LoseCanvas loseCanvas;



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
        
        winCanvas.ChangState(true);
        Debug.LogError("Win canvas show");
    }
}
