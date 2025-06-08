namespace PGGame.Minesweeper;

public class BoardDrawer
{
    private readonly string _lookCovered = "\u2610 ";
    private readonly string _lookMine = "\ud83d\udca3";

    private void DisplayHud(Board board)
    {
        Console.WriteLine($"Cells to uncover left: {board.TotalTilesToUncover} / {board.Rows*board.Columns - board.MineAmount}");
    }
    public void DisplayBoard(Board board)
    {
        Console.Clear();
        DisplayHud(board);
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
                if (board.GameBoard[i, j].IsCovered == true)
                {
                    Console.Write(_lookCovered);
                }
                else if (board.GameBoard[i, j].IsCovered == false)
                {
                    if (board.GameBoard[i, j].IsMine)
                    {
                        Console.Write(_lookMine);
                    }

                    if (!board.GameBoard[i, j].IsMine)
                    {
                        SwapColor(board.GameBoard[i, j].AdjacentMineCount);
                        Console.Write($"{board.GameBoard[i, j].AdjacentMineCount} ");
                        Console.ResetColor();
                    }
                }
            }
            Console.WriteLine();
        }
    }

    private void SwapColor(int count)
    {
        Console.ForegroundColor = count switch
        {
            0 => ConsoleColor.Black, 
            1 => ConsoleColor.Green,
            2 => ConsoleColor.Green,
            3=> ConsoleColor.Blue,
            4 => ConsoleColor.Blue,
            5 => ConsoleColor.Yellow,
            6 => ConsoleColor.Yellow,
            7 => ConsoleColor.Red,
            9 => ConsoleColor.Red,
        };
    }
}