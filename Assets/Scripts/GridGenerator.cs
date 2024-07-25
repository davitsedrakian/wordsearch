using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] private GameObject gridObject;
    [SerializeField] private RectTransform gridParent;
    [SerializeField] private int gridHeight;
    [SerializeField] private int gridWidth;
    [SerializeField] private float gridStep;
    [SerializeField] private List<string> levelWords;
    private GameObject[,] gridObjects;
    
    private void Start()
    {
        // GenerateGrid();
        // PlaceWordsInGrid();
    }

    [ContextMenu("Create Grid")]
    public void GenerateGrid()
    {
        float totalWidth = (gridWidth - 1) * gridStep;
        float totalHeight = (gridHeight - 1) * gridStep;

        gridObjects = new GameObject[gridHeight, gridWidth];
        Vector3 startPosition = new Vector3(-totalWidth / 2, -totalHeight / 2, 0);

        for (int i = 0; i < gridHeight; i++)
        {
            for (int j = 0; j < gridWidth; j++)
            {
                Vector3 position = startPosition + new Vector3(j * gridStep, i * gridStep, 0);
                GameObject newObject = Instantiate(gridObject, position, Quaternion.identity, gridParent);
                newObject.GetComponent<LetterGridPosition>().SetGridPosition(new Vector2(i, j));
                newObject.GetComponent<Letter>().SetLetter(' ');
                gridObjects[i, j] = newObject;
            }
        }

        Debug.Log(gridObjects.Length);
    }


    public void GenerateGrid(ArrayLayout rowData)
    {
        gridHeight = gridWidth = rowData.rows.Length;
        gridObjects = new GameObject[gridHeight, gridWidth];
        
        float totalWidth = (gridWidth - 1) * gridStep;
        float totalHeight = (gridHeight - 1) * gridStep;
        Vector3 startPosition = new Vector3(-totalWidth / 2, -totalHeight / 2, 0);
        //
        //
        for (int i = 0; i < gridHeight; i++)
        {
            for (int j = 0; j < gridWidth; j++)
            {
                Vector3 position = startPosition + new Vector3(j * gridStep, i * gridStep, 0);
                GameObject newObject = Instantiate(gridObject, position, Quaternion.identity, gridParent);
                newObject.GetComponent<LetterGridPosition>().SetGridPosition(new Vector2(i, j));
                newObject.GetComponent<Letter>().SetLetter(rowData.rows[gridHeight-1-i].row[j]);
                gridObjects[i, j] = newObject;
            }
        }
        
        // for (int i = 0; i < gridHeight; i++)
        // {
        //     for (int j = gridWidth-1; j >= 0; j--)
        //     {
        //         Vector3 position = startPosition + new Vector3(j * gridStep, i * gridStep, 0);
        //         GameObject newObject = Instantiate(gridObject, position, Quaternion.identity, gridParent);
        //         newObject.GetComponent<LetterGridPosition>().SetGridPosition(new Vector2(i, j));
        //         newObject.GetComponent<Letter>().SetLetter(rowData.rows[i].row[j]);
        //         gridObjects[i, j] = newObject;
        //     }
        // }
        
        // for (int i = gridHeight - 1; i >= 0; i--)
        // {
        //     for (int j = 0; j < gridWidth; j++)
        //     {
        //         Vector3 position = startPosition + new Vector3(j * gridStep, i * gridStep, 0);
        //         GameObject newObject = Instantiate(gridObject, position, Quaternion.identity, gridParent);
        //         newObject.GetComponent<LetterGridPosition>().SetGridPosition(new Vector2(i, j));
        //         newObject.GetComponent<Letter>().SetLetter(rowData.rows[i].row[j]);
        //         gridObjects[i, j] = newObject;
        //     }
        // }

        Debug.Log(gridObjects.Length);
        
        
        
    }
    
    // public void PlaceWordsInGrid()
    // {
    //     foreach (string word in levelWords)
    //     {
    //         char[] characters = WordToChar(word);
    //         Debug.LogError($"Word is {word}");
    //         bool placed = false;
    //
    //         // Try to place the word horizontally, vertically, or diagonally
    //         for (int i = 0; i < gridHeight && !placed; i++)
    //         {
    //             for (int j = 0; j < gridWidth && !placed; j++)
    //             {
    //                 if (CanPlaceWordHorizontally(i, j, characters.Length))
    //                 {
    //                     PlaceWordHorizontally(i, j, characters);
    //                     placed = true;
    //                 }
    //                 else if (CanPlaceWordVertically(i, j, characters.Length))
    //                 {
    //                     PlaceWordVertically(i, j, characters);
    //                     placed = true;
    //                 }
    //                 else if (CanPlaceWordDiagonally(i, j, characters.Length))
    //                 {
    //                     PlaceWordDiagonally(i, j, characters);
    //                     placed = true;
    //                 }
    //             }
    //         }
    //
    //         if (!placed)
    //         {
    //             Debug.LogWarning("Could not place word: " + word);
    //         }
    //     }
    // }

    public char[] WordToChar(string word)
    {
        return word.ToCharArray();
    }

    private bool CanPlaceWordHorizontally(int row, int col, int length)
    {
        if (col + length > gridWidth) return false;
        for (int i = 0; i < length; i++)
        {
            if (gridObjects[row, col + i].GetComponent<Letter>().GetLetter() != '0')
            {
                Debug.LogError("IS not empty");
                return false;
            }
        }
        return true;
    }

    private void PlaceWordHorizontally(int row, int col, char[] characters)
    {
        for (int i = 0; i < characters.Length; i++)
        {
            gridObjects[row, col + i].GetComponent<Letter>().SetLetter(characters[i]);
        }
    }

    private bool CanPlaceWordVertically(int row, int col, int length)
    {
        if (row + length > gridHeight) return false;
        for (int i = 0; i < length; i++)
        {
            if (gridObjects[row + i, col].GetComponent<Letter>().GetLetter() != ' ') return false;
        }
        return true;
    }

    private void PlaceWordVertically(int row, int col, char[] characters)
    {
        for (int i = 0; i < characters.Length; i++)
        {
            gridObjects[row + i, col].GetComponent<Letter>().SetLetter(characters[i]);
        }
    }

    private bool CanPlaceWordDiagonally(int row, int col, int length)
    {
        if (row + length > gridHeight || col + length > gridWidth) return false;
        for (int i = 0; i < length; i++)
        {
            if (gridObjects[row + i, col + i].GetComponent<Letter>().GetLetter() != ' ') return false;
        }
        return true;
    }

    private void PlaceWordDiagonally(int row, int col, char[] characters)
    {
        for (int i = 0; i < characters.Length; i++)
        {
            gridObjects[row + i, col + i].GetComponent<Letter>().SetLetter(characters[i]);
        }
    }
}


