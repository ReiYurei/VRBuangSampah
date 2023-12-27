using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField]
    private float _sensitivity;

    public Transform _orientation;
    private Vector2 _mouseInput;

    private float xRotation, yRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        MouseInput();
        HandleRotation();
    }

    void MouseInput()
    {
        _mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * Time.deltaTime * _sensitivity;
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
