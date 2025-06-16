using PGGame.Items;


namespace PGGame;

public class Inventory
{
    private List<Item> Content { get; set; } = new List<Item>();
    private int _inventorySlots = 10;
    private int _maxWeight = 50;

    public void AddItem(Item itemToAdd)
    {
        if (Content.Count >= _inventorySlots)
        {
            Console.WriteLine("No free slots.");
            Console.ReadKey();
            return;
        }
        
        if (CalculateWeight() + itemToAdd.Weight >= _maxWeight)
        {
            Console.WriteLine("Cant add this. Inventory too heavy.");
            Console.ReadKey();
            return;
        }
        Content.Add(itemToAdd);
    }

    public void RemoveItem(Item itemToRemove)
    {
        Content.Remove(itemToRemove);
    }
    
    public void DisplayInventory()
    {
        Console.Clear();
        Console.Title = "Inventory";
        Console.WriteLine("Your items are be shown here. Press I to exit.");
        Console.WriteLine($"Current items: {Content.Count} / {_inventorySlots}");
        Console.WriteLine($"Current worth: {CalculateWeight()} / {_maxWeight}");

        List<Type> checkedItems = new List<Type>();
        foreach (var item in Content)
        {
            if (Content.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
                break;
            }
            if (checkedItems.Contains(item.GetType()))
            {
                continue;
            }
            Type t = item.GetType();
            int count = Content.Count(i => i.GetType() == t);
            Console.WriteLine($"{item.Name} x {count}");
            checkedItems.Add(item.GetType());
        }

        while (true)
        {
            ConsoleKeyInfo input = Console.ReadKey(true);

            if (input.Key == ConsoleKey.I)
            {
                break;
            }
            InventoryTest();
            DisplayInventory();
        }
    }

    private int CalculateWeight()
    {
        int totalWight = 0;
        foreach (var item in Content)
        {
            totalWight += item.Weight;
        }

        return totalWight;
    }
    private void InventoryTest()
    {
        string question = """ 
                          What do you want to add?
                          1 - Rope
                          2 - Potion
                          3 - Sword
                          4 - Key
                          """;
        int number = HelperFunctions.GetNumber(question, 1, 4);
        switch (number)
        {
            case 1:
                AddItem(new Rope());
                break;
            case 2:
                AddItem(new Potion());
                break;
            case 3:
                AddItem(new Sword());
                break;
            case 4:
                AddItem(new Key());
                break;
        }
    }
}