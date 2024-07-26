using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Letter : MonoBehaviour
{
    [SerializeField] private bool isClicked;
    [SerializeField] private bool isCompleted;
    [SerializeField] private Image letterBackground;
    [SerializeField] private TextMeshProUGUI letterText;
    [SerializeField] private char letterChar;

    

    public void SetClicked()
    {
        isClicked = true;
        letterBackground.color = new Color32(143, 81, 237,255);
        Bounce();
    }
    
    public void SetCompleted()
    {
        isClicked = false;
        isCompleted = true;
        letterBackground.color = new Color32(122, 235, 124,255);
        Bounce();
    }


    public void SetLetter(char newChar)
    {
        letterText.text = newChar.ToString();
        letterChar = newChar;

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
        return letterChar;
    }

    public void SetDefault()
    {
        if (isCompleted)
        {
            letterBackground.color = new Color32(122, 235, 124,255);
        }
        else
        {
            letterBackground.color = Color.white;
        }
        
        isClicked = false;
       
    }
    
    void Bounce()
    {
        Sequence bounceSequence = DOTween.Sequence()
            .Append(transform.DOScale(1.2f, 0.2f))
            .Append(transform.DOScale(0.95f, 0.2f))
            .Append(transform.DOScale(1f, 0.2f));
    }

    private void OnDestroy()
    {
        DOTween.KillAll();
    }
}
