using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterGridPosition : MonoBehaviour
{
    [SerializeField]
    private Vector2 gridPosition;

    public void SetGridPosition(Vector2 newPos)
    {
        gridPosition = newPos;
    }

    public Vector2 GetGridPosition()
    {
        return gridPosition;
    }
}
