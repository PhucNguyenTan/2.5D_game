using UnityEngine;

public class Player_state_Grounded : Player_state_Base
{
    public Player_state_Grounded(Player_state_Manager context, Player_state_Factory factory): base(context, factory)
    {
        InitializeSubstate();
    }

    public override void EnterState() {
        Debug.Log("I'm in Grounded");
    }
    public override void UpdateState()
    {

    }
    public override void ExitState()
    {

    }
    public override void CheckSwitchState()
    {

    }
    public override void InitializeSubstate()
    {

    }
}
