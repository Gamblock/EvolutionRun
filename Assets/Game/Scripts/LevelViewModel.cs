using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "LevelViewModel", menuName = "Game/LevelViewModel")]
public class LevelViewModel : ScriptableObject
{
    public ObservableVariable<float> currentProgress = new ObservableVariable<float>();
    public ObservableVariable<int> currentPoints = new ObservableVariable<int>();
    public event Action OnPlayLevelButtonPressedEvent = () => {};
    public void OnPlayLevelButtonPressed()
    {
       OnPlayLevelButtonPressedEvent.Invoke(); 
    }
}
