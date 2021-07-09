using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Level", menuName = "Game/Level")]
public class Level : ScriptableObject
{ 
    [FormerlySerializedAs("pointsToProgress")] public int stageToProgress;
    public int maxStges;
    public int startingStage;
    public BossBehaviour boss;
    public Transform bossSpawnPoint;
    public SplineComputer currentLevelSpline; 
    
}
