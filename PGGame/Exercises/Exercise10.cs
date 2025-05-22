namespace PGGame;

public class Exercise10
{
    public Exercise10()
    {
        
    }

    public void RunProgram()
    {
        Console.Clear();
        Countdown(10);
        Console.WriteLine("Recursive Countdown:");
        RecursiveCountdown(10);
        Console.ReadKey();
    }
    private void Countdown(int numberToCountDown)
    {
        Console.WriteLine("Normal Countdown:");
        for (int i = numberToCountDown; i > 0; i--)
        {
            Console.WriteLine(i);
        }
    }
    
    private void RecursiveCountdown(int numberToCountDown)
    {
        Console.WriteLine(numberToCountDown);
        numberToCountDown--;
        if (numberToCountDown==0)
            return;
        RecursiveCountdown(numberToCountDown);
    }
}