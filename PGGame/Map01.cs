namespace PGGame;

public class Map01 : BaseMap
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
                                                  #                                                #
                                                  #      ~~~~~~         ~~~~~~         ~~~~~~      #
                                                  # ~~~~~~===== ~~~~~~===== ~~~~~~===== ~~~~~~==== #
                                                  #~~~~~~~=====~~~~~~~=====~~~~~~~=====~~~~~~~====~#
                                                  # ~~~~~~===== ~~~~~~===== ~~~~~~===== ~~~~~~==== #
                                                  # ~~~~~~===== ~~~~~~===== ~~~~~~===== ~~~~~~==== #
                                                  ##################################################
                                                  """;

    public override string MapText { get; set; } = "You wake up on a beach. There is is a person.";
    
    public override void Interact()
    {
        Console.SetCursorPosition(0,MapHeight);
        Console.WriteLine("Hello");
    }
    
    /*
    
    public Map()
    { 
        MapArray = BuildMapArray();
    }
    
    private char[,] BuildMapArray()
    {
        string[] lines = MapLook.Split('\n');
        char[,] mapArray = new char[lines.Length,lines[0].Length];
        mapHeight = lines.Length;
        mapWidth = lines[0].Length;
        
        for (int i = 0; i < lines.Length; i++)
        {
            char[] letters = lines[i].ToCharArray();

            for (int j = 0; j < letters.Length; j++)
            {
                mapArray[i, j] = letters [j];
            }
        }
        return mapArray;
    }
    */
}