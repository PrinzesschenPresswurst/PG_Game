namespace PGGame;

public  class Player
{
    public string PlayerLook { get; private set; }
    public int PlayerPositionX { get; set; }
    public int PlayerPositionY { get; set; }
    public string PlayerName { get; set; }
    
    private static Player _instance = new Player();
    
    public static Player Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Player();
            }
            return _instance;
        }
    }
    
    private Player()
    {
        PlayerLook = "\u263B";
        PlayerPositionX = 0;
        PlayerPositionY = 0;
        PlayerName = " ";
    }
    
}
    