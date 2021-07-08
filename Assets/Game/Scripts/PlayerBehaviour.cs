using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private List<GameObject> playerStages;

    private int currentStageNumber;
    private GameObject currentStageGO;

    private void Start()
    {
        currentStageGO = playerStages[0];
        currentStageNumber = -1;
    }

    public void ChangeStage(int stageNumber)
    {
        if (currentStageNumber < playerStages.Count)
        {
            currentStageNumber++;
            currentStageGO.SetActive(false);
            currentStageGO = playerStages[stageNumber];
            currentStageGO.SetActive(true);
        }
    }
}
