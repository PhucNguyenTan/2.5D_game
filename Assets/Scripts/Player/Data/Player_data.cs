using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//What is this???
[CreateAssetMenu(fileName = "newPlayerData", menuName ="Data/Player Data/Base Data")]
public class Player_data : ScriptableObject
{
    [Header("Movement")]
    public float movementVelocity = 1.0f;
    public float AngleY = 90f;
    public float jumpForce = 10.0f;
}
