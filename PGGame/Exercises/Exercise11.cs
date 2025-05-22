namespace PGGame;

public class Exercise11
{
    private int _manticoreHealth = 10;
    private int _cityHealth = 15;
    private int _roundNumber = 1;
    private readonly int[,] _grid = new int[20,5];
    private int _manticorePosition = 0;
    private int _currentPlayerGuess;
    
    public void RunGame()
    {
        Console.Clear();
        FillGrid();
        DisplayHud();
        DisplayGrid();
        _manticorePosition = GetManticoreNumber();
        while (!(_manticoreHealth <= 0 || _cityHealth <= 0))
        {
            _currentPlayerGuess = HelperFunctions.GetNumber("Pick a location to shoot at.", 1, 100);
            UpdateGrid(_currentPlayerGuess);
            AdjustHealth(_currentPlayerGuess);
            Console.Clear();
            DisplayHud();
            DisplayGrid();
            GiveHint(_currentPlayerGuess);
        }
        DisplayGameEnd();
        Console.ReadKey();
    }

    private void DisplayGameEnd()
    {
        Console.WriteLine(_manticoreHealth <= 0 ? "You win": "You lose.");
    }

    private void DisplayHud()
    {
        Console.WriteLine($"{"Round:", -15} + {_roundNumber}");
        Console.WriteLine($"{"City:", -15} + {_cityHealth}");
        Console.WriteLine($"{"Manticore:", -15} + {_manticoreHealth}");
        Console.WriteLine("Cannon damage for next shot: "+ CannonDamage());
        if (_cityHealth >10)
            Console.WriteLine($"{"\ud83c\udfe0  \ud83c\udfe0  \ud83c\udfe0", 15}");
        else if (_cityHealth >5)
            Console.WriteLine($"{"\ud83d\udd25  \ud83c\udfe0  \ud83c\udfe0", 15}");
        else if (_cityHealth <=5)
            Console.WriteLine($"{"\ud83d\udd25  \ud83c\udfe0  \ud83d\udd25", 15}");
        else if (_cityHealth <=0)
            Console.WriteLine($"{"\ud83d\udd25  \\ud83d\udd25  \ud83d\udd25", 15}");
            
    }

    private void UpdateGrid(int number)
    {
        for (int i = 0; i < _grid.GetLength(0); i++)
        {
            for (int j = 0; j < _grid.GetLength(1); j++)
            {
                if (_grid[i, j] == number)
                {
                    if (_grid[i, j] == _manticorePosition)
                        _grid[i, j] = 0;
                    else 
                        _grid[i, j] = 999;
                }
            }
        }
        _roundNumber++;
    }

    private int CannonDamage()
    {
        if (_roundNumber % 3 == 0 && _roundNumber % 5 == 0)
        {
            return 10;
        }
        if (_roundNumber % 3 == 0)
        {
            return 5;
        }
        if (_roundNumber % 5 == 0)
        {
            return 3;
        }

        return 1;
    }

    private void AdjustHealth(int number)
    {
        if (number == _manticorePosition)
            _manticoreHealth -= CannonDamage();
        if (_manticoreHealth > 0)
            _cityHealth -= 1;
    }

    private int GetManticoreNumber()
    {
        Random r = new Random();
        return r.Next(1, 101);
    }
    
    void FillGrid()
    {
        int counter = 1;
        for (int i = 0; i < _grid.GetLength(0); i++)
        {
            for (int j = 0; j < _grid.GetLength(1); j++)
            {
                _grid[i, j] = counter;
                counter++;
            }
        }
    }

    void DisplayGrid()
    {
        for (int i = 0; i < _grid.GetLength(0); i++)
        {
            for (int j = 0; j < _grid.GetLength(1); j++)
            {
                if (_grid[i, j] == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{"\ud83d\udc7e",4}");
                    Console.ResetColor();
                }
                else if (_grid[i, j] == 999)
                {
                    Console.Write($"{".",4}");
                }
                else
                    Console.Write($"{_grid[i, j],4}");
            }
            Console.WriteLine();
        }
    }

    private void GiveHint(int number)
    {
        if (number == _manticorePosition)
        {
            Console.WriteLine($"You found the Manticore! Keep shooting at {number}");
            Console.Beep(400, 500);
        }
            
        else if (number < _manticorePosition)
            Console.WriteLine("The manticore is further away.");
        else if (number > _manticorePosition)
            Console.WriteLine("The manticore is closer.");
    }
}