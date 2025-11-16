using System.Xml;

class Rook : Piece
{
    public Rook(string color)
    {
        Type = Pieces.Rook;
        Color = color;
        Symbol = (Color == "White") ? '♜' : '♖';
    }

    
    public override bool CanMove(string start, string end, Piece[,] board)
    {
        
        int startRow = 8 - int.Parse(start[1].ToString());
        int startColumn = start[0] - 'A';

        int endRow = 8 - int.Parse(end[1].ToString());
        int endColumn = end[0] - 'A';

        int rowDiff = Math.Abs(endRow - startRow);
        int colDiff = Math.Abs(endColumn - startColumn);


        if (startRow != endRow && startColumn != endColumn)
            return false;
        
        int rowStep = (endRow == startRow) ? 0 : (endRow > startRow ? 1 : -1);
        int colStep = (endColumn == startColumn) ? 0 : (endColumn > startColumn ? 1 : -1);


        int currentRow = startRow + rowStep;
        int currentCol = startColumn + colStep;

        while(currentRow != endRow || currentCol != endColumn)
        {
            
            if (board[currentRow, currentCol] != null) {
                return false;
            }
            
            currentRow += rowStep;
            currentCol += colStep;   
        }


        if ((rowDiff > 0 && colDiff == 0) || (colDiff > 0 && rowDiff == 0))
        {
            Piece target = board[endRow, endColumn];
            if (target == null || target.Color != this.Color)
            {
                return true;
            }
        }

        return false;
    }
}
