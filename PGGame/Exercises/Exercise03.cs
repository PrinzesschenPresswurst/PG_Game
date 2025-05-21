namespace PGGame;

public class Exercise03
{
    public static int EggsCollected { get; set; } = 0;

    public static void DominionOfKings()
    {
        Console.Clear();
        Console.Title = "Dominion of Kings";
        Console.WriteLine();
        Console.WriteLine("( ಠ \u035cʖರ\u0cc3)");
        Console.WriteLine();
        Console.WriteLine("Hi. I will score you on the King's Scale!");
        Console.WriteLine("Give me the amount of provinces you have!");
        int provinces = GetUserInput();
        Console.WriteLine("Give me the amount of duchies you have!");
        int duchies = GetUserInput();
        Console.WriteLine("And now the amount of estates you have!");
        int estates = GetUserInput();
        int sum = (estates * 1) + (duchies * 3) + (provinces * 6);
        Console.ForegroundColor = ConsoleColor.Green; 
        Console.WriteLine($"\nYour score is {sum}");
        Console.ForegroundColor = ConsoleColor.White; 
        Console.ReadKey();
    }
    
    public static void TriangleFarmer()
    {
        Console.Clear();
        Console.Title = "Triangle Farmer";
        Console.WriteLine();
        Console.WriteLine("ᶘ ᵒᴥᵒᶅ");
        Console.WriteLine();
        Console.WriteLine("Hi. I will calculate your triangle!");
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
        Console.Clear();
        Console.Title = "Four Sisters and the Duckbear";
        Console.WriteLine();
        Console.WriteLine("( \u0361\u00b0( \u0361\u00b0 \u035cʖ( \u0361\u00b0 \u035cʖ \u0361\u00b0)ʖ \u0361\u00b0)");
        Console.WriteLine("We are four sisters and want chocolate eggs.");
        Console.WriteLine();

        if (EggsCollected <= 0)
        {
            Console.WriteLine("You have no eggs. Com back when you have some.");
            Console.ReadKey();
            return;
        }
        
        Console.SetCursorPosition(0,5);
        Console.WriteLine($"You have collected: {EggsCollected} eggs. Let's split.");
        Console.ReadKey();
        DisplayDuckbearResult(EggsCollected);
        Console.ReadKey();
        
        while (PlayAgain() == true)
        {
            Console.WriteLine("Then give any number of eggs.");
            int eggAmount = GetUserInput();
            DisplayDuckbearResult(eggAmount);
        }
    }

    private static void DisplayDuckbearResult(int number)
    {
        int eggPerSister = number / 4;
        int eggsForDuckbear = number % 4;
        Console.WriteLine($"With {number} eggs - each sister gets {eggPerSister} and their pet, the duckbear, gets the rest: {eggsForDuckbear}.");
        if (eggsForDuckbear > eggPerSister)
            Console.WriteLine("Lucky Duckbear got most! ʕ·\u0361ᴥ·ʔ");
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
        Console.WriteLine("Do you want to try again with any number?");
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