using System.Dynamic;

class Piece
{
    public Pieces Type { get; set; }
    public string Color { get; set; }
    public char Symbol { get; set; }


    public virtual bool CanMove(string start, string end, Piece[,] board)
    {
        /* start: "A1" end: A6

            string start = A1
            string end = A6
            8
            7
            6 .
            5 
            4
            3
            2
            1 * 
              A B C D E F G H

            

            A1 = board[7 (row), 0 (column)]


            board[startRow, startColumn]

            


        */

        
        return false;
    }
}