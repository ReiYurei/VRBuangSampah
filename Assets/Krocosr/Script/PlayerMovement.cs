using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _moveInput;
    private bool _isMoving;

    [SerializeField]
    private float _maxSpeed;
    [SerializeField]
    private float _acceleration = 120;
    [SerializeField]
    private float _deceleration = 30;

    [Header("SFX here!")]
    [SerializeField]
    private AudioClip[] _footsteps;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void GatherInput()
    {
        _moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        //Vector3.Normalize(_moveInput);
    }

    private float period = 0.0f;


    void Update()
    {
        GatherInput();
        PlaySound();
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
            _isMoving = false;
        }
        else
        {
            _rb.velocity = Vector3.MoveTowards(_rb.velocity, moveDirection * _maxSpeed, _acceleration * Time.fixedDeltaTime);
            _isMoving = true;
        }
    }

    void PlaySound()
    {
        if (period > .2f && _isMoving)
        {
            SoundsManager.Instance.AudioClip(_footsteps[Random.Range(0, _footsteps.Length)]);
            period = 0;
        }
        period += Time.deltaTime;

    }

}
