using UnityEngine;

public class Player_ground_state : Player_base_state
{
    protected Vector2 xInput;
    protected bool jumpInput;

    public Player_ground_state(Player player, Player_state_machine pStateMachine, Player_data pData, string animBoolName) : base(player, pStateMachine, pData, animBoolName)
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
        xInput = player.InputHandle.movementInput;
        if (player.InputHandle.Jump)
        {
            player.InputHandle.UsedJumpInput();
            pStateMachine.ChangeState(player.JumpState);
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
