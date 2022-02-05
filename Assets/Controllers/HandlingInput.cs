using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlingInput : MonoBehaviour
{

    private float _inputDirection;
    private bool _doingPunch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _inputDirection = Input.GetAxisRaw("Horizontal");
        _doingPunch = Input.GetButton("Fire1");
    }
}
