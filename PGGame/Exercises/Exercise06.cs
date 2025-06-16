namespace PGGame;

public class Exercise06
{
    private List<ItemExercise6>? _inventory = new List<ItemExercise6>();
    private bool discountActive = false;

    public Exercise06()
    {
        RunGame();
    }
    private void RunGame()
    {
        Console.Clear();
        CreateAllItems();

        do
        {
            DisplayMenu();
            Console.WriteLine("Which item do you want to see the price of?");
            int desiredItem = GetNumber();
            DisplayPrice(desiredItem);
            
        } while (PlayAgain());
        
        Console.ReadLine();
    }

    private void CreateAllItems()
    {
        ItemExercise6 torch = new ItemExercise6("Torches", 15);
        ItemExercise6 rope = new ItemExercise6("Ropes", 25);
        ItemExercise6 gear = new ItemExercise6("Climbing Gear", 55);
        ItemExercise6 armor = new ItemExercise6("Armor", 500);
        ItemExercise6 potion = new ItemExercise6("Potion", 5);

        _inventory = [torch, rope, gear, armor, potion];
    }
    private void DisplayMenu()
    {
        Console.WriteLine("We have on sale:");
        int i = 1;
        if (_inventory == null)
            return;
        foreach (var item in _inventory)
        {
            Console.WriteLine($"{i} - {item.Name}");
            i++;
        }
    }

    private int GetNumber()
    {
        while (true)
        {
            string? input = Console.ReadLine();
            if (input != null && int.TryParse(input, out int result))
            {
                if (result >=1 && result <=5)
                    return result;  
            }
        }
    }

    private void DisplayPrice(int number)
    {
        if (_inventory == null)
            return;
        ItemExercise6 itemExercise6 = (number) switch
        {
            1 => _inventory[0],
            2 => _inventory[1],
            3 => _inventory[2],
            4 => _inventory[3],
            5 => _inventory[4],
        };
        Console.WriteLine($"{itemExercise6.Name} costs {(discountActive? (itemExercise6.Price/2) : itemExercise6.Price)}.");
    }
    
    private bool PlayAgain()
    {
        Console.WriteLine("Do you want to see another price? [y] yes - [n] no");
        while (true)
        {
            string input = Console.ReadLine();
            if (input != null && input.ToLower() == "y")
            {
                return true;
            }
            if (input != null && input.ToLower() == "n")
            {
                return false;
            }
        }
    }
}


public record struct ItemExercise6
{
    public string Name { get; set; }
    public int Price { get; set; }

    public ItemExercise6(string name, int price)
    {
        Name = name;
        Price = price;
    }
} 
