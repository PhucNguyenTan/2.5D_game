using UnityEngine;

public class Player_walk_state : Player_ground_state
{
    public Player_walk_state(Player player, Player_state_machine pStateMachine, Player_data pData, string animBoolName) : base(player, pStateMachine, pData, animBoolName)
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

        Debug.Log("in_walk_logic");
        if (input.x == 0f)
        {
            pStateMachine.ChangeState(player.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
