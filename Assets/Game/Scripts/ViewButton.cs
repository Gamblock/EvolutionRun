using System;
using UnityEngine;

public class ViewButton : MonoBehaviour
{
    [SerializeField] LevelViewModel model;
    public void OnClick()
    { 
        model.OnPlayLevelButtonPressed();
    }
}