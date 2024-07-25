using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class TestScript : MonoBehaviour {

	public ArrayLayout data;

	private void Start()
	{
		// GetRowData();
		FillEmptyCells();
	}

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
