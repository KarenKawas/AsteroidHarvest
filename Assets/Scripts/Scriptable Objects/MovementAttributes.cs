using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MovementAttributes : ScriptableObject
{
    [Header("Movement")] 
    public float Torque = 1000f;
    public float Tilt = 8f;
    public float Pitch = 8f;
    public float Acceleration = 30f;
    public float TurnSpeed = 30f;

}
