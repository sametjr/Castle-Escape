using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private Transform _cameraTransform;

    void Start()
    {
        // Find the main camera and store its transform
        _cameraTransform = Camera.main.transform;
    }

    void LateUpdate()
    {
        // Rotate the canvas to face the camera
        transform.LookAt(transform.position + _cameraTransform.rotation * Vector3.forward, _cameraTransform.rotation * Vector3.up);
    }
}
