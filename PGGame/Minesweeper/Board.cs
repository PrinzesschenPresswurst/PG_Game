namespace PGGame.Minesweeper;

public class Board
{
    public Cell[,] GameBoard { get; set; } 
    public int Rows { get; set; }
    public int Columns { get; set; }
    public int MineAmount { get; set; }
    public int TotalTilesToUncover { get; set; }
    
    public Board(int rows, int columns, int mineAmount)
    {
        Rows = rows;
        if (Rows > 99)
            Rows = 99;
        Columns = columns;
        if (Columns > 25)
            Columns = 25;
        MineAmount = mineAmount;
        GameBoard = InitializeBoard();
        PlaceMines();
        CountAdjacentMines();
        TotalTilesToUncover = (rows * columns) - mineAmount;
    }

    public Board (BoardSize size)
    {
        switch (size)
        {
            case BoardSize.Small:
                Rows = 9;
                Columns = 9;
                MineAmount = 1;
                break;
            case BoardSize.Medium:
                Rows = 16;
                Columns = 16;
                MineAmount = 40;
                break;
            case BoardSize.Large:
                Rows = 25;
                Columns = 25;
                MineAmount = 66;
                break;
        } 
        GameBoard = InitializeBoard();
        PlaceMines();
        CountAdjacentMines();
        TotalTilesToUncover = (Rows * Columns) - MineAmount;
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
           cell.CountAdjacentMines(this);
        }
    }
    
    public enum BoardSize
    {
        Small, 
        Medium,
        Large
    };
}