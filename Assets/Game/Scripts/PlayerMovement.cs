using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
using Touch = InControl.Touch;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float touchSensitivityDamping;
    [SerializeField] private PlayerBehaviour player;
    [SerializeField] private VoidEventChannelSO onFinishReached;

    private Vector2 previousTouchPosition;
    private Vector3 previousPlayerPosition;
    private bool inputEnabled = true;
    private bool grounded;
    private float currentDistance;
    

    // Update is called once per frame
    void Update()
    {
        if (inputEnabled)
        { 
            InControlInput(); 
        }
        else if(speed > 0.1f) 
        { 
            speed =  speed - speed / 50;
            
        }
        
        else 
        { 
            speed = 0; 
            player.SendPointsOnFinish();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            onFinishReached.RaiseEvent();
            player.FinishLevel();
        }
        
    }

    public void ToggleInput(bool isEnabled)
    {
        inputEnabled = isEnabled;
    }

    private void InControlInput()
    {
                
        var inputDevice = InputManager.ActiveDevice; 
        if (inputDevice != InputDevice.Null && inputDevice != TouchManager.Device) 
        { 
            TouchManager.ControlsEnabled = false; 
        }
        if (TouchManager.TouchCount != 0) 
        {
            var touch = TouchManager.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                previousTouchPosition = touch.position;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                float distance = previousTouchPosition.x - touch.position.x ;
                previousTouchPosition = touch.position;
                if (Vector3.Distance(player.transform.position, transform.position) < 2.5f)
                {
                    transform.position = transform.position + transform.TransformDirection(Vector3.left) * (distance / touchSensitivityDamping);
                    currentDistance = distance;
                }
                else if(currentDistance < 0 && distance > 0)
                {
                    transform.position = transform.position + transform.TransformDirection(Vector3.left) * (distance / touchSensitivityDamping);
                }
                else if(currentDistance > 0 && distance < 0)
                {
                    transform.position = transform.position + transform.TransformDirection(Vector3.left) * (distance / touchSensitivityDamping);
                }
            } 
        } 
    }
       
}


