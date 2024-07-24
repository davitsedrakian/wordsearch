using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{

    [SerializeField] private Transform firstObject;
    [SerializeField] private Transform lastObject;
    
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
                Debug.Log("Hit: " + result.gameObject.name);
                if (!firstObject) firstObject = result.gameObject.transform;

                lastObject = result.gameObject.transform;
                letter.SetClicked();
            }
        }
        
       
    }
}
