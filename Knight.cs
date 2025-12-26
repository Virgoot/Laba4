using System;
/// <summary>
/// Представляет коня в шахматах
/// </summary>
class Knight : Piece
{
    /// <summary>
    /// Инициализирует новый экземпляр коня указанного цвета
    /// </summary>
    /// <param name="color">Цвет коня: "White" или "Black"</param>
    public Knight(string color)
    {
        Color = color;
        Type = Pieces.Knight;
        Symbol = color == "White" ? '♞' : '♘';
    }

    /// <summary>
    /// Проверяет, может ли конь переместиться из начальной позиции в конечную
    /// </summary>
    /// <param name="start">Начальная позиция в шахматной нотации (например "B1")</param>
    /// <param name="end">Конечная позиция в шахматной нотации (например "C3")</param>
    /// <param name="board">Двумерный массив, представляющий шахматную доску</param>
    /// <returns>true если ход допустим для коня, иначе false</returns>
    public override bool CanMove(string start, string end, Piece[,] board)
    {
        int startRow = 8 - int.Parse(start[1].ToString());
        int startCol = start[0] - 'A';
        int endRow = 8 - int.Parse(end[1].ToString());
        int endCol = end[0] - 'A';

        int rowDiff = Math.Abs(endRow - startRow);
        int colDiff = Math.Abs(endCol - startCol);

        
        if ((rowDiff == 2 && colDiff == 1) || (rowDiff == 1 && colDiff == 2))
        {
            Piece target = board[endRow, endCol];
            if (target == null || target.Color != this.Color)
                return true;
        }

        return false;
    }
}
