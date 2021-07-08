using System;

using UnityEngine;
using InControl;
/*
public class PlayerLauncher : MonoBehaviour
{

    private float currentDistance;
    private float range;
    private float shootPower;
    private RaycastHit hitInfo;
    private Vector3 currentMousePosition;
    private Vector3 temp;
    private Vector3 dir;
    private bool ateFood;
    private Rigidbody rbPlayer;
    private bool launched;
    

    [Tooltip("The Layer/layers the floors are on")] [SerializeField]
    LayerMask groundLayers;
    
   

    [SerializeField] private GameObject arrowPrefab;

    [SerializeField] private Vector3EventChannelSO launchedEvent;
    
   

    private void Update()
    {
        InControlInput();
    }
    private void InControlInput()
    {
        var inputDevice = InputManager.ActiveDevice;
        if (inputDevice != InputDevice.Null && inputDevice != TouchManager.Device)
        {
            TouchManager.ControlsEnabled = false; 
        }
        if (!launched && TouchManager.TouchCount != 0 )
        {
            dir = Vector3.Normalize(currentMousePosition - _player.transform.position);
            var touch = TouchManager.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                arrowPrefab.SetActive(true);
                arrowPrefab.transform.position = _player.transform.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            { 
                Ray ray = Camera.main.ScreenPointToRay(touch.position); 
                if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, groundLayers))
                {
                    if (arrowPrefab.activeSelf)
                    {
                        arrowPrefab.SetActive(true);
                    }
                    currentMousePosition = new Vector3(hitInfo.point.x, _player.transform.position.y, hitInfo.point.z);
                    arrowPrefab.transform.rotation = Quaternion.LookRotation(dir);
                }
            }

            else  if (touch.phase == TouchPhase.Ended)
            {
                launched = true;
                launchedEvent.RaiseEvent(-dir);
                arrowPrefab.SetActive(false);
            }
        }
    }

    public void InputToggleFalse()
    {
        launched = false;
    }

    public void InputToggleTrue()
    {
        launched = true;
    */