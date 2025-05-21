namespace PGGame;

public class Exercise06
{
    private List<Item>? _inventory = new List<Item>();
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
        Item torch = new Item("Torches", 15);
        Item rope = new Item("Ropes", 25);
        Item gear = new Item("Climbing Gear", 55);
        Item armor = new Item("Armor", 500);
        Item potion = new Item("Potion", 5);

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
        Item item = (number) switch
        {
            1 => _inventory[1],
            2 => _inventory[2],
            3 => _inventory[3],
            4 => _inventory[4],
            5 => _inventory[5],
        };
        Console.WriteLine($"{item.Name} costs {(discountActive? (item.Price/2) : item.Price)}.");
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

public struct Item
{
    public string Name { get; set; }
    public int Price { get; set; }

    public Item(string name, int price)
    {
        Name = name;
        Price = price;
    }
}