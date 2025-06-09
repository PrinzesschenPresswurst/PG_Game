namespace PGGame.Minesweeper;

public class MinesweeperGame
{
    private Board _board;
    private BoardDrawer _boardDrawer;
    private PlayerInputHandler _playerInputHandler;
    public bool _gameLost { get; set; } = false;
    public bool _gameWon { get; set; }= false;
    
    public MinesweeperGame(Board.BoardSize size)
    {
        Console.Clear();
        _board = new Board(size);
        _boardDrawer = new BoardDrawer();
        _playerInputHandler = new PlayerInputHandler(_board);
        RunGame();
        Console.ReadKey();
    }

    private void RunGame()
    {
        _boardDrawer.DisplayBoard(_board);
        
        while (_gameWon == false && _gameLost == false)
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
            _board.GameBoard[cell.row, cell.column].Uncover(_board);
            _boardDrawer.DisplayBoard(_board);
            
            if (CheckIfGameWon() == true)
            {
                Console.WriteLine("OMG You made it. Take a treat.");
                _gameWon = true;
            }
            
            if (_board.GameBoard[cell.row, cell.column].IsMine)
            {
                Console.WriteLine("Oh no, a mine. Game over. You lose a life and no treasure for you.");
                _gameLost = true;
            }
        }
    }

    private bool CheckIfGameWon()
    {
        if (_board.TotalTilesToUncover == 0)
            return true;
        return false;
    }
}