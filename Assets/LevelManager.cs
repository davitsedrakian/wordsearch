using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private UserIntefaceManager userIntefaceManager;
    
    [SerializeField] private LevelWordsSO[] levelWordsSO;

    [SerializeField] private GridGenerator gridGenerator;
    [SerializeField] private string[] levelWords;
    [SerializeField] private int wordCount;

    private void Start()
    {
        CreateLevel();
    }

    public void CreateLevel()
    {
        GenerateGrid();
    }

    [Button]
    public void GenerateGrid()
    {
        levelWords = levelWordsSO[0].GetLevelWords();
        wordCount = levelWords.Length;
        ArrayLayout data = levelWordsSO[0].data;
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
        userIntefaceManager.ShowWInCanvas();
    }
}
