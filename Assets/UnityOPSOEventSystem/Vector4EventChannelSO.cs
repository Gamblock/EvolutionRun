using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Vector4 Event Channel")]
public class Vector4EventChannelSO : ScriptableObject
    { 
        public UnityAction<Vector4> OnEventRaised;
        public void RaiseEvent(Vector4 value)
        {
            OnEventRaised.Invoke(value);
        }
    }
