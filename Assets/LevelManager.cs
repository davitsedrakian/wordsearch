using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private LevelWordsSO levelWordsSO;

    [SerializeField] private GridGenerator gridGenerator;
    [SerializeField] private string[] levelWords;

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
        levelWords = levelWordsSO.GetLevelWords();
        ArrayLayout data = levelWordsSO.data;
        gridGenerator.GenerateGrid(data);
    }

    public bool CompareWords(string playerCollectedWord)
    {
        // Debug.LogError($"Compare Words - {playerCollectedWord}");
        for (int i = 0; i < levelWords.Length; i++)
        {
            if (playerCollectedWord.Equals(levelWords[i]))
            {
                // Debug.Log("Match found");
                // Debug.Log("Id of found word is " + i);
                // levelWords[i] = "Completed";
                return true;
            }
        }

        return false;
    }
}
