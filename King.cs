class King : Piece
{
    public King(string color)
    {
        Color = color;
        Type = Pieces.King;
        Symbol = color == "White" ? '♚' : '♔';
    }

    public override bool CanMove(string start, string end, Piece[,] board)
    {
        int startRow = 8 - int.Parse(start[1].ToString());
        int startCol = start[0] - 'A';
        int endRow = 8 - int.Parse(end[1].ToString());
        int endCol = end[0] - 'A';

        int rowDiff = Math.Abs(endRow - startRow);
        int colDiff = Math.Abs(endCol - startCol);

        if ((rowDiff <= 1) && (colDiff <= 1))
        {
            Piece target = board[endRow, endCol];
            if (target == null || target.Color != this.Color)
            {
                return true;
            }
        
                
        }

        return false;
    }
}
