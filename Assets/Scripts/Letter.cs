using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Letter : MonoBehaviour
{
    [SerializeField] private bool isClicked;
    [SerializeField] private Image letterBackground;
    [SerializeField] private TextMeshProUGUI letterText;
    [SerializeField] private char letterChar;


    private void Start()
    {
        // SetRandomLetter();
    }

    public void SetClicked()
    {
        isClicked = true;
        letterBackground.color = Color.red;
    }

    public void SetLetter(char newChar)
    {
        letterText.text = newChar.ToString();
    }

    public bool GetClickedStatus()
    {
        return isClicked;
    }
    
    public void SetRandomLetter()
    {
        letterChar = (char)('A' + Random.Range(0, 26));
        letterText.text = letterChar.ToString();
    }
    
    public char GetLetter()
    {
        // Debug.LogError("Char is  " + letterChar);
        return letterChar;
    }
}
