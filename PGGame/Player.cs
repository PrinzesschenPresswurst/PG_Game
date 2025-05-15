namespace PGGame;

public class Player
{
    public string PlayerLook { get; } = "\u263B";
    public int PlayerPositionX { get; set; } = 5;
    public int PlayerPositionY { get; set; } = 5;
    
    
    public void WritePlayer(Map map, int x = 0, int y = 0)
    {
        
        if (map.MapArray[PlayerPositionY + y, PlayerPositionX + x] == '1')
        {
            map.Interact();
            return;
        }
        
        if (map.MapArray[ PlayerPositionY + y, PlayerPositionX + x] != ' ')
            return;
        
        Console.SetCursorPosition(PlayerPositionX,PlayerPositionY);
        Console.Write(" ");
        
        PlayerPositionY += y;
        PlayerPositionX += x;
    
        Console.SetCursorPosition(PlayerPositionX,PlayerPositionY );
        Console.Write(PlayerLook); 
    }
}