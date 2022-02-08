using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    
    [SerializeField]
    float _walkSpeed;

    Animation_State_Controller _animController;
    Rigidbody _playerBody;
    PlayerAction _control;

    float _angleY = 90f;
    Vector2 _move;
    private void Awake()
    {
        _playerBody = GetComponent<Rigidbody>();
        _animController = GetComponent<Animation_State_Controller>();
        _control = new PlayerAction();
        _control.Player.Punch.started += ctx => Attack();
    }

    private void Update()
    {
        _move = _control.Player.Movement.ReadValue<Vector2>();
    }

     private void FixedUpdate()
    {
        Movement(_move);
    }

    void Movement(Vector2 move)
    {
        _animController.Walking(move.x);
        if (move.x == 0)
        {
            return;
        }
        if (move.x < 0)
        {
            _angleY = -90f;
        }
        else if (move.x > 0)
        {
            _angleY = 90f;
        }

        transform.rotation = Quaternion.Euler(0, _angleY, 0);
        _playerBody.velocity = new Vector3(move.x * _walkSpeed, 0f, 0f);

    }

    public void Attack()
    {
        _animController.Punch();
    }

    private void OnEnable()
    {
        _control.Player.Enable();
    }

    private void OnDisable()
    {
        _control.Player.Disable();
    }
}
