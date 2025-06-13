using PGGame;
using PGGame.Minesweeper;
using PGGame.TicTacToe;

Console.Title = "Player's Guide Game";
Console.CursorVisible = false;
Console.OutputEncoding = System.Text.Encoding.UTF8;


GameHandler.StartGame();
    
while (true)
{
    GameHandler.GetDirection();
}

Console.ReadKey();