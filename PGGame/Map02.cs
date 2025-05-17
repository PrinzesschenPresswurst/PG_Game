namespace PGGame;

public class Map02 : BaseMap
{
    public override char[,] MapArray { get; set; }
    public override int MapWidth { get; set; }
    public override int MapHeight { get; set; }
    public override int playerStartX { get; set; } = 2;
    public override int playerStartY { get; set; } = 7;
    public override string MapLook { get; set; }= """
                                                  ##################################################
                                                  #                                                #
                                                  #           🌳     ______              🌳       #
                                                  #       ___       | ▲▲▲▲ |        ___            #
                                                  #      |   |      | ▲▲▲▲ |       |   |           #
                                                  #      |_1_|          2          |_3_|           #
                                                  #                                                #
                                                  D         ___                     ___            #
                                                  #        | O |                   | O |           #
                                                  #        |___|                   |___|           #
                                                  #                                                #
                                                  #                                                #
                                                  #           🌳                🌳                 #
                                                  #       🌳      🌳                               #
                                                  #         🌳   🌳                      🌳        #
                                                  #                                                #
                                                  ##################################################
                                                  """;

    public override string MapText { get; set; } = "You enter a city. There are lots of shops here.";
    public override string MapTitle { get; set; } = "City of Consolas.";
    
    public override void Interact(char selection = '1')
    {
        if (selection == '1')
        {
            Exercise02.DisplayShop();
            playerStartX = Player.Instance.PlayerPositionX;
            playerStartY = Player.Instance.PlayerPositionY; 
        }
        else if (selection == '2')
        {
            Exercise03.TriangleFarmer();
            playerStartX = Player.Instance.PlayerPositionX;
            playerStartY = Player.Instance.PlayerPositionY;
        }
    }
    
    public override BaseMap MapSwitch()
    {
        playerStartX = Player.Instance.PlayerPositionX;
        playerStartY = Player.Instance.PlayerPositionY;
        return GameHandler.Map01;
    }
}