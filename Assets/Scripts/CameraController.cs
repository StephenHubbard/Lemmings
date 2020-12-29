using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform = null;
    [SerializeField] private float speed = 20f;
    [SerializeField] private float screenBorderThickness = 10f;
    [SerializeField] private Vector2 screenXLimits = Vector2.zero;
    [SerializeField] private Vector2 screenZLimits = Vector2.zero;
    //[SerializeField] private Vector2 zoomLimits = Vector2.zero;

    private Vector2 previousInput;
    private Vector2 previousZoomInput;
    private Vector2 previousRotateInput;

    private Controls controls;


    public void Start()
    {
        controls = new Controls();

        controls.Player.MoveCamera.performed += SetPreviousInput;
        controls.Player.MoveCamera.canceled += SetPreviousInput;

        controls.Player.Zoom.performed += SetPreviousZoomInput;
        controls.Player.Zoom.canceled += SetPreviousZoomInput;

        controls.Player.Rotate.performed += SetPreviousRotateInput;
        controls.Player.Rotate.canceled += SetPreviousRotateInput;

        controls.Enable();
    }
    

    private void Update()
    {
        UpdateCameraPosition();

        ZoomInAndOut();

        // Rotates in world space and affects WASD movement. 
        //RotateCamera();
    }

    private void RotateCamera()
    {
        // not working as intended 

        if (previousRotateInput == Vector2.zero) { return; }

        playerCameraTransform.Rotate(0f, -previousRotateInput.y, 0f, Space.World);
    }

    private void ZoomInAndOut()
    {
        if (previousZoomInput == Vector2.zero) { return; }

        Vector3 pos = playerCameraTransform.position;

        pos += new Vector3(0f, -previousZoomInput.y, previousZoomInput.y) * .5f * Time.deltaTime;

        //pos.y = Mathf.Clamp(pos.y, zoomLimits.x, zoomLimits.y);

        playerCameraTransform.position = pos;

    }

    private void UpdateCameraPosition()
    {
        Vector3 pos = playerCameraTransform.position;

        pos += new Vector3(previousInput.x, 0f, previousInput.y) * speed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, screenXLimits.x, screenXLimits.y);
        pos.z = Mathf.Clamp(pos.z, screenZLimits.x, screenZLimits.y);

        playerCameraTransform.position = pos;
    }

    private void SetPreviousInput(InputAction.CallbackContext ctx)
    {
        previousInput = ctx.ReadValue<Vector2>();
    }

    private void SetPreviousZoomInput(InputAction.CallbackContext ctx)
    {
        previousZoomInput = ctx.ReadValue<Vector2>();
    }

    private void SetPreviousRotateInput(InputAction.CallbackContext ctx)
    {
        previousRotateInput = ctx.ReadValue<Vector2>();
    }
}
