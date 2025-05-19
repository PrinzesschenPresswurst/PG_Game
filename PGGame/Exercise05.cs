namespace PGGame;

public class Exercise05
{
    private static bool even = true;

    public static void RingBell()
    {
        if (even)
            Console.Beep(100, 500);
        
        else 
            Console.Beep(600, 500);

        even = !even;
    }
}