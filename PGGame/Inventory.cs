namespace PGGame;

public class Inventory
{
    public void DisplayInventory()
    {
        Console.Clear();
        Console.Title = "Inventory";
        Console.WriteLine("Your items will be shown here. Press I to exit.");

        while (true)
        {
            ConsoleKeyInfo input = Console.ReadKey(true);

            if (input.Key == ConsoleKey.I)
            {
                break;
            }
        }
    }
}