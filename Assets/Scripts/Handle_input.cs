using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle_input : MonoBehaviour
{
    public float _inputDirection = 0f;
    public bool _doingPunch = false;

    // Start is called before the first frame update
    void Awake()
    {
        _inputDirection = Input.GetAxisRaw("Horizontal");
        _doingPunch = Input.GetButton("Fire1");
    }

    // Update is called once per frame
    void Update()
    {
        _inputDirection = Input.GetAxisRaw("Horizontal");
        _doingPunch = Input.GetButton("Fire1");
    }
}
