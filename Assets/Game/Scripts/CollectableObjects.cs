using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObjects : MonoBehaviour
{
    [SerializeField] private int pointsChangeValue;
    [SerializeField] private IntEventChannelSO onObjectCollected;
    [SerializeField] private ParticleSystem collectedParticles;
    [SerializeField] private GameObject VisualGO;
    
   
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
           onObjectCollected.RaiseEvent(pointsChangeValue);
           collectedParticles.Play();
           Destroy(VisualGO);
           Destroy(gameObject, collectedParticles.main.duration);
        }
    }
}
