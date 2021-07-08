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
                float distance = previousTouchPosition.x - touch.position.x ;
                previousTouchPosition = touch.position;
                transform.position = new Vector3(Mathf.Clamp(transform.position.x + distance/ touchSensitivityDamping, -3.5f, 3.5f), transform.position.y, transform.position.z);
            }
        }
    }
}
