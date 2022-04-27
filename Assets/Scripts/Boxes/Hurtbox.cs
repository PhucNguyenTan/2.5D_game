using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{

    public Collider collider;
    //private ColliderState _state = ColliderState.Open;

    public bool getHitBy(int damage)
    {
        // Do something with the damage and the state
        return true;
    }

    private void OnDrawGizmos()
    {
        // You can simply reuse the code from the hitbox,
        // but taking the size, rotation and scale from the collider
    }


}
