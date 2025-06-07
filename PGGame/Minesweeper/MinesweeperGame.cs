namespace PGGame.Minesweeper;

public class MinesweeperGame
{
    private Board _board;
    private BoardDrawer _boardDrawer;
    private PlayerInputHandler _playerInputHandler;
    public MinesweeperGame()
    {
        Console.Clear();
        _board = new Board(Board.BoardSize.Small);
        _boardDrawer = new BoardDrawer();
        _playerInputHandler = new PlayerInputHandler(_board);
        RunGame();
        Console.ReadKey();
    }

    private void RunGame()
    {
        _boardDrawer.DisplayBoard(_board);
        
        while (true)
        {
            (int row, int column) cellToUncover = _playerInputHandler.GetCellToUncover();
            HandleConsequence(cellToUncover);
        }
    }

    private void HandleConsequence((int row,int column) cell)
    {
        if (!_board.GameBoard[cell.row, cell.column].IsCovered)
        {
            Console.WriteLine("Cell already uncovered. Pick another.");
        }
        else if (_board.GameBoard[cell.row, cell.column].IsCovered)
        {
            _board.GameBoard[cell.row, cell.column].Uncover();
            _boardDrawer.DisplayBoard(_board);
            
            if (_board.GameBoard[cell.row, cell.column].IsMine)
            {
                Console.WriteLine("Oh no, a mine. Game over.");
            }
        }
    }
}