﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class ArrayLayout  {

	[System.Serializable]
	public struct rowData{
		public char[] row;
	}

	public rowData[] rows = new rowData[7]; //Grid of 7x7
}
