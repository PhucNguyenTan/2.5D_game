using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//What is this???
[CreateAssetMenu(fileName = "newPlayerData", menuName ="Data/Player Data/Base Data")]
public class Player_data : ScriptableObject
{
    [Header("Movement")]
    public float movementVelocity = 0.001f;
    public float AngleY = 90f;
}
