namespace PGGame.Minesweeper;

public class MinesweeperGame
{
    public MinesweeperGame()
    {
        Console.Clear();
        Board board = new Board(Board.BoardSize.Small);
        BoardDrawer boardDrawer = new BoardDrawer();
        PlayerInputHandler playerInputHandler = new PlayerInputHandler(board);
        
        boardDrawer.DisplayBoard(board);
        playerInputHandler.GetCellToUncover();
        
        Console.ReadKey();
    }
}