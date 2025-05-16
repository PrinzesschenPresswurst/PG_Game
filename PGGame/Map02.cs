namespace PGGame;

public class Map02 : BaseMap
{
    public override char[,] MapArray { get; set; }
    public override int MapWidth { get; set; }
    public override int MapHeight { get; set; }
    public override int playerStartX { get; set; } = 2;
    public override int playerStartY { get; set; } = 5;
    public override string MapLook { get; set; }= """
                                                  ##################################################
                                                  #                                                #
                                                  #                                                #
                                                  #                                                #
                                                  #                                                #
                                                  D                        1                       #
                                                  #                                                #
                                                  #                                                #
                                                  ##################################################
                                                  ##################################################
                                                  ##################################################
                                                  """;

    public override string MapText { get; set; } = "This is a second map for testing.";
    
    public override void Interact()
    {
        Console.SetCursorPosition(0,MapHeight);
        Console.WriteLine("Boo");
    }
    
    public override BaseMap MapSwitch()
    {
        playerStartX = Player.Instance.PlayerPositionX;
        playerStartY = Player.Instance.PlayerPositionY;
        return GameHandler.Map01;
    }
}