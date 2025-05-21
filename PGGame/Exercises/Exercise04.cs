using Microsoft.Win32.SafeHandles;

namespace PGGame;

public class Exercise04
{
    private readonly char[,] _cityGrid = new char[8,8];
    public Exercise04()
    {
        Console.Clear();
        Console.Title = "The Defense of Consolas";
        do
        {
            FillGridInitially();
            DisplayGrid();
            GameTurn();
        } while (PlayAgain() == true);
    }

    private void GameTurn()
    {
        Console.WriteLine("\nGive the column");
        int column = GetUserInput();
        Console.WriteLine("Give the row");
        int row = GetUserInput();
        Console.WriteLine($"Ready to deploy troops at {row}, {column}. Press key.");
        Console.ReadKey();
        
        column -= 1; 
        row = _cityGrid.GetLength(0) -row;
        
        _cityGrid[row, column] = 'X';
        if (row-1 >= 0)
            _cityGrid[row - 1, column] = 'W';
        if (_cityGrid.GetLength(0) > row +1)
            _cityGrid[row + 1, column] = 'W';
        if (column -1 >=0)
            _cityGrid[row , column - 1] = 'W';
        if (_cityGrid.GetLength(0) > column +1)
            _cityGrid[row , column + 1] = 'W';
        
        DisplayGrid();
        Console.Beep(300,1000);
    }

    private int GetUserInput()
    {
        while (true)
        {
            string? input = Console.ReadLine();
            if (input != null && int.TryParse(input, out int result))
            {
                if (result > 0 && result <=8)
                    return result;
            }
            Console.WriteLine($"{input} is not valid. Must be a number on the grid.");
        }
    }

    private bool PlayAgain()
    {
        Console.WriteLine("\nDeploy another position? [y]yes / [n]no");
        while (true)
        {
            string? input = Console.ReadLine();
            if (input != null && input.ToUpper() == "Y")
                return true;
            if (input.ToUpper() == "N")
                return false;
        }
    }
    private void FillGridInitially()
    {
        for (int i = 0; i < _cityGrid.GetLength(0); i++)
        {
            for (int j = 0; j < _cityGrid.GetLength(1); j++)
            {
                _cityGrid[i, j] = '\u2610';
            }
        }
    }
    private void DisplayGrid()
    {
        Console.Clear();
        for (int i = 0; i < _cityGrid.GetLength(0); i++)
        {
            Console.Write($"{_cityGrid.GetLength(0)-i, 2}");
            for (int j = 0; j < _cityGrid.GetLength(1); j++)
            {
                if (_cityGrid[i, j] == 'X')
                    Console.ForegroundColor = ConsoleColor.Red;
                if (_cityGrid[i, j] == 'W')
                    Console.ForegroundColor = ConsoleColor.Cyan;
                
                Console.Write($"{_cityGrid[i,j], 2}");
                Console.ResetColor();
            }
            Console.WriteLine();
        }

        for (int i = 0; i < _cityGrid.GetLength(0)+1; i++)
        {
            Console.Write($"{i,2}");
        }
        Console.WriteLine();
    }
}