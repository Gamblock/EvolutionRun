using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelViewModel _levelView;
    [SerializeField] private Level _level;
    [SerializeField] private PlayerBehaviour player;
    [SerializeField] private Canvas progressionBar;
    
    private GameObject levelCurrent;
    private int currentPoints;
    private int nextStagePoints;
   
    private void Start()
    { 
        Instantiate(_level.levelPrefab);
        nextStagePoints = _level.scoreToChangeStage; 
        player = Instantiate(player);
      progressionBar.transform.parent = player.transform;
      currentPoints = 0;
      SetCurrentPoints(_level.startingPoints);
    }

    public void SetCurrentPoints(int pointChange)
    {
        if (currentPoints >= 0)
        {
            currentPoints +=  pointChange;
            _levelView.currentPoints.Value = currentPoints;
            _levelView.currentProgress.Value =  (float) currentPoints / _level.maxPoints;
        }
        else
        {
            DestroyLevel();
        }
        
        if (currentPoints >= nextStagePoints)
        {
            nextStagePoints += _level.scoreToChangeStage;
            player.ChangeStage(currentPoints/_level.scoreToChangeStage);
        }

        if (currentPoints < nextStagePoints - _level.scoreToChangeStage)
        {
            nextStagePoints = nextStagePoints - _level.scoreToChangeStage;
            player.ChangeStage(currentPoints/_level.scoreToChangeStage);
        }
    }

    private void DestroyLevel()
    {
        Destroy(levelCurrent);
        Destroy(player);
    }
    
}
