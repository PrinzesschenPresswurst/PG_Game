using PGGame.TicTacToe;

namespace PGGame;

public static class GameHandler
{
    private static readonly int WndowHeight = 50;
    private static readonly int WindowWidth = 100;
    
    public static BaseMap Map01 { get; set; } = new Map01();
    public static BaseMap Map02 { get; set; } = new Map02();
    public static BaseMap Map03 { get; set; } = new Map03();
    private static BaseMap Map { get; set; } = Map01;
    
    private static readonly Player Player = Player.Instance;

    
    public static void StartGame()
    {
        Console.SetWindowSize(WindowWidth, WndowHeight);
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
        else if (input.Key == ConsoleKey.DownArrow && Player.PlayerPositionY + 1 < WndowHeight)
        {
            HandleInput( y: +1);
        }
        else if (input.Key == ConsoleKey.RightArrow && Player.PlayerPositionX + 1 < WindowWidth)
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
        int mapOffsetForHud = -1; //TODO fix this - this is nasty
        char targetCharacter = Map.MapArray[Player.PlayerPositionY + y + mapOffsetForHud, Player.PlayerPositionX + x];
        if (targetCharacter is '1' or '2' or '3' or '4')
        {
            Map.Interact(targetCharacter);
            WriteMap();
            return;
        }
        
        if (targetCharacter == 'D' || targetCharacter == 'E')
        {
            Map = Map.MapSwitch(targetCharacter);
            WriteMap();
            return;
        }

        if (targetCharacter == 'T')
        {
            Map.TreasureHunt();
            if (Map.ActiveTreasureHunt._gameWon)
            {
                Map.MapArray[Player.PlayerPositionY + y + mapOffsetForHud, Player.PlayerPositionX + x] = ' ';
            }
            WriteMap();
            return;
        }

        if (targetCharacter == Map.PickupSign)
        {
            Map.MapArray[Player.PlayerPositionY + y + mapOffsetForHud, Player.PlayerPositionX + x] = ' ';
            Map.Pickup();
        }
        
        if (targetCharacter == 'B')
        {
            Map.Interact(targetCharacter);
            if (Map.ActiveBarrier.CurrentEndResult == TicTacToeGame.EndResult.PlayerWon)
                Map.MapArray[Player.PlayerPositionY + y + mapOffsetForHud, Player.PlayerPositionX + x] = ' ';
            WriteMap();
            return;
        }
        
        else if (targetCharacter != ' ')
            return;
        
        MovePlayer(x, y);
    }
    
    
    private static void MovePlayer(int x = 0, int y=0)
    {
        Console.SetCursorPosition(Player.PlayerPositionX,Player.PlayerPositionY);
        Console.Write(" ");
        
        Player.PlayerPositionY += y;
        Player.PlayerPositionX += x;
    
        Console.SetCursorPosition(Player.PlayerPositionX,Player.PlayerPositionY);
        Console.Write(Player.PlayerLook); 
    }

    private static void WriteMap()
    {
        Console.Clear();
        Console.Title = Map.MapTitle;
        Console.SetCursorPosition(0,0);
        WriteHud();
        Console.SetCursorPosition(0,1);
        Map.WriteMap();
        Console.WriteLine($"\n{Map.MapText}");
        SetPlayerPosition();
    }
    private static void WriteHud()
    {
        Console.Write($"Health: {Player.Instance.Health, -10} ");
        Console.Write($"Coins: {Player.Instance.Coins, -10} ");
        //Console.WriteLine();
    }
}