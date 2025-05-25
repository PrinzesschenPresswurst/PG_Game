namespace PGGame;

public class Exercise12
{
    private ChestState _currentState = ChestState.Closed;
    private ChestState _requestedState;
    private bool _playerWantsToExit = false;
    
    public void RunGame()
    {
        Console.Clear();
        while (!_playerWantsToExit)
        {
            DisplayChestState();
            _requestedState = AskForInput();
        }
    }
    private ChestState AskForInput()
    {
        Console.WriteLine("What do you want to do?");
        while (true)
        {
            string? input = Console.ReadLine();
            if (input == null)
            {
                Console.WriteLine("Give valid input");
                continue;
            }
                
            switch (input.ToLower())
            {
                case "open":
                    return ChestState.Open;
                case "close":
                case "unlock":
                    return ChestState.Closed;
                case "lock":
                    return ChestState.Locked;
                case "exit":
                    _playerWantsToExit = true;
                    return ChestState.Closed;
                    break;
                default:
                    Console.WriteLine($"{input} is not a valid input.");
                    break;
            }
        }
    }
    private void DisplayChestState()
    {
        if (_currentState == _requestedState)
            Console.WriteLine($"The chest is already {_currentState}");
        
        else if (_currentState == ChestState.Open && _requestedState == ChestState.Locked)
            Console.WriteLine("cant do that.");
        else if (_currentState == ChestState.Locked && _requestedState == ChestState.Open)
            Console.WriteLine("cant do that.");
        else
        {
            _currentState = _requestedState;
            Console.WriteLine($"The chest is now {_currentState}");
        }
        
    }
    private enum ChestState
    {
        Open,
        Closed,
        Locked
    };
}