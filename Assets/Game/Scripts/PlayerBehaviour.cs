using System;
using System.Collections;
using System.Collections.Generic;
using Doozy.Engine.Progress;
using TMPro;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private List<GameObject> playerStages;
    [SerializeField] private VoidEventChannelSO OnLevelFailed;
    [SerializeField] private Progressor levelProgress;
    [SerializeField] private TextMeshProUGUI pointsText;

    private int currentStageNumber;
    private int currentPoints;
    private GameObject currentStageGO;
    private int CurrentStagePoints;
    private int pointsToChangeStage;
    private int pointsMax;

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

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Finish"))
        {
            
        }
    }
    public void SetCurrentPoints(int pointChange)
        {
            if (currentPoints < 0)
            {
                Debug.Log("lost");
                OnLevelFailed.RaiseEvent();
                return;
            }
            currentPoints +=  pointChange;
            pointsText.text = currentPoints.ToString();
            levelProgress.SetValue((float) currentPoints / pointsMax);

            if (currentPoints >= pointsToChangeStage)
            {
                pointsToChangeStage += CurrentStagePoints;
               ChangeStage(currentPoints/CurrentStagePoints);
            }
    
            if (currentPoints < pointsToChangeStage - CurrentStagePoints)
            {
                pointsToChangeStage = pointsToChangeStage - CurrentStagePoints;
               ChangeStage(currentPoints / CurrentStagePoints);
            }
        }

    public void SetData(int scoreToChangeStage, int maxPoints, int startingPoints)
    {
        pointsMax = maxPoints;
        CurrentStagePoints = scoreToChangeStage;
        SetCurrentPoints(startingPoints);
    }
}
