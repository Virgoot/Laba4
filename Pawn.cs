using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System;

/// <summary>
/// Класс, представляющий пешку в шахматах
/// </summary>
class Pawn : Piece
{
    /// <summary>
    /// Инициализирует новую пешку заданного цвета
    /// </summary>
    /// <param name="color">Цвет пешки ("White" или "Black")</param>
    public Pawn(string color)
    {
        Type = Pieces.Pawn;
        Color = color;
        Symbol = (Color == "White") ? '♟' : '♙';
    }
    /// <summary>
    /// Проверяет возможность хода пешки
    /// </summary>
    /// <param name="start">Начальная позиция</param>
    /// <param name="end">Конечная позиция</param>
    /// <param name="board">Шахматная доска</param>
    /// <returns>true если ход возможен, иначе false</returns>
    public override bool CanMove(string start, string end, Piece[,] board)
    {
        int startRow = 8 - int.Parse(start[1].ToString());
        int startColumn = start[0] - 'A';

        int endRow = 8 - int.Parse(end[1].ToString());
        int endColumn = end[0] - 'A';

        int step = (Color == "White") ? -1 : 1;


        // Обычный ход на 1 клетку вперёд
        if (startColumn == endColumn && endRow == startRow + step)
        {
            if (board[endRow, endColumn] == null) // клетка пуста
            {
                return true;
            }
            else // там стоит любая фигура — нельзя ходить
            {
                Console.WriteLine("Путь заблокирован");
                return false;
            }
        }


        if ((startRow == 6 && Color == "White") || (startRow == 1 && Color == "Black"))
        { 
            if (startColumn == endColumn && endRow == startRow + 2 * step)
            {
                if (board[startRow + step, endColumn] == null && board[endRow, endColumn] == null)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Путь заблокирован");
                    return false;
                }

            }
        }

        if (startColumn == endColumn && Math.Abs(endRow - startRow) > 2)
        {
            Console.WriteLine("Пешка не может идти больше чем на 2 клетки");
            return false;
        }


        if (Math.Abs(startColumn - endColumn) == 1 && endRow == startRow + step)
        {
            if (board[endRow, endColumn] != null && board[endRow, endColumn].Color != Color)
            {
                return true;
            }
                
            else
            {
                Console.WriteLine("Такой ход не разрешен!");
                return false;
            }
        }
       

        Piece target = board[endRow, endColumn];

        if (target != null && target.Color == Color)
        {
            Console.WriteLine("Вы не можете съесть свою фигуру");
            return false;
        }
        
       

        return false;
    }
}