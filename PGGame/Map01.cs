using PGGame.Minesweeper;
using PGGame.RPS;
using PGGame.TicTacToe;

namespace PGGame;

public class Map01 : BaseMap
{
    public override char[,] MapArray { get; set; }
    public override int MapWidth { get; set; }
    public override int MapHeight { get; set; }
    public override int playerStartX { get; set; } = 25; 
    public override int playerStartY { get; set; } = 8; 
    public override MinesweeperGame ActiveTreasureHunt { get; set; }
    public override TicTacToeGame ActiveBarrier { get; set; }
    
    public override string MapLook { get; set; }= """
                                                  ##################################################
                                                  #                                                #
                                                  #       T                                        #
                                                  #                                                #
                                                  #                                                #
                                                  #                        1        2             BD
                                                  #        S                                       #
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
        SetPlayerStart();
        return GameHandler.Map02;
    }
    
    public override void Interact(char selection = '1')
    {
        if (selection == '1')
        {
            Exercise01.GetPlayerName();
            SetPlayerStart();
        }
        if (selection == '2')
        {
            RpsGame rpsGame = new RpsGame();
            SetPlayerStart();
        }
        if (selection == 'B')
        {
            TicTacToeGame game = new TicTacToeGame();
            ActiveBarrier = game;
            SetPlayerStart();
        }
        if (selection == 'T')
            TreasureHunt(Board.BoardSize.Small, 5);
    }
}