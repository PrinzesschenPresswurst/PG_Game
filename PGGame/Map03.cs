using PGGame.Minesweeper;

namespace PGGame;

public class Map03 : BaseMap
{
    public override char[,] MapArray { get; set; }
    public override int MapWidth { get; set; }
    public override int MapHeight { get; set; }
    public override int playerStartX { get; set; } = 2; 
    public override int playerStartY { get; set; } = 9; 
    public override MinesweeperGame ActiveTreasureHunt { get; set; }
    
    public override string MapLook { get; set; }= """
                                                  ##################################################
                                                  #        🌳                    .-. _______|      #
                                                  #                              |=|/     /  \     #
                                                  #                 🌳           | |_____|_""_|    #
                                                  #                              | |__[1]|____|    #
                                                  #         \---/                                  #
                                                  #          |o|                                   #
                                                  #          | |                       🌳 4        #
                                                  D         ==2==                                  #
                                                  #                                                #
                                                  #                          ._                    #
                                                  #           🌳             |~                    #
                                                  #      🌳   T  🌳          uuuuu                 #
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
        
        else if (selection == '3')
        {
            Exercise06 exercise = new Exercise06();
            SetPlayerStart();
        }
        else if (selection == 'T')
            TreasureHunt(Board.BoardSize.Large, 50);
    }
}

