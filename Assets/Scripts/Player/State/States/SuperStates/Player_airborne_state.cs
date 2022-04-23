using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_airborne_state : Player_base_state
{
    public Player_airborne_state(Player player, Player_state_machine pStateMachine, Player_data pData, string animBoolName) : base(player, pStateMachine, pData, animBoolName)
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
        player.CheckGround();
        if (player.isGrounded)
        {
            pStateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
