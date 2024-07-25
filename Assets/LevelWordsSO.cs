using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level", order = 1)]
public class LevelWords : ScriptableObject
{
    public ArrayLayout data;
    
    
    public void GetRowData()
    {
        for (int i = 0; i < data.rows.Length; i++)
        {
            for (int j = 0; j <  data.rows[i].row.Length; j++)
            {
                Debug.LogError("data rows " + data.rows[i].row[j]);
            }
        }
    }
    
    public void FillEmptyCells()
    {
        for (int i = 0; i < data.rows.Length; i++)
        {
            for (int j = 0; j <  data.rows[i].row.Length; j++)
            {
                Debug.LogError("data rows " + data.rows[i].row[j]);
                if (data.rows[i].row[j] == '\0')
                {
                    int randomValue = Random.Range(65, 91); 
                    data.rows[i].row[j] = (char)randomValue;
                    Debug.LogError("Row is empty");
                }
            }
        }
    }
}
