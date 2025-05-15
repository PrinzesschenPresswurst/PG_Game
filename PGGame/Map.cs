namespace PGGame;

public class Map
{
    public char[,] MapArray { get; set; }
    private int mapWidth = 0;
    private int mapHeight = 0;
    public string MapLook = """
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

    public string mapText { get; set; } = "You wake up on a beach. There is is a person.";

    public Map()
    {
    MapArray = BuildMapArray();
    }

    public void Interact()
    {
        Console.SetCursorPosition(0,mapHeight);
        Console.WriteLine("Hello");
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
}