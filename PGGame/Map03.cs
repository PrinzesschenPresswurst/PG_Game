namespace PGGame;

public class Map03 : BaseMap
{
    public override char[,] MapArray { get; set; }
    public override int MapWidth { get; set; }
    public override int MapHeight { get; set; }
    public override int playerStartX { get; set; } = 2; 
    public override int playerStartY { get; set; } = 9; 
    
    public override string MapLook { get; set; }= """
                                                  ##################################################
                                                  #        🌳                    .-. _______|      #
                                                  #                              |=|/     /  \     #
                                                  #                 🌳           | |_____|_""_|    #
                                                  #                              | |__[1]|____|    #
                                                  #         \---/                                  #
                                                  #          |o|                                   #
                                                  #          | |                       🌳          #
                                                  D         ==2==                                  #
                                                  #                                                #
                                                  #                          ._                    #
                                                  #           🌳             |~                    #
                                                  #      🌳      🌳          uuuuu                 #
                                                  #         🌳               |_#-|                 #
                                                  #            🌳            | 3#|          🌳     #
                                                  #                                                #
                                                  ##################################################
                                                  """;
    
    
    public override string MapText { get; set; } = "This is the area to defend consolas.";
    public override string MapTitle { get; set; } = "Military Ground.";

    public override BaseMap MapSwitch(char exit)
    {
        SetPlayerStart();
        return GameHandler.Map02;
    }
    
    public override void Interact(char selection = '1')
    {
        if (selection == '1')
        {
            Exercise04 defenseOfConsolas = new Exercise04();
            SetPlayerStart();
        }
        if (selection == '2')
        {
            Exercise05.RingBell();
            SetPlayerStart();
        }
    }
}

