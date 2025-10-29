using System.Net;

class Pawn : Piece
{
    public Pawn(string color)
    {
        Type = Pieces.Pawn;
        Color = color;
        Symbol = (Color == "White") ? '♟' : '♙';
    }
    

    public override bool CanMove(string start, string end, Piece[,] board)
    {
        int startRow = 8 - int.Parse(start[1].ToString());
        int startColumn = start[0] - 'A';

        int endRow = 8 - int.Parse(end[1].ToString());
        int endColumn = end[0] - 'A';


        if (startColumn == endColumn)
        {
            int step = (endRow > startRow) ? 1 : -1;
            if (board[startRow + step, startColumn] != null)
            {
                Console.WriteLine("Путь заблокирован");
                return false;
            }
        }
        else
        {
            return false;
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