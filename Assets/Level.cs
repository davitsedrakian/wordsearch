using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ArrayElement
{
    public char value; // Change from int to char
}

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class Level : ScriptableObject
{
    [SerializeField]
    private List<List<ArrayElement>> array2D = new List<List<ArrayElement>>();
    public List<List<ArrayElement>> Array2D
    {
        get { return array2D; }
        set { array2D = value; }
    }
    
}