using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{


    [SerializeField] private string word;
    
    [SerializeField] private Letter firstLetter;
    [SerializeField] private Letter lastLetter;
    
    void Update()
    {
        if (Input.GetMouseButton(0)) // Check if the left mouse button is held down
        {
            RaycastToUI();
        }
    }

    private void RaycastToUI()
    {

        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };
        
        
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);
        
        foreach (RaycastResult result in results)
        {
            if (result.gameObject.TryGetComponent(out Letter letter))
            {
                if (letter.GetClickedStatus()) return;
                Debug.Log("Hit: " + result.gameObject.name);
                if (!firstLetter) firstLetter = letter;

                lastLetter = letter;
                letter.SetClicked();
                char letterValue = letter.GetValue();
                word += letterValue;
                
                letter.SetClicked();

                Vector2 firstLetterPositions =
                    firstLetter.gameObject.GetComponent<LetterGridPosition>().GetGridPosition();
                Vector2 lastLetterPositions =
                    lastLetter.gameObject.GetComponent<LetterGridPosition>().GetGridPosition();;

                float xDiff = Mathf.Abs(firstLetterPositions.x - lastLetterPositions.x);
                float yDiff = Mathf.Abs(firstLetterPositions.y - lastLetterPositions.y);

                if (xDiff == 1 && yDiff == 0)
                {
                    Debug.Log("The positions are side by side horizontally.");
                }
                else if (xDiff == 0 && yDiff == 1)
                {
                    Debug.Log("The positions are side by side vertically.");
                }
                else if (xDiff == 1 && yDiff == 1)
                {
                    Debug.Log("The positions are diagonally adjacent.");
                }
                else
                {
                    Debug.Log("The positions are not adjacent.");
                }
                
                
            }
        }
        
       
    }
}
