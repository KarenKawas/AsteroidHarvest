using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private MovementAttributes _movementAttributes;
    [SerializeField] private Camera _camera;
    [SerializeField] private Animator _cameraAnimator;
   
    private Vector2 _lookInput;
    private Vector2 _moveInput;
    public Vector3 _forward {get; set;} 
    private Rigidbody _rigidbody;
    private float _thrust;
    private float _turn;

    private void Start()
    {
       _rigidbody = GetComponent<Rigidbody>();
    }

    public void OnLook(InputValue value)
    {
        _lookInput = value.Get<Vector2>();
    }

    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

    private void Update()
    {
        _turn = _moveInput.x; //horizontal
        _thrust = _moveInput.y; //vertical
        
    }

    private void FixedUpdate()
    {
        
        Vector3 movement = new Vector3(_turn, 0.0f, _thrust);
        _rigidbody.AddForce(movement * _movementAttributes.Acceleration, ForceMode.Impulse);

        
        _rigidbody.AddRelativeTorque(Vector3.right * _movementAttributes.Torque * -_thrust);
        _rigidbody.AddRelativeTorque(Vector3.up * _movementAttributes.Torque * _turn);

        _rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, _rigidbody.velocity.x * -_movementAttributes.Tilt);
        
    }

}
