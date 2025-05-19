namespace PGGame;

public class Map02 : BaseMap
{
    public override char[,] MapArray { get; set; }
    public override int MapWidth { get; set; }
    public override int MapHeight { get; set; }
    public override int playerStartX { get; set; } = 2;
    public override int playerStartY { get; set; } = 7;
    public override char PickupSign { get; set; } = 'o';

    public override string MapLook { get; set; }= """
                                                  ##################################################
                                                  #   o                                       o    #
                                                  #           🌳     ______              🌳        #
                                                  #       ___       | ▲▲▲▲ |        ___            #
                                                  #      |   |      | ▲▲▲▲ |       | 🐔|           #
                                                  #      |_1_|          2          |_3_|           #
                                                  #                                                #
                                                  D         ___                     ___            E
                                                  #        |___|                  o|   |           #
                                                  #        |___|o                  |_4_|           #
                                                  #                                                #
                                                  #                                                #
                                                  #           🌳                🌳                 #
                                                  #       🌳   o  🌳             o                 #
                                                  #         🌳   🌳                      🌳o       #
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
            SetPlayerStart();
        }
        else if (selection == '2')
        {
            Exercise03.TriangleFarmer();
            SetPlayerStart();
        }
        else if (selection == '3')
        {
            Exercise03.DuckBear();
            SetPlayerStart();
        }
        else if (selection == '4')
        {
            Exercise03.DominionOfKings();
            SetPlayerStart();
        }
        
    }

    public override void Pickup()
    {
        Exercise03.EggsCollected++;
    }

    public override BaseMap MapSwitch(char exit)
    {
        if (exit == 'D')
        {
            SetPlayerStart();
            return GameHandler.Map01;
        }
        else if (exit == 'E')
        {
            SetPlayerStart();
            return GameHandler.Map03;
        }
        else return GameHandler.Map02;
        
        
    }
}