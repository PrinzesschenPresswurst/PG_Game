namespace PGGame;

public class Exercise03
{
    public static int EggsCollected { get; set; } = 0;
    
    public static void TriangleFarmer()
    {
        Console.Clear();
        Console.Title = "Triangle Farmer";
        Console.WriteLine();
        Console.WriteLine("ᶘ ᵒᴥᵒᶅ");
        Console.WriteLine();
        Console.WriteLine("I will calculate your triangle!");
        Console.WriteLine("Give me the base measurement!");
        int width = GetUserInput();
        Console.WriteLine("Give me the height measurement!");
        int height = GetUserInput();
        Console.ForegroundColor = ConsoleColor.Green; 
        Console.WriteLine($"\nYour triangle is size {((float)width * (float)height)/2}");
        Console.ForegroundColor = ConsoleColor.White; 
        Console.ReadKey();
    }

    public static void DuckBear()
    {
        do
        {
            Console.Clear();
            Console.Title = "Four Sisters and the Duckbear";
            Console.WriteLine();
            Console.WriteLine("( \u0361\u00b0\u2765 \u0361\u00b0)( \u0361\u00b0\u2765 \u0361\u00b0)( \u0361\u00b0\u2765 \u0361\u00b0)( \u0361\u00b0\u2765 \u0361\u00b0)");
            Console.WriteLine();
            Console.WriteLine("Help us solve the dispute. How many eggs do we have?");
            Console.WriteLine($"You have collected: {EggsCollected} eggs.");
            int eggAmount = GetUserInput();
            int eggPerSister = eggAmount / 4;
            int eggsForDuckbear = eggAmount % 4;
            Console.WriteLine($"With {eggAmount} eggs - each sister gets {eggPerSister} and the duckbear gets the rest: {eggsForDuckbear}.");
            if (eggsForDuckbear > eggPerSister)
                Console.WriteLine("Lucky Duckbear! ᶘ ᵒᴥᵒᶅ");
            Console.ReadKey();
        } while (PlayAgain() == true );
    }

    private static int GetUserInput()
    {
        while (true)
        {
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                if (result >=0)
                    return result;
            }
            Console.WriteLine($"{input} is not a valid number.");
        }
    }

    private static bool PlayAgain()
    {
        Console.WriteLine("Do again [a] or exit [e]?");
        while (true)
        {
            string userInput = Console.ReadLine();
            if (userInput.ToUpper() == "A")
            {
                return true;
            }
            else if (userInput.ToUpper() == "E")
            {
                return false;
            }
            Console.WriteLine($"{userInput} is not an answer.");
        }
    }
}