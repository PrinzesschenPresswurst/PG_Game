namespace PGGame.Minesweeper;

public class Board
{
    public Cell[,] GameBoard { get; set; } 
    private int Rows { get; set; }
    private int Columns { get; set; }
    private int MineAmount { get; set; }
    
    public Board(int rows, int columns, int mineAmount)
    {
        Rows = rows;
        Columns = columns;
        MineAmount = mineAmount;
        GameBoard = InitializeBoard();
        PlaceMines();
    }

    public Board (BoardSize size)
    {
        switch (size)
        {
            case BoardSize.Small:
                Rows = 9;
                Columns = 9;
                MineAmount = 10;
                break;
            case BoardSize.Medium:
                Rows = 16;
                Columns = 16;
                MineAmount = 40;
                break;
            case BoardSize.Large:
                Rows = 60;
                Columns = 30;
                MineAmount = 99;
                break;
        } 
        GameBoard = InitializeBoard();
        PlaceMines();
        CountAdjacentMines();
    }

    private Cell[,] InitializeBoard()
    {
        Cell[,] boardArray = new Cell[Rows,Columns];
        for (int i = 0; i < boardArray.GetLength(0); i++)
        {
            for (int j = 0; j < boardArray.GetLength(1); j++)
            {
                boardArray[i, j] = new Cell(row:i, column:j);
            }
        }
        return boardArray;
    }

    private void PlaceMines()
    {
        int totalCells = Rows * Columns;
        bool[] mines = new bool[totalCells];
        
        for (int i = 0; i < MineAmount; i++)
        {
            mines[i] = true;
        }
        Random.Shared.Shuffle(mines);
        
        for (int i = 0; i < GameBoard.GetLength(0); i++)
        {
            for (int j = 0; j < GameBoard.GetLength(1); j++)
            {
                GameBoard[i, j].IsMine = mines[totalCells-1];
                totalCells--;
            }
        }
    }

    private void CountAdjacentMines()
    {
        foreach (var cell in GameBoard)
        {
            int count = 0;
            
            int[,] neighbors = new int[,]
            {
                {+1,0}, {0,+1}, {-1,0}, {0,-1}, 
                {+1,+1}, {-1,-1}, {+1,-1}, {-1,+1}, 
            };
            
            for (int i = 0; i < neighbors.GetLength(0); i++)
            {
                int neighborRow = neighbors[i, 0];
                int neighborColumn = neighbors[i, 1];
                int rowToCheck = cell.Row + neighborRow;
                int columnToCheck = cell.Column + neighborColumn;
                
                if (rowToCheck < 0 || rowToCheck >= Rows)
                    continue;
                if (columnToCheck < 0 || columnToCheck >= Columns )
                    continue;
               
                if (GameBoard[rowToCheck, columnToCheck].IsMine)
                    count++;
            }
            
            cell.AdjacentMineCount = count;
        }
    }
    
    public enum BoardSize
    {
        Small, 
        Medium,
        Large
    };
}