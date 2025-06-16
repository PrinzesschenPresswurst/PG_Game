using PGGame.Minesweeper;
using PGGame.TicTacToe;

namespace PGGame;

public class BaseMap
{
    public virtual char[,] MapArray { get; set; } = new char[1,1];
    public virtual int MapWidth { get; set; }
    public virtual int MapHeight{ get; set; }
    public virtual string MapLook { get; set; } 
    public virtual int playerStartX { get; set; } = 1;
    public virtual int playerStartY { get; set; } = 1;

    public virtual char PickupSign { get; set; }
    public virtual MinesweeperGame ActiveTreasureHunt { get; set; }
    public virtual TicTacToeGame ActiveBarrier { get; set; }
    
    public virtual string MapText { get; set; } = "Default base map text ";
    public virtual string MapTitle { get; set; } = "Default Title ";
    
    public virtual void Interact(char selection = '1')
    {
        
    } 
    public virtual void Pickup()
    {
        
    }
    
    public void TreasureHunt(Board.BoardSize size, int reward)
    {
        MinesweeperGame game = new MinesweeperGame(size);
        ActiveTreasureHunt = game;
        SetPlayerStart();
        
        if (game._gameLost)
        {
            Player.Instance.Health -= 1;
        }

        else if (game._gameWon)
        {
            Player.Instance.Coins += reward;
            MapArray[Player.Instance.PlayerPositionX, Player.Instance.PlayerPositionY] = ' ';
        }
    }
    
    public virtual BaseMap MapSwitch(char exit)
    {
        return new Map01();
    }

    public void SetPlayerStart()
    {
        playerStartX = Player.Instance.PlayerPositionX;
        playerStartY = Player.Instance.PlayerPositionY;
    }

    protected BaseMap()
    { 
        BuildMapArray();
    }
    
    private void BuildMapArray()
    {
        string[] lines = MapLook.Split('\n');
        MapArray = new char[lines.Length,lines[0].Length];
        MapHeight = lines.Length;
        MapWidth = lines[0].Length;
        
        for (int i = 0; i < lines.Length; i++)
        {
            char[] letters = lines[i].ToCharArray();

            for (int j = 0; j < letters.Length; j++)
            {
                MapArray[i, j] = letters [j];
            }
        }
    }

    public void WriteMap()
    {
        for (int i = 0; i < MapArray.GetLength(0); i++)
        {
            for (int j = 0; j < MapArray.GetLength(1); j++)
            {
                if (MapArray[i, j] == 'D' || MapArray[i, j] == 'E')
                { 
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write('E'); 
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (MapArray[i, j] == 'S')
                { 
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('\u2694'); 
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else Console.Write(MapArray[i,j]);
            }
            Console.WriteLine();
        }
    }
}