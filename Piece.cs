using System.Dynamic;

class Piece
{
    public Pieces Type { get; set; }
    public string Color { get; set; }
    public char Symbol { get; set; }


    public virtual bool CanMove(string start, string end, Piece[,] board)
    {
        return false;
    }
}