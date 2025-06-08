namespace PGGame.Minesweeper;

public class Cell
{
    public bool IsCovered { get; set; }
    public bool IsMine { get; set; }
    private int Row { get; set; }
    private int Column { get; set; }
    public int AdjacentMineCount { get; set; } 
    
    private readonly int[,] _neighbors = new int[,]
    {
        {+1,0}, {0,+1}, {-1,0}, {0,-1}, 
        {+1,+1}, {-1,-1}, {+1,-1}, {-1,+1}, 
    };

    public Cell(int row, int column)
    {
        IsCovered = true;
        Row = row;
        Column = column;
    }

    public void Uncover(Board board)
    {
        if (!IsCovered)
            return;
        IsCovered = false;
        board.TotalTilesToUncover--;
        if (AdjacentMineCount == 0)
            UncoverNeighbors(board);
    }
    
    public void CountAdjacentMines(Board board)
    {
        int count = 0;
        for (int i = 0; i < _neighbors.GetLength(0); i++)
        {
            int rowToCheck = Row + _neighbors[i, 0];
            int columnToCheck = Column + _neighbors[i, 1];
                
            if (CheckIfNeighborIsOnBoard(rowToCheck, columnToCheck, board) == false)
                continue;
            if (board.GameBoard[rowToCheck, columnToCheck].IsMine)
                count++;
        }
        AdjacentMineCount = count;
    }

    private void UncoverNeighbors(Board board)
    {
        for (int i = 0; i < _neighbors.GetLength(0); i++)
        {
            int rowToCheck = Row + _neighbors[i, 0];
            int columnToCheck = Column + _neighbors[i, 1];
                
            if (CheckIfNeighborIsOnBoard(rowToCheck, columnToCheck, board) == false)
                continue;
            if (board.GameBoard[rowToCheck, columnToCheck].AdjacentMineCount == 0)
                board.GameBoard[rowToCheck, columnToCheck].Uncover(board);
            board.GameBoard[rowToCheck, columnToCheck].Uncover(board);
        }
    }

    private bool CheckIfNeighborIsOnBoard(int rowToCheck, int columnToCheck, Board board)
    {
        if (rowToCheck < 0 || rowToCheck >= board.Rows)
            return false;
        if (columnToCheck < 0 || columnToCheck >= board.Columns )
            return false;;
        
        return true;
    }
}