using System;
using System.Text.RegularExpressions;

/// <summary>
/// Статический класс, содержащий методы для проверки вводимых данных
/// </summary>
public static class InputValidator
{
    /// <summary>
    /// Получает от пользователя целое число
    /// </summary>
    /// <returns>Введенное целое число</returns>
    public static int GetInt()
    {
        int value;
        while (!int.TryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine("Не число. Попробуйте снова: ");
        }
        return value;
    }

    /// <summary>
    /// Получает от пользователя целое число в заданном диапазоне
    /// </summary>
    /// <param name="min">Минимальное допустимое значение</param>
    /// <param name="max">Максимальное допустимое значение</param>
    /// <returns>Введенное целое число</returns>
    public static int GetIntInRange(int min, int max)
    {
        int value;
        while (true)
        {
            value = GetInt();
            if (value >= min && value <= max)
                return value;
            Console.WriteLine($"Число должно быть в диапазоне от {min} до {max}. Попробуйте снова: ");
        }
    }

    /// <summary>
    /// Получает от пользователя число с плавающей точкой
    /// </summary>
    /// <returns>Введенное число с плавающей точкой</returns>
    public static double GetDouble()
    {
        double value;
        while (!double.TryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine("Не число. Попробуйте снова: ");
        }
        return value;
    }

    /// <summary>
    /// Получает от пользователя строку, соответствующую шаблону шахматной клетки (A1-H8)
    /// </summary>
    /// <param name="message">Сообщение для пользователя</param>
    /// <returns>Введенная строка в верхнем регистре</returns>
    public static string GetChessCell(string message)
    {
        Regex validCell = new Regex("^[A-H][1-8]$");
        string cell;

        while (true)
        {
            Console.WriteLine(message);
            cell = Console.ReadLine().ToUpper();

            if (validCell.IsMatch(cell))
            {
                return cell;
            }
            Console.WriteLine("Неверный ввод! Введите клетку в формате буква(А-H) + цифра(1-8).");
        }
    }

    /// <summary>
    /// Получает от пользователя подтверждение (д/н)
    /// </summary>
    /// <param name="message">Сообщение для пользователя</param>
    /// <returns>true если пользователь ответил 'д', false если 'н'</returns>
    public static bool GetConfirmation(string message)
    {
        Console.WriteLine(message);
        string answer = Console.ReadLine().ToLower();

        while (answer != "д" && answer != "н")
        {
            Console.WriteLine("Некорректный ввод! Введите 'д' или 'н': ");
            answer = Console.ReadLine().ToLower();
        }

        return answer == "д";
    }
}