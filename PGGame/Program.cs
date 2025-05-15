using PGGame;

Console.Title = "Player's Guide Game";
Console.CursorVisible = false;
Console.OutputEncoding = System.Text.Encoding.UTF8;

GameHandler gameHandler = new GameHandler();

while (true)
{
    gameHandler.GetDirection();
}

Console.ReadKey();