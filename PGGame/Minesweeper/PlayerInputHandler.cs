namespace PGGame.Minesweeper;
using System.Text.RegularExpressions;

public class PlayerInputHandler
{
    private readonly Regex _regex;

    public PlayerInputHandler(Board board)
    {
        int maxNumber = board.GameBoard.GetLength(0)-1;
        char maxLetter = (char)('a' + board.GameBoard.GetLength(1)-1);
        string letterPattern = $"[a-{maxLetter}]";
        string numberPattern = $@"(0*[1-9]|[1-9][0-9]?)"; // matches 1–99 without leading zeros
        _regex = new Regex($@"^({letterPattern}\s*{numberPattern}|{numberPattern}\s*{letterPattern})$", RegexOptions.IgnoreCase);
    }
    public (int row, int column) GetCellToUncover()
    {
        Console.WriteLine("\nWhich cell do you want to uncover?");
        while (true)
        {
            
            string? input = Console.ReadLine();
            if (input != null && _regex.IsMatch(input))
            {
                int column = GetColumn(input);
                int row = GetRow(input);
                return (row, column);
            }
            Console.WriteLine("Invalid input. Give a number and a letter.");
        }
    }

    private int GetColumn(string input)
    {
        int column = -1;
        input = input.ToUpper();
        var matchesLetter = Regex.Matches(input, @"[A-Z]");
        
        foreach (Match match in matchesLetter)
        {
            char letter = match.ToString()[0];
            int value = letter - 'A' + 1;
            column = value - 1;
        }
        return column;
    }
    private int GetRow(string input)
    {
        int row = -1;
        var matchesNumber = Regex.Matches(input, @"\d+");
        foreach (Match match in matchesNumber)
        {
            if( Int32.TryParse(match.ToString(), out int result))
            {
                row = result - 1;
            }
        }
        return row;
    }
}