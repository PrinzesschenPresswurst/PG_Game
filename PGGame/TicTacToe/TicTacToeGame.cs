namespace PGGame.TicTacToe;

public class TicTacToeGame
{
    private Cell[,] _board = new Cell[3,3];
    public EndResult CurrentEndResult = EndResult.Undefined;
    public TicTacToeGame()
    {
        RunGame();
    }

    private void RunGame()
    {
        Console.Clear();
        InitializeBoard();
        DisplayBoard();
        while (true)
        {
            int playerNumber = HelperFunctions.GetNumber("Which cell do you want?", 1, 9);
            HandlePlayerInput(playerNumber);
            DisplayBoard(); 
            if (CheckIfAllCellsAreTaken())
                break;
            if (CheckIfWin())
            {
                CurrentEndResult = EndResult.PlayerWon;
                break;
            }
            
            HelperFunctions.FeedbackTimer("Enemy picking");
            HandleEnemyTurn();
            DisplayBoard();
            if (CheckIfAllCellsAreTaken())
                break;
            if (CheckIfWin())
            {
                CurrentEndResult = EndResult.PlayerLost;
                break;
            }
        }
        DisplayEnd();
        Console.ReadKey();
    }

    private void InitializeBoard()
    {
        int counter = 1;
        for (int i = 0; i < _board.GetLength(0); i++)
        {
            for (int j = 0; j < _board.GetLength(1); j++)
            {
                _board[i, j] = new Cell();
                _board[i, j].Number = counter;
                counter++;
            }
        }
    }

    private void DisplayBoard()
    {
        Console.Clear();
        for (int i = 0; i < _board.GetLength(0); i++)
        {
            Console.WriteLine(" _  _  _ ");
            for (int j = 0; j < _board.GetLength(1); j++)
            {
                if (_board[i, j].CurrentState == Cell.State.Free)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write($"|{_board[i,j].Number}|"); 
                    Console.ResetColor();
                }
                else if (_board[i, j].CurrentState == Cell.State.X)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"|X|"); 
                    Console.ResetColor();
                }
                else if (_board[i, j].CurrentState == Cell.State.O)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"|O|"); 
                    Console.ResetColor();
                }
            }
            Console.WriteLine("\n \u2594  \u2594  \u2594 ");
        }
    }

    private void HandlePlayerInput(int number)
    {
        for (int i = 0; i < _board.GetLength(0); i++)
        {
            for (int j = 0; j < _board.GetLength(1); j++)
            {
                if (_board[i, j].Number == number)
                {
                    if (_board[i, j].CurrentState == Cell.State.Free)
                    {
                        _board[i, j].CurrentState = Cell.State.X;
                    }
                    else if (_board[i, j].CurrentState != Cell.State.Free)
                    {
                        Console.WriteLine("Cell already taken. Pick another.");
                    }
                    return;
                }
            }
        }
    }

    private void HandleEnemyTurn()
    {
        while (true)
        {
            int enemyNumber = HelperFunctions.GetRandomNumber(1, 10);
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    if (_board[i, j].Number == enemyNumber)
                    {
                        if (_board[i, j].CurrentState == Cell.State.Free)
                        {
                            _board[i, j].CurrentState = Cell.State.O;
                            return;
                        }
                    }
                }
            } 
        }
    }

    private bool CheckIfAllCellsAreTaken()
    {
        for (int i = 0; i < _board.GetLength(0); i++)
        {
            for (int j = 0; j < _board.GetLength(1); j++)
            {
                if (_board[i, j].CurrentState == Cell.State.Free)
                {
                    return false;
                }
            }
        }

        CurrentEndResult = EndResult.Draw;
        return true;
    }
    private bool CheckIfWin()
    {
        // horizontals
        for (int i = 0; i < _board.GetLength(0); i++)
        { 
            if (_board[i, 0].CurrentState == Cell.State.Free)
                continue;
            if (_board[i, 0].CurrentState == _board[i, 1].CurrentState &&
                _board[i, 0].CurrentState == _board[i, 2].CurrentState)
                return true;
        }
        // verticals
        for (int i = 0; i < 3; i++)
        { 
            if (_board[0, i].CurrentState == Cell.State.Free)
                continue;
            if (_board[0, i].CurrentState == _board[1, i].CurrentState &&
                _board[0, i].CurrentState == _board[2, i].CurrentState)
                return true;
        }
        // diagonals 
        if (_board[1,1].CurrentState == Cell.State.Free)
            return false;
        else if (_board[0,0].CurrentState == _board[1,1].CurrentState &&  (_board[2,2].CurrentState == _board[1,1].CurrentState))
            return true;
        else if (_board[0,2].CurrentState == _board[1,1].CurrentState &&  (_board[2,0].CurrentState == _board[1,1].CurrentState))
            return true;
        
        return false;
    }

    private void DisplayEnd()
    {
        ConsoleColor color = ConsoleColor.White;
        string message = "default";
        switch (CurrentEndResult)
        {
            case EndResult.Draw:
                color = ConsoleColor.Yellow;
                message = "A draw. Boring.";
                break;
            case EndResult.PlayerLost:
                color = ConsoleColor.Red;
                message = "Shoot you lost.";
                break;
            case EndResult.PlayerWon:
                color = ConsoleColor.Green;
                message = "Well done. The door opens.";
                break;
        }

        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    public enum EndResult
    {
        PlayerWon, PlayerLost, Draw, Undefined
    }
}

public class Cell
{
    public int Number { get; set; }
    public State CurrentState { get; set; }

    public Cell()
    {
        CurrentState = State.Free;
        Number = 0;
    }
    public enum State
    {
        Free, X, O
    }
}