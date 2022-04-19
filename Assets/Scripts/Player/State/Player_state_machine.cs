//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

public class Player_state_machine
{
    public Player_base_state currentState { get; private set; }
    

    
    public void Initialized(Player_base_state startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }

    public void ChangeState(Player_base_state newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
