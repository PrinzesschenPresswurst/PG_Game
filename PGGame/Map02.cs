namespace PGGame;

public class Map02 : BaseMap
{
    public override char[,] MapArray { get; set; }
    public override int MapWidth { get; set; }
    public override int MapHeight { get; set; }
    public override string MapLook { get; set; }= """
                                                  ##################################################
                                                  #                                                #
                                                  #                                                #
                                                  #                                                #
                                                  #                                                #
                                                  #                        1                       #
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

}