namespace PGGame;

public class Map01 : BaseMap
{
    public override char[,] MapArray { get; set; }
    public override int MapWidth { get; set; }
    public override int MapHeight { get; set; }
    public override int playerStartX { get; set; } = 25; 
    public override int playerStartY { get; set; } = 8; 
    
    public override string MapLook { get; set; }= """
                                                  ##################################################
                                                  #                                                #
                                                  #                                                #
                                                  #                                                #
                                                  #                                                #
                                                  #                        1                       D
                                                  #                                                #
                                                  #                                                #
                                                  #                                                #
                                                  #      ~~~~~~         ~~~~~~         ~~~~~~      #
                                                  # ~~~~~~===== ~~~~~~===== ~~~~~~===== ~~~~~~==== #
                                                  #~~~~~~~=====~~~~~~~=====~~~~~~~=====~~~~~~~====~#
                                                  # ~~~~~~===== ~~~~~~===== ~~~~~~===== ~~~~~~==== #
                                                  # ~~~~~~===== ~~~~~~===== ~~~~~~===== ~~~~~~==== #
                                                  ##################################################
                                                  """;

    public override string MapText { get; set; } = "You wake up on a beach. There is is a person.";

    public override BaseMap MapSwitch()
    {
        return new Map02();
    }
    
    public override void Interact()
    {
        Exercise01.GetPlayerName();
    }
}