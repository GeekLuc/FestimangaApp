// Rougefort Luca
// 2024
// Project Application Festimanga
// DragImage.cs
// This script allows dragging and zooming of an image using touch gestures.
using UnityEngine;
using UnityEngine.EventSystems;

public class DragImage : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    private Vector3 pointerOffset;
    private float zoomSpeed = 0.005f; // Zoom speed, adjust as needed
    private float previousTouchDistance;
    private Vector3 initialScale;
    private Vector3 initialPosition; // Variable pour stocker la position initiale
    public float minZoomScale = 0.5f; // Minimum zoom scale
    public float maxZoomScale = 2f; // Maximum zoom scale

    void Start()
    {
        // Store the initial scale and position of the image
        initialScale = transform.localScale;
        initialPosition = transform.position; // Stocker la position initiale
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Calculate the offset between the image position and the touch point
        Vector3 screenPoint = new Vector3(eventData.position.x, eventData.position.y, Camera.main.nearClipPlane);
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);
        pointerOffset = transform.position - worldPoint;

        // If there are two touches, store the initial distance between them
        if (Input.touchCount == 2)
        {
            previousTouchDistance = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Handle dragging with one touch
        if (Input.touchCount == 1)
        {
            Vector3 screenPoint = new Vector3(eventData.position.x, eventData.position.y, Camera.main.nearClipPlane);
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);
            transform.position = worldPoint + pointerOffset;
        }

        // Handle zooming with two touches
        if (Input.touchCount == 2)
        {
            float touchDistance = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
            float deltaDistance = previousTouchDistance - touchDistance;

            // Zoom in/out with pinch gesture
            Vector3 targetScale = initialScale * (1 - deltaDistance * zoomSpeed);

            // Check zoom limits
            if (targetScale.x >= minZoomScale && targetScale.x <= maxZoomScale)
            {
                transform.localScale = targetScale;
                // Update initialScale each frame during zoom
                initialScale = transform.localScale;
            }

            // Si la taille minimale est atteinte, réinitialiser la position
            if (targetScale.x <= minZoomScale)
            {
                transform.position = initialPosition;
            }

            previousTouchDistance = touchDistance;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Update initialScale after each zoom
        if (Input.touchCount == 2)
        {
            previousTouchDistance = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
            initialScale = transform.localScale;
        }
    }
}

