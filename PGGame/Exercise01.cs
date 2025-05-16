namespace PGGame;

public static class Exercise01
{
    private static bool nameWasSet = false;
    public static void GetPlayerName()
    {
        if (nameWasSet == true)
        {
            DisplaySetName();
            return;
        }
        
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("\u250c( ಠ_ಠ)\u2518");
        Console.WriteLine();
        Console.WriteLine("Hello. What is your name?");
        Console.CursorVisible = true;

        string name;

        while (true)
        {
            name = Console.ReadLine();
            if (name.Length > 0)
                break;
        }
        
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("\u250c( ಠ\u25e1ಠ)\u2518");
        Console.WriteLine();
        Console.WriteLine($"Cool, hello {name}");
        Console.ReadKey();
        Console.CursorVisible = false;

        Player.Instance.PlayerName = name;
        nameWasSet = true;
    }

    private static void DisplaySetName()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("\u250c( ಠ\u25e1ಠ)\u2518");
        Console.WriteLine();
        Console.WriteLine($"You already told me you are {Player.Instance.PlayerName}. \nGonna live with that now.");
        Console.ReadKey();
    }
}