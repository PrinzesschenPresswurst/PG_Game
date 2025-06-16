namespace PGGame.Items;

public class Item
{
    public string Name { get; set; }
    public int Cost { get; set; }
    public int Weight { get; set; }

    public Item(string name, int cost, int weight)
    {
        Name = name;
        Cost = cost;
        Weight = weight;
    }
    
}

public class Rope : Item
{
    public Rope() : base("Rope", 5, 10) { }
}

public class Potion() : Item("Potion", weight: 5, cost: 15);
public class Sword() : Item("Sword", weight: 25, cost: 50);
public class Key() : Item("Key", weight: 2, cost: 35);