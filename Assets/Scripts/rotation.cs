using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // Rotation speed around the X, Y, and Z axes
    public Vector3 rotationSpeed = new Vector3(0, 100, 0); // Example: rotate around the Y-axis

    void Update()
    {
        // Rotate the object over time using the specified rotation speed
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
