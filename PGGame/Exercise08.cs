namespace PGGame;

public class Exercise08
{
    public Exercise08()
    {
        DisplayShots();
    }
    
    private void DisplayShots()
    {
        Console.Clear();
        for (int i = 1; i < 101; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"{i}: Super");
            }
            else if (i % 3 == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"{i}: Fire");
            }
            else if (i % 5 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{i}: Electric");
            }
            else
            {
                Console.ResetColor();
                Console.WriteLine($"{i}: Normal");
            }
                
        }

        Console.ReadKey();
    }
}