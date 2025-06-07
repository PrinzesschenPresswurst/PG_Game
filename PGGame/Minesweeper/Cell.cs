namespace PGGame.Minesweeper;

public class Cell
{
    public bool IsCovered { get; set; }
    public bool IsMine { get; set; }
    public int Row { get; set; }
    public int Column { get; set; }
    public int AdjacentMineCount { get; set; }

    public Cell(int row, int column)
    {
        IsCovered = false;
        Row = row;
        Column = column;
    }

    public void Uncover()
    {
        IsCovered = false;
    }
}