namespace PGGame;

public static class HelperFunctions
{
    public static int GetNumber(string question = "Give a number", int minvalue = Int32.MinValue, int maxValue = int.MaxValue)
    {
        Console.WriteLine(question);
        
        while (true)
        {
            string? input = Console.ReadLine();
            if (input != null && int.TryParse(input, out int result))
            {
                if (result >= minvalue && result <= maxValue)
                    return result;
                Console.WriteLine($"{result} is not between {minvalue} and {maxValue}.");
            }
            Console.WriteLine($"{input} is not a valid input.");
        }
    }

    public static bool PlayAgain(string question = "Do you want to do again?", string yes = "y", string no = "n")
    {
        Console.WriteLine($"{question} {yes} / {no} ");
        while (true)
        {
            string? input = Console.ReadLine();
            if (input != null && input.Length >= 1)
            {
                if (input == yes)
                    return true;
                else if (input == no)
                    return false;
            }
            Console.WriteLine($"{input} is not a valid input.");
        }
    }

    public static void FeedbackTimer(string display = "Copying ")
    {
        char[] icons = new[] { '.', '.', '.' };
        Console.WriteLine(display);
        foreach (var icon in icons)
        {
            Thread.Sleep(500);
            Console.Write(icon + " ");
        }
    }
}