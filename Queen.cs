class Queen : Piece
{
    public Queen(string color)
    {
        Color = color;
        Type = Pieces.Queen;
        Symbol = color == "White" ? '♛' : '♕';
    }

    public override bool CanMove(string start, string end, Piece[,] board)
    {
        int startRow = 8 - int.Parse(start[1].ToString());
        int startCol = start[0] - 'A';
        int endRow = 8 - int.Parse(end[1].ToString());
        int endCol = end[0] - 'A';

        int rowDiff = endRow - startRow;
        int colDiff = endCol - startCol;

        if (rowDiff != 0 && colDiff != 0 && Math.Abs(rowDiff) != Math.Abs(colDiff))
            return false;

        int rowStep = rowDiff == 0 ? 0 : (rowDiff > 0 ? 1 : -1);
        int colStep = colDiff == 0 ? 0 : (colDiff > 0 ? 1 : -1);

        int currentRow = startRow + rowStep;
        int currentCol = startCol + colStep;

        while (currentRow != endRow || currentCol != endCol)
        {
            if (board[currentRow, currentCol] != null)
            {
                return false;
            }
                 
            currentRow += rowStep;
            currentCol += colStep;
        }

        Piece target = board[endRow, endCol];
        if (target == null || target.Color != this.Color)
        {
            return true;
        }
            

        return false;
    }
}
