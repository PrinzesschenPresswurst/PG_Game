namespace PGGame;

public class Exercise14
{
    public void RunGame()
    {
        Console.Clear();
        Console.Title = "Arrow Shop";
        do
        {
            DisplayMenu();
            GetOrder();
        } while (HelperFunctions.PlayAgain("Do you want another arrow?"));
        
        Console.ReadKey();
    }

    private void DisplayMenu()
    {
        Console.WriteLine("Here is the menu.");
        Console.WriteLine("1 - Predefined elite arrow");
        Console.WriteLine("2 - Predefined marksman arrow");
        Console.WriteLine("3 - Predefined practice arrow");
        Console.WriteLine("4 - Make your own arrow");
    }

    private void GetOrder()
    {
        int choice = HelperFunctions.GetNumber("What do you want?", 1, 4);
        Arrow orderedArrow = choice switch
        {
            1 => Arrow.CreateEliteArrow(),
            2 => Arrow.CreateMarksmanArrow(),
            3 => Arrow.CreateParcticeArrow(),
            4 => Arrow.MakeOwnArrow()
        };
        Console.WriteLine($"Here is your {orderedArrow.Length} cm {orderedArrow.Name}: {orderedArrow.Head} head, {orderedArrow.Tip} Tip.");
        Console.WriteLine($"That will cost {orderedArrow.GetCost()}.");
    }
    
}
public class Arrow
{
    public ArrowHead Head { get; set; }
    public Tip Tip { get; set; }
    public float Length { get; set; }
    public string Name { get; set; }

    public Arrow(ArrowHead head, Tip tip, int length, string name = "Arrow")
    {
        Head = head;
        Tip = tip;
        Length = length;
        Name = name;
    }

    public float GetCost()
    {
        float cost = 0;
        cost = Head switch
        {
            ArrowHead.Obsidian => cost += 50 ,
            ArrowHead.Steel => cost += 10,
            ArrowHead.Wood => cost += 1
        };
        cost = Tip switch
        {
            Tip.Cotton => cost += 10 ,
            Tip.Feather => cost += 50,
            Tip.Plastic => cost += 1
        };
        cost += Length * 1f;
        return cost;
    }

    public static Arrow CreateEliteArrow()
    {
        return new Arrow(ArrowHead.Obsidian, Tip.Feather, 100, "Elite Arrow");
    }
    
    public static Arrow CreateMarksmanArrow()
    {
        return new Arrow(ArrowHead.Steel, Tip.Plastic, 80, "Marksman Arrow");
    }
    
    public static Arrow CreateParcticeArrow()
    {
        return new Arrow(ArrowHead.Wood, Tip.Cotton, 160, "Practice Arrow");
    }
    
    public static Arrow MakeOwnArrow()
    {
        Console.WriteLine("Make your own arrow.");
        int head = HelperFunctions.GetNumber($"What head do you want? 1 - {ArrowHead.Obsidian.ToString()} 2 - {ArrowHead.Wood} 3 - {ArrowHead.Steel}", 1, 3);
        int tip = HelperFunctions.GetNumber($"What tip do you want? 1 - {Tip.Cotton} 2 - {Tip.Feather} 3 - {Tip.Plastic}", 1, 3);
        int length = HelperFunctions.GetNumber($"What length do you want? We do anything between 60 and 100.", 60,100);

        ArrowHead arrowHead = head switch
        {
            1 => ArrowHead.Obsidian,
            2 => ArrowHead.Wood,
            3 => ArrowHead.Steel
        };
        Tip arrowTip = tip switch
        {
            1 => Tip.Cotton,
            2 => Tip.Feather,
            3 => Tip.Plastic
        };
        
        Arrow customArrow = new Arrow(arrowHead, arrowTip, length, "Custom Arrow");
        return customArrow;
    }
}

public enum ArrowHead
{
    Steel,
    Obsidian,
    Wood
};

public enum Tip
{
    Feather,
    Cotton,
    Plastic
};