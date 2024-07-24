using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class GridGenerator : MonoBehaviour
{

    [SerializeField] private GameObject gridObject;
    [SerializeField] private RectTransform gridParent;
    [SerializeField] private int gridHeight;
    [SerializeField] private int gridWidth;
    [SerializeField] private float gridStep;


    private void Start()
    {
        GenerateGrid();
    }

    [ContextMenu("Create Grid")]
    public void GenerateGrid()
    {
        float totalWidth = (gridWidth - 1) * gridStep;
        float totalHeight = (gridHeight - 1) * gridStep;

        Vector3 startPosition = new Vector3(-totalWidth / 2, -totalHeight / 2, 0);

        for (int i = 0; i < gridHeight; i++)
        {
            for (int j = 0; j < gridWidth; j++)
            {
                Vector3 position = startPosition + new Vector3(i * gridStep, j * gridStep, 0);
                Instantiate(gridObject, position, Quaternion.identity, gridParent);
            }
        }
    }

}
