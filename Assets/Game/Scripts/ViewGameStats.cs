using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Doozy.Engine.Progress;
using TMPro;

public class ViewGameStats : MonoBehaviour
{
    [SerializeField] private Progressor levelProgress;
    [SerializeField] private TextMeshProUGUI TextCurrentIQ;
    [SerializeField] private LevelViewModel _model;

    

    private void OnEnable()
    { 
        _model.currentProgress.OnValueChanged += OnEventHpPlayerChanged;
        OnEventHpPlayerChanged(_model.currentProgress.Value, _model.currentProgress.Value);

        _model.currentPoints.OnValueChanged += EventCurrentPointsChange;
        EventCurrentPointsChange(_model.currentPoints.Value, _model.currentPoints.Value);
    }

    private void OnDisable()
    {
        _model.currentProgress.OnValueChanged -= OnEventHpPlayerChanged;
        _model.currentPoints.OnValueChanged -= EventCurrentPointsChange;
    }

    public void OnEventHpPlayerChanged(float previous, float current)
    {
        levelProgress.SetValue(current);
    }

    public  void EventCurrentPointsChange(int previous, int current)
    {
        
        TextCurrentIQ.text = current.ToString();
    }
    
}
