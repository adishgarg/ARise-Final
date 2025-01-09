using UnityEngine;

public class AlignWithMarker : MonoBehaviour
{
    private Transform markerTransform;

    // Call this method to assign the marker's transform when spawning
    public void Initialize(Transform marker)
    {
        markerTransform = marker;
        AlignWithMarkerTransform();
    }

    private void AlignWithMarkerTransform()
    {
        if (markerTransform != null)
        {
            // Align the object's position and rotation with the marker
            transform.position = markerTransform.position;
            transform.rotation = markerTransform.rotation;

            // Optionally, you can also scale the object to match the marker
            // transform.localScale = markerTransform.localScale;
        }
        else
        {
            Debug.LogError("Marker transform is not assigned.");
        }
    }

    private void Update()
    {
        if (markerTransform != null)
        {
            // Continuously align with the marker in case of movement
            AlignWithMarkerTransform();
        }
    }
}
