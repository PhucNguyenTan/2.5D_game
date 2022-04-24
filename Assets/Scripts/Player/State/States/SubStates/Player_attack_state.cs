//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Player_attack_state : Player_ground_state
{
    public Player_attack_state(Player player, Player_state_machine pStateMachine, Player_data pData, string animBoolName) : base(player, pStateMachine, pData, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
        player.SetMovementX(0f);
;    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (player.AnimatorIsPlaying())
        {
            player.InputHandle.UsedAttackInput();
            pStateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
