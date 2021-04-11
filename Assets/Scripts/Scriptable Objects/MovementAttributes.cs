using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MovementAttributes : ScriptableObject
{
    [Header("Movement")]
    public float Speed = 5f;
    public float SprintSpeed = 8f;
    public float Tilt = 8f;
    public float Acceleration = 15f;
    public float TurnSpeed = 30f;
    
    
    [Header("Airborne")] 
    public float Gravity = -20f;
    public float JumpHeight = 2f;
    public float AirControl = 0.1f;
    public bool AirTurning = true;
}
