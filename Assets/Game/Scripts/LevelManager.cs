using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Level _level;
    [SerializeField] private PlayerBehaviour player;
    [SerializeField] private CameraFollow mainCamera;

    private GameObject levelCurrent;
    private int currentPoints;
    private PlayerBehaviour playerBehaviour;

    private void Start()
    { 
        levelCurrent = Instantiate(_level.levelPrefab);
        playerBehaviour = Instantiate(player);
        playerBehaviour.SetData(_level.scoreToChangeStage,_level.maxPoints,_level.startingPoints);
        mainCamera.SetPlayer(player.transform);
        currentPoints = 0;
    }
    public void DestroyLevel()
    {
        Destroy(levelCurrent);
        Destroy(playerBehaviour.gameObject);
    }
    
}
