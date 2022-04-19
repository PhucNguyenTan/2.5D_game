using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Player_state_machine StateMachine{ get; private set; }
    public Animator Anim { get; private set; }

    public Player_idle_state idleState { get; private set; }
    public Player_ground_state groundState { get; private set; }
    public Player_walk_state walkState { get; private set; }

    public InputHandler inputHandler { get; private set; }

    [SerializeField]
    private Player_data data;

    private void Awake()
    {
        StateMachine = new Player_state_machine();

        idleState = new Player_idle_state(this, StateMachine, data, "idle");
        walkState = new Player_walk_state(this, StateMachine, data, "walk");
    }

    private void Start()
    {
        Anim = GetComponentInChildren<Animator>();
        inputHandler = GetComponent<InputHandler>();
        StateMachine.Initialized(idleState);
    }

    private void Update()
    {
        StateMachine.currentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.currentState.PhysicsUpdate();
    }

    /*
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
        Control.Player.Punch.performed += context => Attack();  
    }

    //Quick and dirty
    private void OnEnable()
    {
        Control.Player.Enable();
    }

    private void OnDisable()
    {
        Control.Player.Disable();
    }

    private void Update()
    {
        
        //Control.Player.Movement.performed += context => Movement(context.ReadValue<Vector2>());
        Vector2 _move = Control.Player.Movement.ReadValue<Vector2>();
        Movement(_move);
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
    }*/
}
