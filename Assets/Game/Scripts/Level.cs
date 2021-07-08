using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Level", menuName = "Game/Level")]
public class Level : ScriptableObject
{
    public int pointsToProgress;
    public int maxPoints;
    public int scoreToChangeStage;
    public int startingPoints;
    public GameObject levelPrefab;
}
