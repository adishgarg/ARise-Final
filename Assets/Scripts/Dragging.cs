using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private Camera arCamera;
    private Vector3 offset;
    private bool isDragging = false;

    void Start()
    {
        // Reference to the AR camera
        arCamera = Camera.main;
    }

    void Update()
    {
        HandleTouchInput();
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);
        Ray ray = arCamera.ScreenPointToRay(touch.position);

        if (touch.phase == TouchPhase.Began)
        {
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Draggable"))
            {
                isDragging = true;
                offset = hit.transform.position - GetWorldPosition(touch.position);
            }
        }
        else if (touch.phase == TouchPhase.Moved && isDragging)
        {
            // Update object position
            Vector3 newWorldPos = GetWorldPosition(touch.position) + offset;
            transform.position = newWorldPos;
        }
        else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
        {
            isDragging = false;
        }
    }

    private Vector3 GetWorldPosition(Vector2 screenPosition)
    {
        // Convert screen touch position to AR world space
        Plane groundPlane = new Plane(Vector3.up, 0);
        Ray ray = arCamera.ScreenPointToRay(screenPosition);

        if (groundPlane.Raycast(ray, out float enter))
        {
            return ray.GetPoint(enter);
        }

        return Vector3.zero;
    }
}
