using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{


    [SerializeField] private string word;
    
    [SerializeField] private Letter firstLetter;
    [SerializeField] private Letter lastLetter;
    [SerializeField] private List<Letter> clickedLetters;

    [SerializeField] private LevelManager levelManager;

    private enum InputDirection
    {
        None,
        Up,
        Down,
        Left,
        Right,
        RightUp,
        RightDown,
        LeftDown,
        LeftUp
    }

    [SerializeField] private InputDirection currentInputDirection;


    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastToUI();
        }

        if (Input.GetMouseButtonUp(0))
        {
            //reset all
            currentInputDirection = InputDirection.None;
            firstLetter = null;
            lastLetter = null;
            word = null;

            for (int i = 0; i < clickedLetters.Count; i++)
            {
                clickedLetters[i].SetDefault();
            }
            
            clickedLetters.Clear();
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

                if (firstLetter && lastLetter && firstLetter != lastLetter)
                {
                    InputDirection newDirection = GetDirection(lastLetter.transform.position, letter.transform.position);
                    if (newDirection != currentInputDirection)
                    {
                        return;
                    }
                }
               
                
                Debug.Log("Hit: " + result.gameObject.name);
                if (!firstLetter) firstLetter = letter;

                lastLetter = letter;
                letter.SetClicked();
                char letterValue = letter.GetLetter();
                word += letterValue;
                
                clickedLetters.Add(letter);
                letter.SetClicked();
                
                levelManager.PlayPopSound();
                
                bool isCompleted = levelManager.CompareWords(word);

                if (isCompleted)
                {
                    for (int i = 0; i < clickedLetters.Count; i++)
                    {
                        clickedLetters[i].SetCompleted();
                        // levelManager.pla
                    }
                    clickedLetters.Clear();
                }

                if (currentInputDirection == InputDirection.None)
                {
                    InputDirection direction = GetDirection(firstLetter.transform.position, letter.transform.position);
                    currentInputDirection = direction;
                }
                
            }
        }
        
       
    }
    
    private InputDirection GetDirection(Vector3 from, Vector3 to)
    {
        Vector3 direction = (to - from).normalized;

        if (direction == Vector3.zero)
            return InputDirection.None;

        if (Mathf.Approximately(direction.x, 0))
        {
            if (direction.y > 0)
                return InputDirection.Up;
            else if (direction.y < 0)
                return InputDirection.Down;
        }
        else if (Mathf.Approximately(direction.y, 0))
        {
            if (direction.x > 0)
                return InputDirection.Right;
            else if (direction.x < 0)
                return InputDirection.Left;
        }
        else if (direction.x > 0 && direction.y > 0)
            return InputDirection.RightUp;
        else if (direction.x > 0 && direction.y < 0)
            return InputDirection.RightDown;
        else if (direction.x < 0 && direction.y < 0)
            return InputDirection.LeftDown;
        else if (direction.x < 0 && direction.y > 0)
            return InputDirection.LeftUp;

        return InputDirection.None;
    }
}
