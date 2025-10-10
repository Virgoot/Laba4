using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        bool isRunning = true;

        while (isRunning)
        {
            printMenu();

            int userInput;
            bool validMenuChoice = int.TryParse(Console.ReadLine(), out userInput);

            if (validMenuChoice && userInput >= 1 && userInput <= 5)
            {
                switch (userInput)
                {
                    case 1:
                        {

                            firstCase();

                        }
                        break;

                    case 2:
                        {
                            secondCase();
                        }
                        break;

                    case 3:
                        thirdCase();
                        break;
                    case 4:
                        FourthCase();
                        break;
                    case 5:
                        {
                            isRunning = fifthCase();
                            break;
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine("Зачем ты вводишь что-то, кроме цифр от 1 до 4?");
            }
        }
    }

    static string printArrayInfo(int[] array)
    {
        return "[ " + string.Join(" ", array) + " ]";
    }

    static void printMenu()
    {
        Console.WriteLine("1. Отгадать ответ");
        Console.WriteLine("2. Об авторе");
        Console.WriteLine("3. Сортировка массива");
        Console.WriteLine("4. Игра");
        Console.WriteLine("5. Выход");
        Console.WriteLine("Выберите вариант (1-5): ");
    }

    static void firstCase()
    {
        const double PI = Math.PI;
        const double epsilon = 0.01;

        Console.Write("Введите значение A: ");
        bool validA = double.TryParse(Console.ReadLine(), out double a);

        if (validA)
        {
            Console.Write("Введите значение B: ");
            bool validB = double.TryParse(Console.ReadLine(), out double b);

            if (validB)
            {

                Console.Write("Введите предполагаемый ответ: ");
                double userGuess = double.Parse(Console.ReadLine());

                double cosB = Math.Cos(b);

                if (cosB >= 0)
                {
                    double f = Math.Pow(Math.Sin((3 * PI / 4) + (a / 3)), 2) + Math.Sqrt(cosB);
                    Console.WriteLine($"\nРезультат - {f:F2}");

                    if (Math.Abs(f - userGuess) < epsilon)
                    {
                        Console.WriteLine("Правильный ответ! :)\n");
                    }
                    else
                    {
                        Console.WriteLine("Ваш ответ неправильный :(\n");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: подкоренное выражение cos(B) < 0, вычисление невозможно.\n");
                }
            }
            else
            {

                Console.WriteLine("Ошибка: введите число для B!\n");
            }
        }
        else
        {
            Console.WriteLine("Ошибка: введите число для A!\n");
        }
    }

    static void secondCase()
    {
        Console.WriteLine("\n----------------------------------------");
        Console.WriteLine("Кошель Виталий Михайлович / 6106-090301D");
        Console.WriteLine("----------------------------------------\n");
    }

    static void thirdCase()
    {
        int sizeOfArray;

        Console.Write("Введите размер массива: ");
        bool isSizeValidNumber = int.TryParse(Console.ReadLine(), out sizeOfArray);
        Console.Write("\n");

        if (sizeOfArray <= 0)
        {
            Console.WriteLine("Размер массива не может быть меньше 1! \n");
        }
        else
        {
            int[] array = new int[sizeOfArray];



            // таймер лол
            Stopwatch stopwatch = new Stopwatch();



            // Массив до сортировки


            Console.Write("[ ");

            Random rnd = new Random();
            for (int i = 0; i < sizeOfArray; i++)
            {
                array[i] = rnd.Next(0, 100);
            }
            if (sizeOfArray <= 10)
            {
                for (int i = 0; i < sizeOfArray; i++)
                {
                    Console.Write(array[i] + " ");
                }
            }
            else
            {
                Console.Write("Массивы не могут быть выведены на экран, так как длина массива больше 10 ");
            }
            Console.WriteLine("]\n");

            int[] arrayForGnomeSort = getCopyOfArray(array);
            int[] arrayForCocktailSort = getCopyOfArray(array);






            // Гномья сортировка 
            // -------------------------
            stopwatch.Start();
            gnomeSort(arrayForGnomeSort);
            stopwatch.Stop();
            Console.WriteLine($">> 1.Gnome Sort - Время выполнения сортировки: {stopwatch.Elapsed.TotalMilliseconds} мс\n");
            // -------------------------

            stopwatch.Reset();

            // Сортировка перемешиванием
            // -------------------------

            stopwatch.Start();
            cocktailSort(arrayForCocktailSort);
            stopwatch.Stop();
            Console.WriteLine($">> 2.Cocktail Sort - Время выполнения сортировки: {stopwatch.Elapsed.TotalMilliseconds} мс\n");
            // -------------------------


            // Массив после сортировки
            // -------------------------
            Console.WriteLine("Массив после сортировки:\n");
            if (sizeOfArray <= 10)
            {
                Console.WriteLine("|-------------------------------------------------------------|");
                Console.WriteLine($"   После Gnome Sort: {printArrayInfo(arrayForGnomeSort)}");
                Console.WriteLine($"   После Cocktail Sort: {printArrayInfo(arrayForCocktailSort)}");
                Console.WriteLine("|-------------------------------------------------------------|\n");
            }
            else
            {
                Console.WriteLine("[ Массивы не могут быть выведены на экран, так как длина массива больше 10 ]\n");
            }


        }


    }
    
    static void FourthCase()
    {
        char[,] board = new char[8, 8];

        for (int row = 0; row < 8; row++)
        {
            // Верхняя рамка строки
            Console.Write("+--+--+--+--+--+--+--+--+\n");

            for (int col = 0; col < 8; col++)
                Console.Write($"| {board[row, col]} ");

            Console.Write("|\n");
        }
        // Нижняя рамка после последней строки
        Console.Write("+--+--+--+--+--+--+--+--+\n");
    }

    static bool fifthCase()
    {
        Console.WriteLine("Вы уверены?: (д/н)");
        string userAnswer = Console.ReadLine();

        if (userAnswer == "д")
        {
            return false;
        }
        else if (userAnswer != "н")
        {
            Console.WriteLine("Некорректный ввод! Возвращаю в меню");
        }

        return true;
    }


    static int[] getCopyOfArray(int[] array)
    {
        return (int[])array.Clone();
    }
    static void gnomeSort(int[] array)
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

    static void cocktailSort(int[] array)
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
        


}
