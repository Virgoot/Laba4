using System;
/// <summary>
/// Представляет ферзя (королеву) в шахматах
/// </summary>
class Queen : Piece
{
    /// <summary>
    /// Инициализирует новый экземпляр ферзя указанного цвета
    /// </summary>
    /// <param name="color">Цвет ферзя: "White" или "Black"</param>
    public Queen(string color)
    {
        Color = color;
        Type = Pieces.Queen;
        Symbol = color == "White" ? '♛' : '♕';
    }

    /// <summary>
    /// Проверяет, может ли ферзь переместиться из начальной позиции в конечную
    /// </summary>
    /// <param name="start">Начальная позиция в шахматной нотации (например "D1")</param>
    /// <param name="end">Конечная позиция в шахматной нотации (например "D5")</param>
    /// <param name="board">Двумерный массив, представляющий шахматную доску</param>
    /// <returns>true если ход допустим для ферзя, иначе false</returns>
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
