using PGGame;

Console.Title = "Player's Guide Game";

int windowHeight = 25;
int windowWidth = 50;
Console.SetWindowSize(windowWidth, windowHeight);
Console.CursorVisible = false;
Console.OutputEncoding = System.Text.Encoding.UTF8;

Player player = new Player();
BaseMap map = new Map02(); ;


WriteMap();
player.WritePlayer(map);

while (true)
{
    Move();
}

void Move() 
{
    ConsoleKeyInfo input = Console.ReadKey();
    if (input.Key == ConsoleKey.UpArrow && player.PlayerPositionY > 0)
    {
        player.WritePlayer(map, y: -1);
    }
    else if (input.Key == ConsoleKey.DownArrow && player.PlayerPositionY + 1 < windowHeight)
    {
        player.WritePlayer(map, y: +1);
    }
    else if (input.Key == ConsoleKey.RightArrow && player.PlayerPositionX + 1 < windowWidth)
    {
        player.WritePlayer(map, x: +1);
    }
    else if (input.Key == ConsoleKey.LeftArrow && player.PlayerPositionX > 0)
    {
        player.WritePlayer(map, x: -1);
    }
}


void WriteMap()
{
    Console.SetCursorPosition(0,0);
    Console.WriteLine(map.MapLook);
    Console.WriteLine($"\n{map.MapText}");
}

Console.ReadKey();