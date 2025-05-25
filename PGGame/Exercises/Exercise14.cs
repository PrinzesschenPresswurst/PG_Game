namespace PGGame;

public class Exercise14
{
    public void RunGame()
    {
        Console.Clear();
        Console.Title = "Arrow Shop";
        Arrow practiceArrow = new Arrow(ArrowHead.Wood, Tip.Plastic, 5);
        Arrow marksmanArrow = new Arrow(ArrowHead.Steel, Tip.Cotton, 25);
        Arrow deluxeArrow = new Arrow(ArrowHead.Obsidian, Tip.Feather, 50);
        Console.WriteLine($"Practice arrows costs {practiceArrow.Cost}");
        Console.WriteLine($"Marksman arrows costs {marksmanArrow.Cost}");
        Console.WriteLine($"Deluxe arrows costs {deluxeArrow.Cost}");
        Console.ReadKey();
    }
}
public class Arrow
{
    public ArrowHead Head { get; set; }
    public Tip Tip { get; set; }
    public float Length { get; set; }
    public float Cost { get; set; }

    public Arrow(ArrowHead head, Tip tip, int length)
    {
        Head = head;
        Tip = tip;
        Length = length;
        Cost = GetCost();
    }

    private float GetCost()
    {
        Cost = Head switch
        {
            ArrowHead.Obsidian => Cost += 50 ,
            ArrowHead.Steel => Cost += 10,
            ArrowHead.Wood => Cost += 1
        };
        Cost = Tip switch
        {
            Tip.Cotton => Cost += 10 ,
            Tip.Feather => Cost += 50,
            Tip.Plastic => Cost += 1
        };
        Cost += Length * 0.05f;
        return Cost;
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