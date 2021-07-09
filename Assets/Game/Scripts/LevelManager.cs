using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy;
using Dreamteck.Splines;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Level _level;
    [SerializeField] private PlayerBehaviour player;
    [SerializeField] private CameraFollow mainCamera;

    private SplineComputer  levelCurrent;
    private int currentPoints;
    private PlayerBehaviour playerBehaviour;
    private Vector3 positionOnFinish;
    private BossBehaviour currentBoss;
    private SplineFollower follower;

    private void Start()
    { 
        
        levelCurrent = Instantiate(_level.currentLevelSpline);
       
        playerBehaviour = Instantiate(player, new Vector3(0,5,0), Quaternion.identity);
        follower = playerBehaviour.SetData(_level.maxStges,_level.startingStage);
        follower.SetNewSpline(levelCurrent);
        mainCamera.SetPlayer(playerBehaviour.transform);
        currentPoints = 0;
        currentBoss = Instantiate(_level.boss, _level.bossSpawnPoint.position, _level.bossSpawnPoint.rotation);
    }
    public void DestroyLevel()
    {
        Destroy(levelCurrent.gameObject);
        Destroy(playerBehaviour.gameObject);
    }

    public void SetFinishData(int finalStage)
    {
        currentBoss.OnPlayerArrived( finalStage >= _level.stageToProgress, playerBehaviour.transform.position);
    }
}
