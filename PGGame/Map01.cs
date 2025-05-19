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

    public override string MapText { get; set; } = "You wake up on a beach. There is a person.";
    public override string MapTitle { get; set; } = "Beach.";

    public override BaseMap MapSwitch(char exit)
    {
        playerStartX = Player.Instance.PlayerPositionX;
        playerStartY = Player.Instance.PlayerPositionY;
        return GameHandler.Map02;
    }
    
    public override void Interact(char selection = '1')
    {
        if (selection == '1')
        {
            Exercise01.GetPlayerName();
            playerStartX = Player.Instance.PlayerPositionX;
            playerStartY = Player.Instance.PlayerPositionY;
        }
    }
}