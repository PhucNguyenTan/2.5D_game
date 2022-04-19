using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region States Variables
    public Player_state_machine StateMachine{ get; private set; }
    public Animator Anim { get; private set; }
    public Player_idle_state IdleState { get; private set; }
    public Player_ground_state GroundState { get; private set; }
    public Player_walk_state WalkState { get; private set; }
    #endregion

    #region Components
    public InputHandler InputHandle { get; private set; }
    public Rigidbody PlayerBody { get; private set; }
    #endregion

    #region Other Variables
    [SerializeField]
    private Player_data data;
    public float AngleY = 90f;
    public int isFacingRight { get; private set; }
    #endregion

    #region Unity callback Functions
    private void Awake()
    {
        StateMachine = new Player_state_machine();
        PlayerBody = GetComponent<Rigidbody>();
        IdleState = new Player_idle_state(this, StateMachine, data, "idle");
        WalkState = new Player_walk_state(this, StateMachine, data, "walk");
    }

    private void Start()
    {
        Anim = GetComponentInChildren<Animator>();
        InputHandle = GetComponent<InputHandler>();
        StateMachine.Initialized(IdleState);
        isFacingRight = 1;
    }

    private void Update()
    {
        StateMachine.currentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.currentState.PhysicsUpdate();
    }
    #endregion

    #region Set Functions
    public void SetVelocityX(float xValue)
    {
        PlayerBody.velocity = new Vector3(xValue * data.movementVelocity, 0f, 0f);

    }
    #endregion

    #region Check Functions
    public void CheckToFlipX()
    {
        if(InputHandle.movementInput.x < 0 && isFacingRight > 0)
        {
            FlipX();
        }
        else if(InputHandle.movementInput.x > 0 && isFacingRight < 0)
        {
            FlipX();
        }
    }
    #endregion

    #region Other Functions
    public void FlipX()
    {
        isFacingRight *= -1;
        transform.rotation = Quaternion.Euler(0f, isFacingRight * AngleY, 0f);
    }
    #endregion

    /*
    private Rigidbody PlayerBody;
    [SerializeField]
    private float WalkSpeed = 1f;
    private float AngleY = 90f;

    public PlayerAction Control;

    private Animation_State_Controller AnimController;

    

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
