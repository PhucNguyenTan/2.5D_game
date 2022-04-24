using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_jump_state : Player_airborne_state
{
    public Player_jump_state(Player player, Player_state_machine pStateMachine, Player_data pData, string animBoolName) : base(player, pStateMachine, pData, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        player.AddJumpForce();
        pStateMachine.ChangeState(player.AirState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
