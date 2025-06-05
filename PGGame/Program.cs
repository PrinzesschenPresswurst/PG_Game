using PGGame;
using PGGame.Minesweeper;

Console.Title = "Player's Guide Game";
Console.CursorVisible = false;
Console.OutputEncoding = System.Text.Encoding.UTF8;

MinesweeperGame game = new MinesweeperGame(); // deleteme
GameHandler.StartGame();
    
while (true)
{
    GameHandler.GetDirection();
}

Console.ReadKey();