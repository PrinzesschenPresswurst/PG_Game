namespace PGGame;

public static class GameHandler
{
    private static readonly int _windowHeight = 25;
    private static readonly int _windowWidth = 50;
    public static Player _player { get; set; }= new Player();
    private static BaseMap Map { get; set; } = new Map01();

    
    public static void StartGame()
    {
        Console.SetWindowSize(_windowWidth, _windowHeight);
        WriteMap();
        MovePlayer();
    }


    private static void SetPlayerPosition()
    {
        _player.PlayerPositionX = Map.playerStartX;
        _player.PlayerPositionY = Map.playerStartY;
        MovePlayer();
    }
    
    public static void GetDirection() 
    {
        ConsoleKeyInfo input = Console.ReadKey();
        
        if (input.Key == ConsoleKey.UpArrow && _player.PlayerPositionY > 0)
        {
            HandleInput( y: -1);
        }
        else if (input.Key == ConsoleKey.DownArrow && _player.PlayerPositionY + 1 < _windowHeight)
        {
            HandleInput( y: +1);
        }
        else if (input.Key == ConsoleKey.RightArrow && _player.PlayerPositionX + 1 < _windowWidth)
        {
            HandleInput( x: +1);
        }
        else if (input.Key == ConsoleKey.LeftArrow && _player.PlayerPositionX > 0)
        {
            HandleInput( x: -1);
        }
    }
    
    private static void HandleInput(int x = 0, int y = 0)
    {
        if (Map.MapArray[_player.PlayerPositionY + y, _player.PlayerPositionX + x] == '1')
        {
            Map.Interact();
            WriteMap();
            return;
        }
        
        if (Map.MapArray[_player.PlayerPositionY + y, _player.PlayerPositionX + x] == 'D')
        {
            SwitchMaps();
            WriteMap();
            return;
        }
        
        if (Map.MapArray[ _player.PlayerPositionY + y, _player.PlayerPositionX + x] != ' ')
            return;
        
        MovePlayer(x, y);
    }

    private static void  SwitchMaps()
    {
        Map = Map.MapSwitch();
    }
    
    private static void MovePlayer(int x = 0, int y=0)
    {
        Console.SetCursorPosition(_player.PlayerPositionX,_player.PlayerPositionY);
        Console.Write(" ");
        
        _player.PlayerPositionY += y;
        _player.PlayerPositionX += x;
    
        Console.SetCursorPosition(_player.PlayerPositionX,_player.PlayerPositionY );
        Console.Write(_player.PlayerLook); 
    }

    private static void WriteMap()
    {
        Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.WriteLine(Map.MapLook);
        Console.WriteLine($"\n{Map.MapText}");
        SetPlayerPosition();
    }
}