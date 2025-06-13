namespace PGGame.RPS;

public class RpsGame
{
    private Choice OpponentChoice { get; set; }
    private int _opponentScore = 0;
    private Choice PlayerChoice { get; set; }
    private int _playerScore = 0;
    public bool PlayerWon { get; set; }

    public RpsGame()
    {
        Console.Clear();
        while (!GameEnd())
        {
            RunGame();
        }
        DisplayEndResult();
        Console.ReadKey();
    }

    private void RunGame()
    {
        Console.Clear();
        DisplayScore();
        PlayerChoice = GetPlayerChoice();
        OpponentChoice = GetOpponentChoice();
        EvaluateWinner();
        Console.ReadKey();
    }
    
    private Choice GetOpponentChoice()
    {
        int number = Random.Shared.Next(1, 4);
        return NumberToChoice(number);
    }

    private Choice GetPlayerChoice()
    {
        int number = HelperFunctions.GetNumber("1 - Rock, 2 - Paper, 3 - Scissor", 1, 3);
        return NumberToChoice(number);
    }

    private void EvaluateWinner()
    {
        Console.WriteLine($"Player: {PlayerChoice.ToString()}");
        Console.WriteLine($"Enemy: {OpponentChoice.ToString()}");
        
        if (PlayerChoice == OpponentChoice)
        {
            Console.WriteLine("It's a draw.");
        }
        else switch (PlayerChoice)
        {
            case Choice.Paper when OpponentChoice == Choice.Rock:
            case Choice.Rock when OpponentChoice == Choice.Scissors:
            case Choice.Scissors when OpponentChoice == Choice.Paper:
                Console.WriteLine("Player wins.");
                _playerScore++;
                break;
            default:
                Console.WriteLine("Enemy wins.");
                _opponentScore++;
                break;
        }
    }

    private void DisplayScore()
    {
        Console.WriteLine($"Player: {_playerScore} - Enemy: {_opponentScore}");
    }

    private Choice NumberToChoice(int number)
    {
        Choice choice = number switch
        {
            1 => Choice.Rock,
            2 => Choice.Paper,
            3 => Choice.Scissors
        };
        return choice;
    }

    private bool GameEnd()
    {
        return _playerScore == 3 || _opponentScore == 3;
    }

    private void DisplayEndResult()
    {
        Console.Clear();
        DisplayScore();
        if (_playerScore == 3)
        {
            PlayerWon = true;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Player won.");
        }
        else if (_opponentScore == 3)
        {
            PlayerWon = false;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Oh no. Enemy won.");
        }
        Console.ResetColor();
    }
    
    private enum Choice
    {
        Rock,
        Paper,
        Scissors
    };
}