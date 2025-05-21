namespace PGGame;

public class Exercise07
{
    private Random _random = new Random();
    private int _numberToGuess;
    private int _playerNumber;
    private int guesses = 0;
    private static int bestGuess = 0;

    public Exercise07()
    {
        PlayGame();
    }
    private void PlayGame()
    {
        GameStart();
        ShuffleNumberToGuess();
        do
        {
            _playerNumber = AskNumber();
            GiveHint();
            Console.WriteLine();
            
        } while (_playerNumber != _numberToGuess);

        Console.ReadKey();
    }

    private void GameStart()
    {
        Console.Clear();
        Console.Title = "Number Guesser";
        string rules = """
                       Can you guess my number?
                       It is a number between 0 and 100. 
                       Good luck.
                       """;
        Console.WriteLine(rules);
    }

    private void ShuffleNumberToGuess()
    {
        _numberToGuess = _random.Next(0, 101);
    }

    private int AskNumber()
    {
        Console.WriteLine("What is your next guess? ");
        while (true)
        {
            string? input = Console.ReadLine();
            
            if (input != null && int.TryParse(input, out int result))
            {
                if (result >= 0 && result <= 100)
                {
                    guesses++;
                    return result;
                }
                Console.WriteLine($"{result} is not between 0 and 10");
            }
            Console.WriteLine($"{input} is not a valid input");
        } 
    }

    private void GiveHint()
    {
        if (_playerNumber < _numberToGuess)
            Console.WriteLine($"{_playerNumber} is too low");
        else if (_playerNumber > _numberToGuess)
            Console.WriteLine($"{_playerNumber} is too high");
        else if (_playerNumber == _numberToGuess)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Wow, You guessed the number! You needed {guesses} tries.");
            CheckForHighScore();
            Console.ResetColor();
        }
    }

    private void CheckForHighScore()
    {
        if (bestGuess == 0)
        {
            bestGuess = guesses;
            Console.WriteLine("You broke the previous highscore!");
        }
        else if (guesses < bestGuess)
        {
            bestGuess = guesses;
            Console.WriteLine("You broke the previous highscore!");
        }
        else 
            Console.WriteLine($"{guesses} tries is not bad. But last best is {bestGuess}!");
            
           
    }
}