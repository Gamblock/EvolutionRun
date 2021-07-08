using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
using Touch = InControl.Touch;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float touchSensitivityDamping;

    private Vector2 previousTouchPosition;
    private Vector3 previousPlayerPosition;
    private bool turningOnXaxis = true;
    

    // Update is called once per frame
    void Update()
    {
       
        transform.position =  Vector3.MoveTowards(transform.position, transform.position + transform.forward, Time.deltaTime * speed);

       InControlInput();
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
                bool grounded = Physics.Raycast(transform.position, Vector3.down, 5f,1);
                float distance = previousTouchPosition.x - touch.position.x ;
                previousTouchPosition = touch.position;
                if (grounded)
                {
                    if (turningOnXaxis)
                    {
                        previousPlayerPosition = transform.position;
                        transform.position = new Vector3(transform.position.x + distance / touchSensitivityDamping, transform.position.y, transform.position.z); 
                    }
                    else
                    {
                        previousPlayerPosition = transform.position;
                        transform.position = new Vector3(transform.position.x , transform.position.y, transform.position.z + distance / touchSensitivityDamping); 
                    }
                    
                }
                else
                {
                    if (turningOnXaxis)
                    {
                        transform.position = new Vector3(previousPlayerPosition.x, previousPlayerPosition.y, transform.position.z); 
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x, previousPlayerPosition.y, previousPlayerPosition.z); 
                    }
                    
                }
                
            }
        }
    }
    
}


