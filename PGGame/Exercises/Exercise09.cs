namespace PGGame;

public class Exercise09
{
    private readonly int[] _initialArray = new int[5];
    private readonly int[] _copyArray = new int[5];
    private bool _playAgain = true;
    public Exercise09()
    {
        Console.Clear();
        GetArray();
        do
        {
            Instruction();
        } while (_playAgain);
    }

    private void GetArray()
    {
        Console.WriteLine($"Fill the array with some numbers now.");
        for (int i = 0; i < _initialArray.Length; i++)
        {
            _initialArray[i] = HelperFunctions.GetNumber();
        }
    }

    private void Instruction()
    {
        string instruction = """
                             
                             What do you want to do with your array?
                             1 - Copy into new array
                             2 - See min value
                             3 - See max value 
                             4 - Make new array
                             5 - Leave
                             """;
        Console.WriteLine(instruction);
        int choice = HelperFunctions.GetNumber(Minvalue: 1, maxValue: 5);
        switch (choice)
        {
            case 1: 
                CopyArray();
                Console.ReadKey();
                break;
            case 2:
                DisplayMinimum(_initialArray);
                Console.ReadKey();
                break;
            case 3:
                DisplayAverage(_initialArray);
                Console.ReadKey();
                break;
            case 4: 
                GetArray();
                Console.ReadKey();
                break;
            case 5:
                _playAgain = false;
                break;
        }
    }
    private void CopyArray()
    {
        HelperFunctions.FeedbackTimer();
        Array.Copy(_initialArray, _copyArray, _initialArray.Length);
        PrintArray("Old: ", _initialArray);
        PrintArray("New: ", _copyArray);
    }
    
    private void PrintArray(string printMessage, int[] arrayToPrint)
    {
        Console.Write($"\n{printMessage}");
        foreach (var number in arrayToPrint)
        {
            Console.Write(number + " ");
        }
    }

    private void DisplayMinimum(int[] numbersToCheck)
    {
        HelperFunctions.FeedbackTimer("Calculating ");
        int smallestNumber = Int32.MaxValue;
        foreach (var number in numbersToCheck)
        {
            if (number < smallestNumber)
                smallestNumber = number;
        }
        
        Console.WriteLine($"\nThe smallest number is {smallestNumber}");
    }
    
    private void DisplayAverage(int[] numbersToCheck)
    {
        HelperFunctions.FeedbackTimer("Calculating ");
        int sum = 0;
        foreach (var number in numbersToCheck)
        {
            sum += number;
        }

        int average = sum / numbersToCheck.Length;
        Console.WriteLine($"\nThe average of all numbers is {average}");
    }
}