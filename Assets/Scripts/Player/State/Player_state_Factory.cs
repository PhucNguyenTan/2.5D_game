public class Player_state_Factory
{
    Player_state_Manager _context;

    //Constructor
    public Player_state_Factory(Player_state_Manager currentContext)
    {
        _context = currentContext;
    }

    public Player_state_Base Walk()
    {
        return new Player_state_Walking(_context, this);
    }

    public Player_state_Base Grounded()
    {
        return new Player_state_Grounded(_context, this);
    }
    public Player_state_Base Airborne()
    {
        return new Player_state_Airborne(_context, this);
    }
    public Player_state_Base Attack()
    {
        return new Player_state_Attacking(_context, this);
    }
}
