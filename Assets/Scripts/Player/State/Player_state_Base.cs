public abstract class Player_state_Base
{
    /*Abstract Methods
     * _ Need to be public so inherented Class can use
     */

    bool _isRootState = false;

    //Constructor to give context so that Concrete state can use
    protected Player_state_Manager _curContext;
    protected Player_state_Factory _factory;

    protected Player_state_Base _curSuperState;
    protected Player_state_Base _curSubState;
    public Player_state_Base(Player_state_Manager context, Player_state_Factory factory)
    {
        _curContext = context;
        _factory = factory;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract void CheckSwitchState();
    public abstract void InitializeSubstate();

    /*Locally define functions*/
    public void UpdateStates() {
        UpdateState();
        if(_curSubState != null)
        {
            _curSubState.UpdateStates();
        }
    }
    void SwitchState(Player_state_Base newState)
    {
        ExitState(); //Exit current state
        newState.EnterState();
        //Here, this class need to check context
        if (_isRootState)
        {
            _curContext.CurState = newState;
        }
        else if(_curSuperState != null)
        {
            _curSuperState.SetSuperState(newState);
        }
    }

    //Set for parent to know child, child know parent ==> Need to get this
    void SetSuperState(Player_state_Base newSuperState) {
        _curSuperState = newSuperState;
    }
    void SetSubState(Player_state_Base newSubState) {
        _curSubState = newSubState;
        newSubState.SetSuperState(this);
    }

}
