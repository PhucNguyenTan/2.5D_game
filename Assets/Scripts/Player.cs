using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody PlayerBody;
    [SerializeField]
    private float WalkSpeed = 1f;

    public PlayerAction Control;

    private Animation_State_Controller AnimController;

    private float AngleY = 90f;

    private void Awake()
    {
        PlayerBody = GetComponent<Rigidbody>();
        AnimController = GetComponent<Animation_State_Controller>();
        Control = new PlayerAction();
    }

    //Quick and dirty
    private void OnEnable()
    {
        Control.Enable();
    }

    private void OnDisable()
    {
        Control.Disable();
    }

    private void Update()
    {
        Control.Player.Punch.performed += context => Attack();
        Control.Player.Movement.performed += context => Movement(context.ReadValue<Vector2>());
    }

    private void FixedUpdate()
    {

    }

    private void Movement(Vector2 inputDirection)
    {
        AnimController.Walking(inputDirection.x);
        if (inputDirection.x == 0)
        {
            return;
        }
        if (inputDirection.x < 0)
        {
            AngleY = -90f;
        }
        else if (inputDirection.x > 0)
        {
            AngleY = 90f;
        }

        Debug.Log(inputDirection.x);

        transform.rotation = Quaternion.Euler(0, AngleY, 0);
        PlayerBody.velocity = new Vector3(inputDirection.x * WalkSpeed, 0f, 0f);

    }

    private void Attack()
    {
        AnimController.Punch();
    }
}
