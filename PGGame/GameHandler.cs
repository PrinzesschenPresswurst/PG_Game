namespace PGGame;

public static class GameHandler
{
    private static readonly int _windowHeight = 50;
    private static readonly int _windowWidth = 100;
    
    public static BaseMap Map01 { get; set; } = new Map01();
    public static BaseMap Map02 { get; set; } = new Map02();
    private static BaseMap Map { get; set; } = Map01;
    
    private static Player Player = Player.Instance;

    
    public static void StartGame()
    {
        Console.SetWindowSize(_windowWidth, _windowHeight);
        WriteMap();
        MovePlayer();
    }


    private static void SetPlayerPosition()
    {
        Player.PlayerPositionX = Map.playerStartX;
        Player.PlayerPositionY = Map.playerStartY;
        MovePlayer();
    }
    
    public static void GetDirection() 
    {
        ConsoleKeyInfo input = Console.ReadKey();
        
        if (input.Key == ConsoleKey.UpArrow && Player.PlayerPositionY > 0)
        {
            HandleInput( y: -1);
        }
        else if (input.Key == ConsoleKey.DownArrow && Player.PlayerPositionY + 1 < _windowHeight)
        {
            HandleInput( y: +1);
        }
        else if (input.Key == ConsoleKey.RightArrow && Player.PlayerPositionX + 1 < _windowWidth)
        {
            HandleInput( x: +1);
        }
        else if (input.Key == ConsoleKey.LeftArrow && Player.PlayerPositionX > 0)
        {
            HandleInput( x: -1);
        }
    }
    
    private static void HandleInput(int x = 0, int y = 0)
    {
        char targetCharacter = Map.MapArray[Player.PlayerPositionY + y, Player.PlayerPositionX + x];
        if (targetCharacter is '1' or '2' or '3' or '4')
        {
            Map.Interact(targetCharacter);
            WriteMap();
            return;
        }
        
        if (targetCharacter == 'D')
        {
            SwitchMaps();
            WriteMap();
            return;
        }

        if (targetCharacter == Map.PickupSign)
        {
            Map.MapArray[Player.PlayerPositionY + y, Player.PlayerPositionX + x] = ' ';
            Map.Pickup();
        }
        
        else if (targetCharacter != ' ')
            return;
        
        MovePlayer(x, y);
    }

    private static void SwitchMaps()
    {
        Map = Map.MapSwitch();
    }
    
    private static void MovePlayer(int x = 0, int y=0)
    {
        Console.SetCursorPosition(Player.PlayerPositionX,Player.PlayerPositionY);
        Console.Write(" ");
        
        Player.PlayerPositionY += y;
        Player.PlayerPositionX += x;
    
        Console.SetCursorPosition(Player.PlayerPositionX,Player.PlayerPositionY );
        Console.Write(Player.PlayerLook); 
    }

    private static void WriteMap()
    {
        Console.Clear();
        Console.Title = Map.MapTitle;
        Console.SetCursorPosition(0,0);
        Map.WriteMap();
        Console.WriteLine($"\n{Map.MapText}");
        SetPlayerPosition();
    }
}