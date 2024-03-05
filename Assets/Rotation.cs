using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 70f; // Rotation speed

    // Rotate each frame
    void Update()
    {
        // Do the rotation times the rotation speed times the delta time
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
