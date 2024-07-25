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
    [SerializeField] private float gridYOffset;
    
    private GameObject[,] gridObjects;
    


    public void GenerateGrid(ArrayLayout rowData)
    {
        gridHeight = gridWidth = rowData.rows.Length;
        gridObjects = new GameObject[gridHeight, gridWidth];
        
        float totalWidth = (gridWidth - 1) * gridStep;
        float totalHeight = (gridHeight - 1) * gridStep;
        Vector3 startPosition = new Vector3(-totalWidth / 2, -totalHeight / 2, 0);
  

        for (int i = 0; i < gridHeight; i++)
        {
            for (int j = 0; j < gridWidth; j++)
            {
                Vector3 position = startPosition + new Vector3(j * gridStep, i * gridStep, 0)+ new Vector3(0,gridYOffset,0);;
                GameObject newObject = Instantiate(gridObject, position, Quaternion.identity, gridParent);
                newObject.GetComponent<LetterGridPosition>().SetGridPosition(new Vector2(i, j));
                newObject.GetComponent<Letter>().SetLetter(rowData.rows[gridHeight-1-i].row[j]);
                gridObjects[i, j] = newObject;
            }
        }
        
        Debug.Log(gridObjects.Length);
    }
    
    
}


