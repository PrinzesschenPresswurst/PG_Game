namespace PGGame;

public  class Player
{
    public string PlayerLook { get; private set; } = "\u263B";
    public int PlayerPositionX { get; set; } = 0;
    public int PlayerPositionY { get; set; } = 0;
    public string PlayerName { get; set; } = "default";
    public int Coins { get; set; } = 0;
    public int Health { get; set; } = 10;
    public Inventory Inventory { get; set; } = new Inventory();

    private static Player _instance = null;
    
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
        
    }
    
}
    