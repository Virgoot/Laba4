using System;
using System.Diagnostics;

/// <summary>
/// Класс, содержащий методы для работы с массивами
/// </summary>
public class ArrayProcessor
{
    private int size;
    private int[] array;

    /// <summary>
    /// Количество элементов в массиве
    /// </summary>
    public int Size
    {
        get { return size; }
        private set
        {
            if (value <= 0)
                throw new ArgumentException("Размер массива не может быть меньше 1");
            size = value;
        }
    }

    /// <summary>
    /// Массив целых чисел
    /// </summary>
    public int[] Array
    {
        get { return array; }
        private set { array = value; }
    }

    /// <summary>
    /// Конструктор без параметров, создающий массив из 10 элементов
    /// </summary>
    public ArrayProcessor()
    {
        Size = 10;
        InitializeArray();
    }

    /// <summary>
    /// Конструктор с параметром, создающий массив заданного размера
    /// </summary>
    /// <param name="size">Размер массива</param>
    public ArrayProcessor(int size)
    {
        Size = size;
        InitializeArray();
    }

    /// <summary>
    /// Инициализирует массив случайными числами от 0 до 99
    /// </summary>
    private void InitializeArray()
    {
        array = new int[Size];
        Random rnd = new Random();
        for (int i = 0; i < Size; i++)
        {
            array[i] = rnd.Next(0, 100);
        }
    }

    /// <summary>
    /// Выводит массив на экран (если размер не превышает 10)
    /// </summary>
    public void DisplayArray()
    {
        Console.Write("[ ");

        if (Size <= 10)
        {
            for (int i = 0; i < Size; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
        else
        {
            Console.Write("Массив не может быть выведен на экран, так как длина массива больше 10 ");
        }
        Console.WriteLine("]\n");
    }

    /// <summary>
    /// Сортирует массив методом гномьей сортировки
    /// </summary>
    /// <returns>Время выполнения сортировки в миллисекундах</returns>
    public double SortWithGnomeSort()
    {
        int[] arrayCopy = (int[])array.Clone();
        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();
        GnomeSort(arrayCopy);
        stopwatch.Stop();

        array = arrayCopy;
        return stopwatch.Elapsed.TotalMilliseconds;
    }

    /// <summary>
    /// Сортирует массив методом сортировки перемешиванием (шейкерная сортировка)
    /// </summary>
    /// <returns>Время выполнения сортировки в миллисекундах</returns>
    public double SortWithCocktailSort()
    {
        int[] arrayCopy = (int[])array.Clone();
        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();
        CocktailSort(arrayCopy);
        stopwatch.Stop();

        array = arrayCopy;
        return stopwatch.Elapsed.TotalMilliseconds;
    }

    /// <summary>
    /// Реализация гномьей сортировки
    /// </summary>
    /// <param name="array">Массив для сортировки</param>
    private void GnomeSort(int[] array)
    {
        int index = 0;
        while (index < array.Length)
        {
            if (index == 0 || array[index] >= array[index - 1])
            {
                index++;
            }
            else
            {
                int temp = array[index];
                array[index] = array[index - 1];
                array[index - 1] = temp;
                index--;
            }
        }
    }

    /// <summary>
    /// Реализация сортировки перемешиванием
    /// </summary>
    /// <param name="array">Массив для сортировки</param>
    private void CocktailSort(int[] array)
    {
        int left = 0;
        int right = array.Length - 1;
        while (left < right)
        {
            for (int i = left; i < right; i++)
            {
                if (array[i] > array[i + 1])
                {
                    int temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                }
            }
            right--;

            for (int i = right; i > left; i--)
            {
                if (array[i] < array[i - 1])
                {
                    int t = array[i];
                    array[i] = array[i - 1];
                    array[i - 1] = t;
                }
            }
            left++;
        }
    }

    /// <summary>
    /// Находит минимальное значение в массиве
    /// </summary>
    /// <returns>Минимальное значение</returns>
    public int FindMin()
    {
        if (array == null || array.Length == 0)
            throw new InvalidOperationException("Массив не инициализирован.");

        int min = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < min)
            {
                min = array[i];
            }
        }
        return min;
    }

    /// <summary>
    /// Находит максимальное значение в массиве
    /// </summary>
    /// <returns>Максимальное значение</returns>
    public int FindMax()
    {
        if (array == null || array.Length == 0)
            throw new InvalidOperationException("Массив не инициализирован.");

        int max = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
            }
        }
        return max;
    }

    /// <summary>
    /// Вычисляет среднее арифметическое значение элементов массива
    /// </summary>
    /// <returns>Среднее значение</returns>
    public double CalculateAverage()
    {
        if (array == null || array.Length == 0)
            throw new InvalidOperationException("Массив не инициализирован.");

        double sum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }
        return sum / array.Length;
    }
}