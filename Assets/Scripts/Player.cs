using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody _playerBody;
    [SerializeField]
    float _walkSpeed;

    private Animation_State_Controller _animController;
    private Handle_input _input;

    private float _angleY = 90f;

    private void Awake()
    {
        _playerBody = GetComponent<Rigidbody>();
        _animController = GetComponent<Animation_State_Controller>();
        _input = GetComponent<Handle_input>();
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        Movement();
        Attack();
    }

    private void Movement()
    {
        _animController.Walking(_input._inputDirection);
        if (_input._inputDirection == 0)
        {
            return;
        }
        if (_input._inputDirection < 0)
        {
            _angleY = -90f;
        }
        else if (_input._inputDirection > 0)
        {
            _angleY = 90f;
        }

        transform.rotation = Quaternion.Euler(0, _angleY, 0);
        _playerBody.velocity = new Vector3(_input._inputDirection * _walkSpeed, 0f, 0f);

    }

    private void Attack()
    {
        if (!_input._doingPunch)
        {
            return;
        }

        _animController.Punch();
    }
}
