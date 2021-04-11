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
    
    [HideInInspector] public CinemachineFreeLook _cinemachineFreeLook;


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
        _thrust = _moveInput.y;
        _turn = _moveInput.x;
    }

    private void FixedUpdate()
    {
        // find thrust force as a Vector3 using the ship's forward
        Vector3 force = _thrust * _movementAttributes.Acceleration * transform.forward;
        // apply thrust
        _rigidbody.AddForce(force);

        // find rotation torque as a Vector3
        Vector3 torque = _turn * _movementAttributes.TurnSpeed * transform.up;
        // this is the same as Vector3 torque = new Vector3(0f, _turn * _turnSpeed, 0f);
        // apply torque
        _rigidbody.AddTorque(torque);
        
        
        
        
    }

}
