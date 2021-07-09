using System;
using System.Collections;
using System.Collections.Generic;
using Doozy.Engine.Progress;
using TMPro;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using Dreamteck.Splines;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private List<GameObject> playerStages;
    [SerializeField] private VoidEventChannelSO OnLevelFailed;
    [SerializeField] private Progressor levelProgress;
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private IntEventChannelSO onLevelFinished;
    [SerializeField] private Animator animator;
    
    public  SplineFollower follower;
    private int currentStageNumber;
    private int currentPoints;
    private GameObject currentStageGO;
    private int stagesMax;
    private void Awake()
    {
        currentStageGO = playerStages[0];
        currentStageNumber = 0;
        SetCurrentPoints(0);
        
    }
    public async void ChangeStage(int stageChange)
    {
        if (currentStageNumber > stagesMax)
        {
            return;
        }
        if (currentStageNumber + stageChange < 0)
        {
            playerMovement.ToggleInput(false);
            animator.SetBool("Lost", true);
            await Task.Delay(TimeSpan.FromSeconds(2f));
            OnLevelFailed.RaiseEvent();
        }
        else if(currentStageNumber + stageChange >= playerStages.Count - 1 )
        {
            currentStageGO.SetActive(false);
            currentStageNumber += stageChange;
            currentStageGO = playerStages[playerStages.Count -1];
            currentStageGO.SetActive(true);
            levelProgress.SetValue((float) currentStageNumber / stagesMax);
        }
        else
        {
            currentStageGO.SetActive(false);
            currentStageNumber += stageChange;
            currentStageGO = playerStages[currentStageNumber];
            currentStageGO.SetActive(true);
            levelProgress.SetValue((float) currentStageNumber / stagesMax); 
        }

    }
    public void FinishLevel()
    {
        playerMovement.ToggleInput(false);
        follower.followSpeed = 0;
        animator.SetBool("StoppedRunning", true);
    }
    public void SetCurrentPoints(int pointChange)
    {
        currentPoints += pointChange;
        pointsText.text =  " Collected " + currentPoints + "objects";

    }
    
    public SplineFollower SetData( int maxStages, int startingStage)
    {
        stagesMax = maxStages;
        ChangeStage(startingStage);
        return follower;
    }

    public void SendPointsOnFinish()
    {
        onLevelFinished.RaiseEvent(currentPoints);
    }

    public void FightBoss(int hasBossWon)
    {
        
        animator.SetBool("Fighting", true);
        if (hasBossWon == 0)
        {
            animator.SetBool("Lost", true);
            Destroy(gameObject,1.5f);
        }
        else
        {
            // play win animation
        }
        
    }
}
