using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_state_Manager : MonoBehaviour
{
    public float WalkSpeed = 1f;
    public float AngleY = 90f;

    PlayerAction _control;
    Rigidbody _playerBody;
    Animation_State_Controller _animController;

    [SerializeField] //For testting
    bool _isGrounded = false;

    Player_state_Base _currentState;
    Player_state_Factory _states;

    public Player_state_Base CurState {
        get { return _currentState; }
        set { _currentState = value; } 
    }

    void Awake() 
    {
        //Setup Unity stuffs
        _playerBody = GetComponent<Rigidbody>();
        _animController = GetComponent<Animation_State_Controller>();
        _control = new PlayerAction();
        //_control.Player.Punch.performed += context => Attack();

        //Setup state
        _states = new Player_state_Factory(this);
        _currentState = _states.Grounded();
        _currentState.EnterState();


    }


    void Update()
    {
        
    }

    void Movement()
    {

    }

    //Enable n Disable Control
    private void OnEnable()
    {
        _control.Player.Enable();
    }

    private void OnDisable()
    {
        _control.Player.Disable();
    }
}
