using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransform : MonoBehaviour
{
    [SerializeField]
    private float _sensitivity;

    public Transform _orientation;
    public Transform _cameraHolder;
    private Vector2 _mouseInput;

    private float xRotation, yRotation;

    private bool canMove;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }
     void Start()
    {
        Cursor.visible = true;
        canMove = false;
        Cursor.lockState = CursorLockMode.None;
        Timer.OnTimerEndHandler += DisableMouse;
        GuidePage.OnGuideRead += EnableMouse;
    }
    void Update()
    {
        MouseInput();
        HandleRotation();
        HandlePosition();
    }
    void DisableMouse()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        _mouseInput = Vector2.zero;
        canMove = false;
        Timer.OnTimerEndHandler -= DisableMouse;
    }
    void EnableMouse()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        canMove = true;
        GuidePage.OnGuideRead -= EnableMouse;
    }
    void MouseInput()
    {
        if (canMove == true)
        {
            _mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * Time.deltaTime * _sensitivity;
        }
    }

    private void HandlePosition()
    {
        transform.position = _cameraHolder.position;
    }

    void HandleRotation()
    {
        xRotation -= _mouseInput.y;
        yRotation += _mouseInput.x;

        xRotation = Mathf.Clamp(xRotation, -90f, 90);

        _orientation.Rotate(Vector3.up * _mouseInput.x);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
