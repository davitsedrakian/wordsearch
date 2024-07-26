using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using Smashlab.Pattern;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{

    [SerializeField] private UserIntefaceManager userIntefaceManager;
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private CountdownTimer countDownTimer;
    [SerializeField] private PlayerInput playerInput;
    
    [SerializeField] private LevelWordsSO[] levelWordsSO;

    [SerializeField] private GridGenerator gridGenerator;
    [SerializeField] private string[] levelWords;
    [SerializeField] private int wordCount;
    [SerializeField] private int level;

    public void CreateLevel()
    {
        userIntefaceManager.ShowGameplayCanvas();
        GenerateGrid();
        countDownTimer.StartTimer();
        playerInput.enabled = true;
    }

    [Button]
    public void GenerateGrid()
    {

        level = PlayerPrefs.GetInt("level_number", 0);
        
        if (level >= levelWordsSO.Length)
        {
            level -= levelWordsSO.Length;
        }
        
        levelWords = levelWordsSO[level].GetLevelWords();
        wordCount = levelWords.Length;
        ArrayLayout data = levelWordsSO[level].data;
        gridGenerator.GenerateGrid(data);
        
        userIntefaceManager.InitializeGameplayCanvas(levelWords);
    }

    public bool CompareWords(string playerCollectedWord)
    {
        // Debug.LogError($"Compare Words - {playerCollectedWord}");
        for (int i = 0; i < levelWords.Length; i++)
        {
            if (playerCollectedWord.Equals(levelWords[i]))
            {
                userIntefaceManager.CompleteWord(i);
                wordCount--;
                if (wordCount == 0)
                {
                    LevelPassed();
                }
                return true;
            }
        }

        return false;
    }

    public void LevelPassed()
    {
        userIntefaceManager.ShowWinCanvas();
        level++;
        PlayerPrefs.SetInt("level_number",level);
        playerInput.enabled = false;
    }

    public void PlayPopSound()
    {
        soundManager.PlayPopSound();
    }

    public void LevelFailed()
    {
        userIntefaceManager.ShowLoseCanvas();
        playerInput.enabled = false;
    }
}
