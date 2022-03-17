using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    private Vector3 worldpos;

    public InputController playerController;
    public bool mouseLook;
    RaycastHit hit;
    private void OnEnable()
    {
        playerController = GetComponent<InputController>();
        playerController.controllerInput.CharacterController.AimMouse.performed += LookAtMouse; 
        playerController.controllerInput.CharacterController.AimMouse.canceled += LookAtMouse;  
    }

   
    public void LookAtMouse(InputAction.CallbackContext context)
    {
        mouseLook = context.ReadValueAsButton();
    }

    void Update()
    {
        if (mouseLook)
        {
            
            Ray ray = Camera.main.ScreenPointToRay (Mouse.current.position.ReadValue());
 
            if(Physics.Raycast(ray,out hit,100))
            {
                transform.LookAt(new Vector3(hit.point.x,transform.position.y,hit.point.z));
            }
        }
       
    }
   

}
