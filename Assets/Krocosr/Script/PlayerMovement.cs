
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _moveInput;

    [SerializeField]
    private float _maxSpeed;
    [SerializeField]
    private float _acceleration = 120;
    [SerializeField]
    private float _deceleration = 30;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void GatherInput()
    {
        _moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3.Normalize(_moveInput);
    }

    void Update()
    {
        GatherInput();
    }

    private void FixedUpdate()
    {
        OnMovement();
    }

    void OnMovement()
    {
        var moveDirection = transform.forward * _moveInput.z + transform.right * _moveInput.x;

        if (_moveInput == Vector3.zero)
        {
            _rb.velocity = Vector3.MoveTowards(_rb.velocity, Vector3.zero, _deceleration * Time.fixedDeltaTime);
        }
        else
        {
            _rb.velocity = Vector3.MoveTowards(_rb.velocity, moveDirection * _maxSpeed, _acceleration * Time.fixedDeltaTime);
        }
    } 
}
