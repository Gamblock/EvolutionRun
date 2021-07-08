using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float offsetY;
    [SerializeField] private float offsetZ;
    [SerializeField] private float smoothingTime;

    private Transform player;
    private Vector3 velocity = Vector3.zero;
    

    private void Update()
    { 
        if (player != null)
        {
            Vector3 targetPosition = player.TransformPoint(0, offsetY, offsetZ);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothingTime);
        }
    }

    public void SetPlayer(Transform playerTransform)
    {
        player = playerTransform;
    }
}
