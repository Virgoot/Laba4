using System;

/// <summary>
/// Статический класс, содержащий методы для игры по отгадыванию ответа значения функции
/// </summary>
public static class FunctionGame
{
    private const double EPSILON = 0.01;
    private const double PI = Math.PI;

    /// <summary>
    /// Вычисляет значение функции f = sin²(3π/4 + a/3) + √cos(b)
    /// </summary>
    /// <param name="a">Первый аргумент функции</param>
    /// <param name="b">Второй аргумент функции</param>
    /// <returns>Значение функции или double.NaN если вычисление невозможно</returns>
    public static double CalculateFunction(double a, double b)
    {
        double cosB = Math.Cos(b);

        if (cosB >= 0)
        {
            double f = Math.Pow(Math.Sin((3 * PI / 4) + (a / 3)), 2) + Math.Sqrt(cosB);
            return f;
        }
        else
        {
            Console.WriteLine("Ошибка: подкоренное выражение cos(B) < 0, вычисление невозможно.\n");
            return double.NaN;
        }
    }

    /// <summary>
    /// Запускает игру по отгадыванию значения функции
    /// </summary>
    /// <param name="a">Первый аргумент функции</param>
    /// <param name="b">Второй аргумент функции</param>
    public static void PlayGuessingGame(double a, double b)
    {
        double correctAnswer = CalculateFunction(a, b);

        if (double.IsNaN(correctAnswer))
        {
            return;
        }

        for (int i = 3; i != 0; i--)
        {
            Console.Write("Введите предполагаемый ответ: ");
            double guess = InputValidator.GetDouble();

            if (Math.Abs(correctAnswer - guess) < EPSILON)
            {
                Console.WriteLine("Правильный ответ! :)\n");
                return;
            }
            else
            {
                Console.WriteLine("Ваш ответ неправильный :(\n");
            }
        }

        Console.WriteLine($"Результат - {correctAnswer:f2}\n");
    }
}