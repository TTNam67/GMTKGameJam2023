using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [SerializeField] float smoothSpeed = 0.18f;

    private void LateUpdate()
    {
        // Calculate the desired position based on the target's position and offset
        Vector3 desiredPosition = target.position + offset;

        // Smoothly move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Set the camera's position only on the x and y axes
        smoothedPosition.z = transform.position.z;
        transform.position = smoothedPosition;
    }
}
