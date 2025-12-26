/// <summary>
/// Представляет короля в шахматах
/// </summary>
class King : Piece
{
    /// <summary>
    /// Инициализирует новый экземпляр короля указанного цвета
    /// </summary>
    /// <param name="color">Цвет короля: "White" или "Black"</param>
    public King(string color)
    {
        Color = color;
        Type = Pieces.King;
        Symbol = color == "White" ? '♚' : '♔';
    }

    /// <summary>
    /// Проверяет, может ли король переместиться из начальной позиции в конечную
    /// </summary>
    /// <param name="start">Начальная позиция в шахматной нотации (например "E1")</param>
    /// <param name="end">Конечная позиция в шахматной нотации (например "E2")</param>
    /// <param name="board">Двумерный массив, представляющий шахматную доску</param>
    /// <returns>true если ход допустим для короля, иначе false</returns>
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
