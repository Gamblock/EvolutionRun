using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Sirenix;
using Sirenix.OdinInspector;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.Serialization;

public class CollectableObjects : MonoBehaviour
{
    public bool isArch;
    [HideIf("isArch")] public int pointsChangeValue;
    [HideIf("isArch")] public IntEventChannelSO onObjectCollected;
    [SerializeField] private ParticleSystem collectedParticles;
    [FormerlySerializedAs("VisualGO")] [SerializeField] private GameObject collectableVisualGO;
    [ShowIf("isArch")] public int numberOfStagesToChange;
    [ShowIf("isArch")] public  IntEventChannelSO onArchPassed;
    [ShowIf("isArch")] public TextMeshProUGUI archText;

    private bool justPassedAnArch;
    private void OnTriggerEnter(Collider collider)
    {
        if (!isArch)
        { 
            if (collider.gameObject.CompareTag("Player"))
            {
                onObjectCollected.RaiseEvent(pointsChangeValue);
                collectedParticles.Play();
                Destroy(collectableVisualGO);
                Destroy(gameObject, collectedParticles.main.duration);
            } 
        }
        else if(!justPassedAnArch)
        {
            if (collider.gameObject.CompareTag("Player"))
            { 
                onArchPassed.RaiseEvent(numberOfStagesToChange);
                collectedParticles.Play();
                Destroy(collectableVisualGO);
                ArchCollisiondetectionDelay();
                Destroy(archText);
            } 
        }
    }

    private async void ArchCollisiondetectionDelay()
    {
        justPassedAnArch = true;
        await Task.Delay(TimeSpan.FromSeconds(0.5f));
        justPassedAnArch = false;
    }
}
