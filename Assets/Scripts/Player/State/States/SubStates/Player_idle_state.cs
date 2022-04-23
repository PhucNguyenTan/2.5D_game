
using UnityEngine;

public class Player_idle_state : Player_ground_state
{
    public Player_idle_state(Player player, Player_state_machine pStateMachine, Player_data pData, string animBoolName) : base(player, pStateMachine, pData, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityX(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(xInput.x != 0f)
        {
            pStateMachine.ChangeState(player.WalkState);
            
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
