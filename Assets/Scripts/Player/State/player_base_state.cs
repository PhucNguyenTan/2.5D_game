//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Player_base_state
{
    protected Player_state_machine pStateMachine;
    protected Player player;
    protected Player_data pData;

    protected float startTime; // How long has been in a specific state;

    private string animBoolName;

    public Player_base_state(Player player, Player_state_machine pStateMachine, Player_data pData, string animBoolName)
    {
        this.player = player;
        this.pData = pData;
        this.pStateMachine = pStateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        DoCheck();
        player.Anim.SetBool(animBoolName, true);
        startTime = Time.time;
    }

    public virtual void Exit()
    {
        player.Anim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        DoCheck();
    }

    public virtual void DoCheck() // Example: Look for ground look for wall, etc.
    {

    }
}
