using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Reference to the ball's transform
    public Vector3 offset;    // Offset from the target (ball)
    public float smoothSpeed = 0.125f;  // Speed of camera follow

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);  // Make the camera look at the ball
    }
}
