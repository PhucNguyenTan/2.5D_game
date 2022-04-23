using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region States Variables
    public Player_state_machine StateMachine { get; private set; }
    public Animator Anim { get; private set; }
    public Player_idle_state IdleState { get; private set; }
    public Player_ground_state GroundState { get; private set; }
    public Player_walk_state WalkState { get; private set; }
    public Player_attack_state AttackState { get; private set; }
    public Player_airborne_state AirState { get; private set; }
    public Player_jump_state JumpState { get; private set; }
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

    #region TestJump
    public bool isGrounded;
    //public Transform groundCheck;
    public LayerMask whatIsGround;
    public float groundRadius;
    private Vector3 hitpoint;
    public float distance =0f;
    #endregion

    #region Unity callback Functions
    private void Awake()
    {
        StateMachine = new Player_state_machine();
        PlayerBody = GetComponent<Rigidbody>();
        IdleState = new Player_idle_state(this, StateMachine, data, "idle");
        WalkState = new Player_walk_state(this, StateMachine, data, "walk");
        AttackState = new Player_attack_state(this, StateMachine, data, "attack");
        AirState = new Player_airborne_state(this, StateMachine, data, "air");
        JumpState = new Player_jump_state(this, StateMachine, data, "jump");

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
        PlayerBody.velocity = new Vector3(xValue * data.movementVelocity, PlayerBody.velocity.y, 0f);

    }

    public void SetVelocityY(float yValue)
    {
        PlayerBody.velocity = new Vector3(PlayerBody.velocity.x, yValue, 0f);
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

    public void CheckGround()
    {
        RaycastHit hit;
        RaycastHit hit2;
        RaycastHit hit3;
        Vector3 _point1 = transform.position + Vector3.left * 0.075f;
        Vector3 _point2 = transform.position + Vector3.right * 0.075f;
        bool test;

        isGrounded = Physics.Raycast(_point1, Vector3.down, out hit, 0.05f, (int)whatIsGround)
                  || Physics.Raycast(_point2, Vector3.down, out hit2, 0.05f, (int)whatIsGround);
        //Debug.DrawRay(transform.position + Vector3.left*0.05f, Vector3.down, Color.red);
        //Debug.DrawRay(transform.position + Vector3.right * 0.05f, Vector3.down, Color.red);
        Debug.DrawLine(_point1, _point1 + Vector3.down * 0.1f, Color.red);
        Debug.DrawLine(_point2, _point2 + Vector3.down * 0.1f, Color.red);
        if (!isGrounded)
        {
            test = Physics.Raycast(_point1, Vector3.down, out hit3, 0.5f, (int)whatIsGround);
            Debug.Log(hit3.distance);
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
