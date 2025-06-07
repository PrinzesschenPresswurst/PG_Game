namespace PGGame.Minesweeper;
using System.Text.RegularExpressions;

public class PlayerInputHandler
{
    private readonly Regex _regex;

    public PlayerInputHandler(Board board)
    {
        int maxNumber = board.GameBoard.GetLength(0)-1;
        char maxLetter = (char)('a' + board.GameBoard.GetLength(1)-1);
        _regex = new Regex ($@"^([a-{maxLetter}]\s*[0-{maxNumber}]|[0-{maxNumber}]\s*[a-{maxLetter}])$", RegexOptions.IgnoreCase);
    }
    public void GetCellToUncover()
    {
        Console.WriteLine("Which cell do you want top uncover?");
        while (true)
        {
            string? input = Console.ReadLine();
            if (input != null && _regex.IsMatch(input))
            {
                Console.WriteLine("Valid input.");
                FilterResult(input);
            }
            else
            {
                Console.WriteLine("Invalid input. Give a number and a letter.");
            }  
        }
    }

    public void FilterResult(string input)
    {
        input = input.ToUpper();
         var matchesLetter = Regex.Matches(input, @"[A-Z]");
        
         foreach (Match match in matchesLetter)
         {
             string letter = match.ToString();
             Console.WriteLine(letter);
         }
        
         var matchesNumber = Regex.Matches(input, @"\d+");
         foreach (Match match in matchesNumber)
         {
             if( Int32.TryParse(match.ToString(), out int result))
             {
                 int number = result;
                 Console.WriteLine(number);
             }
         }
    }
}