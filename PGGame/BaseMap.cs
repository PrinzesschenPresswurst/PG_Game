namespace PGGame;

public class BaseMap
{
    public virtual char[,]? MapArray { get; set; }
    public virtual int MapWidth { get; set; }
    public virtual int MapHeight{ get; set; }
    public virtual string MapLook { get; set; } 
    
    public virtual string MapText { get; set; } = "Default base map text ";
    
    public virtual void Interact()
    {
        
    }

    protected BaseMap()
    { 
        BuildMapArray();
    }
    private void BuildMapArray()
    {
        string[] lines = MapLook.Split('\n');
        MapArray = new char[lines.Length,lines[0].Length];
        MapHeight = lines.Length;
        MapWidth = lines[0].Length;
        
        for (int i = 0; i < lines.Length; i++)
        {
            char[] letters = lines[i].ToCharArray();

            for (int j = 0; j < letters.Length; j++)
            {
                MapArray[i, j] = letters [j];
            }
        }
    }
}