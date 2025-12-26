using System;

/// <summary>
/// Класс, представляющий фигуру "Слон"
/// </summary>
public class Bishop : Piece
{
    /// <summary>
    /// Инициализирует новый экземпляр слона с указанным цветом
    /// </summary>
    /// <param name="color">Цвет фигуры ("White" или "Black")</param>
    public Bishop(string color)
    {
        Color = color;
        Symbol = '♝';
        Type = Pieces.Bishop;
    }

    /// <summary>
    /// Проверяет, может ли слон совершить ход по диагонали
    /// </summary>
    public override bool CanMove(string start, string end, Piece[,] board)
    {
        int startRow = 8 - int.Parse(start[1].ToString());
        int startCol = start[0] - 'A';
        int endRow = 8 - int.Parse(end[1].ToString());
        int endCol = end[0] - 'A';

        // Слон ходит по диагонали, поэтому разница по строкам и столбцам должна быть одинаковой
        if (Math.Abs(startRow - endRow) != Math.Abs(startCol - endCol))
        {
            return false;
        }

        // Проверяем, есть ли фигуры на пути
        int rowStep = Math.Sign(endRow - startRow);
        int colStep = Math.Sign(endCol - startCol);

        int currentRow = startRow + rowStep;
        int currentCol = startCol + colStep;

        while (currentRow != endRow || currentCol != endCol)
        {
            // Эта проверка гарантирует, что мы не выйдем за пределы доски
            if (currentRow < 0 || currentRow >= 8 || currentCol < 0 || currentCol >= 8)
            {
                return false; // Should not happen with valid logic, but as a safeguard
            }

            if (board[currentRow, currentCol] != null)
            {
                return false; // Путь заблокирован
            }
            currentRow += rowStep;
            currentCol += colStep;
        }

        // Проверяем целевую клетку
        Piece destinationPiece = board[endRow, endCol];
        if (destinationPiece == null)
        {
            return true; // Ход на пустую клетку
        }
        if (destinationPiece.Color != this.Color)
        {
            return true; // Взятие фигуры соперника
        }

        return false; // Нельзя ходить на клетку, занятую своей фигурой
    }
}
