namespace PGGame.Minesweeper;

public class BoardDrawer
{
    private readonly string _lookCovered = "\u2610 ";
    private readonly string _lookMine = "\ud83d\udca3";
    
    public void DisplayBoard(Board board)
    {
        Console.Clear();
        char topLetters = 'A';
        Console.Write("  ");
        for (int i = 0; i < board.GameBoard.GetLength(1); i++)
        {
            Console.Write($"{topLetters, 2}");
            topLetters++;
        }
        Console.WriteLine();

        int sideNumbers = 1;
        for (int i = 0; i < board.GameBoard.GetLength(0); i++)
        {
            Console.Write($"{sideNumbers, 2} ");
            sideNumbers++;
            for (int j = 0; j < board.GameBoard.GetLength(1); j++)
            {
                //Console.Write($" {board.GameBoard[i, j].Column}{board.GameBoard[i, j].Row} ");
                if (board.GameBoard[i, j].IsCovered == true)
                {
                    Console.Write(_lookCovered);
                    
                }
                else if (board.GameBoard[i, j].IsCovered == false)
                {
                    Console.Write(board.GameBoard[i, j].IsMine
                        ? _lookMine
                        : $"{board.GameBoard[i, j].AdjacentMineCount} ");
                }
            }
            Console.WriteLine();
        }
    }
}