namespace PGGame;

public class GameHandler
{
    private int windowHeight = 25;
    private int windowWidth = 50;
    private Player player = new Player();
    private BaseMap Map { get; set; } 

    public GameHandler()
    {
        Map = new Map01();
        StartGame();
    }
    
    private void StartGame()
    {
        Console.SetWindowSize(windowWidth, windowHeight);
        WriteMap();
        MovePlayer();
    }


    private void SetPlayerPosition()
    {
        player.PlayerPositionX = Map.playerStartX;
        player.PlayerPositionY = Map.playerStartY;
        MovePlayer();
    }
    
    public void GetDirection() 
    {
        ConsoleKeyInfo input = Console.ReadKey();
        
        if (input.Key == ConsoleKey.UpArrow && player.PlayerPositionY > 0)
        {
            HandleInput(Map, y: -1);
        }
        else if (input.Key == ConsoleKey.DownArrow && player.PlayerPositionY + 1 < windowHeight)
        {
            HandleInput(Map, y: +1);
        }
        else if (input.Key == ConsoleKey.RightArrow && player.PlayerPositionX + 1 < windowWidth)
        {
            HandleInput(Map, x: +1);
        }
        else if (input.Key == ConsoleKey.LeftArrow && player.PlayerPositionX > 0)
        {
            HandleInput(Map, x: -1);
        }
    }
    
    private void HandleInput(BaseMap map, int x = 0, int y = 0)
    {
        if (map.MapArray[player.PlayerPositionY + y, player.PlayerPositionX + x] == '1')
        {
            map.Interact();
            return;
        }
        
        if (map.MapArray[player.PlayerPositionY + y, player.PlayerPositionX + x] == 'D')
        {
            Map = map.MapSwitch();
            WriteMap();
            SetPlayerPosition();
            return;
        }
        
        if (map.MapArray[ player.PlayerPositionY + y, player.PlayerPositionX + x] != ' ')
            return;
        
        MovePlayer(x, y);
    }

    private void MovePlayer(int x = 0, int y=0)
    {
        Console.SetCursorPosition(player.PlayerPositionX,player.PlayerPositionY);
        Console.Write(" ");
        
        player.PlayerPositionY += y;
        player.PlayerPositionX += x;
    
        Console.SetCursorPosition(player.PlayerPositionX,player.PlayerPositionY );
        Console.Write(player.PlayerLook); 
    }

    private void WriteMap()
    {
        Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.WriteLine(Map.MapLook);
        Console.WriteLine($"\n{Map.MapText}");
    }
}