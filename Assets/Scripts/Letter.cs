using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    [SerializeField] private Image letterBackground;

    public void SetClicked()
    {
        letterBackground.color = Color.red;
    }
}
