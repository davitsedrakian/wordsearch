using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordView : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI wordTMP;

    [SerializeField] private Image backgroundImage;

    public void SetText(string newText)
    {
        wordTMP.text = newText;
    }

    public void Complete()
    {
        backgroundImage.color = Color.green;
    }
}
