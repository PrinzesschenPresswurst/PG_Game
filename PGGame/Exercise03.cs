namespace PGGame;

public class Exercise03
{
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

    private static int GetUserInput()
    {
        while (true)
        {
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                return result;
            }
            Console.WriteLine($"{input} is not a valid number.");
        }
    }
}