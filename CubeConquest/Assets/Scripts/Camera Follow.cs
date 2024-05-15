using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform

    private Vector3 offset; // Offset between camera and player

    private void Start()
    {
        // Calculate the initial offset between the camera and player
        offset = transform.position - player.position;
    }

    private void LateUpdate()
    {
        // Move the camera to follow the player smoothly
        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
    }
}
