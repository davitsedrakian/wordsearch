using UnityEngine;

public class InputSlideDetector : MonoBehaviour
{
     public enum SlideDirection
    {
        None,
        Left,
        Right,
        Up,
        Down,
        RightUp,
        RightDown,
        LeftUp,
        LeftDown
    }

    public SlideDirection currentSlideDirection = SlideDirection.None;
    private Vector3 startMousePosition;
    private Vector3 currentMousePosition;
    public float slideThreshold = 50f; // Minimum distance to consider a slide

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            DetectSlideDirection();
        }

        if (Input.GetMouseButtonUp(0))
        {
            currentSlideDirection = SlideDirection.None;
        }
    }

    private void DetectSlideDirection()
    {
        currentMousePosition = Input.mousePosition;
        Vector3 slideVector = currentMousePosition - startMousePosition;

        if (slideVector.magnitude >= slideThreshold)
        {
            float angle = Mathf.Atan2(slideVector.y, slideVector.x) * Mathf.Rad2Deg;

            if (angle > -22.5f && angle <= 22.5f)
            {
                currentSlideDirection = SlideDirection.Right;
            }
            else if (angle > 22.5f && angle <= 67.5f)
            {
                currentSlideDirection = SlideDirection.RightUp;
            }
            else if (angle > 67.5f && angle <= 112.5f)
            {
                currentSlideDirection = SlideDirection.Up;
            }
            else if (angle > 112.5f && angle <= 157.5f)
            {
                currentSlideDirection = SlideDirection.LeftUp;
            }
            else if (angle > 157.5f || angle <= -157.5f)
            {
                currentSlideDirection = SlideDirection.Left;
            }
            else if (angle > -157.5f && angle <= -112.5f)
            {
                currentSlideDirection = SlideDirection.LeftDown;
            }
            else if (angle > -112.5f && angle <= -67.5f)
            {
                currentSlideDirection = SlideDirection.Down;
            }
            else if (angle > -67.5f && angle <= -22.5f)
            {
                currentSlideDirection = SlideDirection.RightDown;
            }

            // Update the start position to the current position to detect continuous sliding
            startMousePosition = currentMousePosition;
        }

        Debug.Log("Slide Direction: " + currentSlideDirection);
     }
}
