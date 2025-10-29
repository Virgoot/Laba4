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



        if (startRow != endRow && startColumn != endColumn)
        {
            return false;
        }


        /*
            start row | *          ~ | end row
        */

        if (startRow == endRow)
        {
            int step = (endColumn > startColumn) ? 1 : -1;

            for (int n = startColumn + step; n != endColumn; n += step)
            {
                if (board[startRow, n] != null)
                {
                    Console.WriteLine("Путь заблокирован");
                    return false;
                }
            }
        }

        if (startColumn == endColumn)
        {
            int step = (endRow > startRow) ? 1 : -1;

            for (int n = startRow + step; n != endRow; n += step)
            {
                if (board[n, startColumn] != null)
                {

                    Console.WriteLine("Путь заблокирован");
                    return false;
                }
            }
        }

        Piece target = board[endRow, endColumn];

        if (target != null && target.Color == Color)
        {
            Console.WriteLine("Вы не можете съесть свою фигуру");
            return false;
        }

        
        return true;
    }
}
