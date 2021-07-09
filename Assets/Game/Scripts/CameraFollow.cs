using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float offsetY;
    [SerializeField] private float offsetZ;
    [SerializeField] private float smoothingTime;
    
    
    private Vector3 velocity = Vector3.zero;
    private Transform player;

    private void Update()
    { 
        if (player != null)
        {
            Vector3 targetPosition = player.TransformPoint(0, offsetY, offsetZ);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothingTime);
            Vector3 targetRotation = player.rotation.eulerAngles;
            targetRotation = new Vector3(targetRotation.x + 40, targetRotation.y, targetRotation.z);
            transform.rotation = Quaternion.Euler(targetRotation);
        }
        else
        {
            transform.position = transform.position;
        }
    }

    public void SetPlayer(Transform playerTransform)
    { 
        player = playerTransform; 
    }
}
