using System;
using System.Dynamic;

/// <summary>
/// Абстрактный базовый класс для всех шахматных фигур
/// </summary>
/// <remarks>
/// Этот класс определяет общие свойства и методы для всех шахматных фигур
/// </remarks>
public abstract class Piece
{
    /// <summary>
    /// Тип шахматной фигуры из перечисления Pieces
    /// </summary>
    public Pieces Type { get; set; }
    /// <summary>
    /// Цвет фигуры: "White" (белые) или "Black" (черные)
    /// </summary>
    public string Color { get; set; }
    /// <summary>
    /// Юникод-символ для графического представления фигуры
    /// </summary>
    public char Symbol { get; set; }

    /// <summary>
    /// Абстрактный метод для проверки возможности хода фигуры
    /// </summary>
    /// <param name="start">Начальная позиция фигуры в шахматной нотации</param>
    /// <param name="end">Целевая позиция фигуры в шахматной нотации</param>
    /// <param name="board">Двумерный массив, представляющий текущее состояние шахматной доски</param>
    /// <returns>true если фигура может совершить указанный ход, иначе false</returns>
    public abstract bool CanMove(string start, string end, Piece[,] board);
}