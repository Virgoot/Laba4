using System;
using System.Data;
using System.Diagnostics;
using System.Runtime;
using System.Security;
using System.Threading.Tasks.Dataflow;

class Program
{
    static void Main()
    {
        bool isRunning = true;

        while (isRunning)
        {
            PrintMenu();

            int userInput;
            bool validMenuChoice = int.TryParse(Console.ReadLine(), out userInput);

            if (validMenuChoice && userInput >= 1 && userInput <= 5)
            {
                switch (userInput)
                {
                    case 1:  
                        FirstCase();
                        break;

                    case 2:
                        
                        SecondCase();
                        
                        break;
                    case 3:
                        
                        ThirdCase();
                        break;   
                        
                    case 4:

                        ChessGame();
                        break;
                        
                    case 5:
                        
                        isRunning = FifthCase();
                        break;      
                }
            }
            else
            {
                Console.WriteLine("Зачем ты вводишь что-то, кроме цифр от 1 до 4?");
            }
        }
    }

    static string PrintArrayInfo(int[] array)
    {
        return "[ " + string.Join(" ", array) + " ]";
    }

    static void PrintMenu()
    {
        Console.WriteLine("1. Отгадать ответ");
        Console.WriteLine("2. Об авторе");
        Console.WriteLine("3. Сортировка массива");
        Console.WriteLine("4. Игра");
        Console.WriteLine("5. Выход");
        Console.WriteLine("Выберите вариант (1-5): ");
    }

    static void FirstCase()
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

    static void SecondCase()
    {
        Console.WriteLine("\n----------------------------------------");
        Console.WriteLine("Кошель Виталий Михайлович / 6106-090301D");
        Console.WriteLine("----------------------------------------\n");
    }

    static void ThirdCase()
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

            int[] arrayForGnomeSort = GetCopyOfArray(array);
            int[] arrayForCocktailSort = GetCopyOfArray(array);






            // Гномья сортировка 
            // -------------------------
            stopwatch.Start();
            GnomeSort(arrayForGnomeSort);
            stopwatch.Stop();
            Console.WriteLine($">> 1.Gnome Sort - Время выполнения сортировки: {stopwatch.Elapsed.TotalMilliseconds} мс\n");
            // -------------------------

            stopwatch.Reset();

            // Сортировка перемешиванием
            // -------------------------

            stopwatch.Start();
            CocktailSort(arrayForCocktailSort);
            stopwatch.Stop();
            Console.WriteLine($">> 2.Cocktail Sort - Время выполнения сортировки: {stopwatch.Elapsed.TotalMilliseconds} мс\n");
            // -------------------------


            // Массив после сортировки
            // -------------------------
            Console.WriteLine("Массив после сортировки:\n");
            if (sizeOfArray <= 10)
            {
                Console.WriteLine("|-------------------------------------------------------------|");
                Console.WriteLine($"   После Gnome Sort: {PrintArrayInfo(arrayForGnomeSort)}");
                Console.WriteLine($"   После Cocktail Sort: {PrintArrayInfo(arrayForCocktailSort)}");
                Console.WriteLine("|-------------------------------------------------------------|\n");
            }
            else
            {
                Console.WriteLine("[ Массивы не могут быть выведены на экран, так как длина массива больше 10 ]\n");
            }


        }


    }

    static string[,] MakeBoard()
    {
        Console.WriteLine("===============================================================\n");
        
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string[,] board = new string[8, 8];

        // Чёрные фигуры
        board[0, 0] = board[0, 7] = "♜";
        board[0, 1] = board[0, 6] = "♞";
        board[0, 2] = board[0, 5] = "♝";
        board[0, 3] = "♛";
        board[0, 4] = "♚";
        for (int i = 0; i < 8; i++) board[1, i] = "♟";

        // Белые фигуры
        board[7, 0] = board[7, 7] = "♖";
        board[7, 1] = board[7, 6] = "♘";
        board[7, 2] = board[7, 5] = "♗";
        board[7, 3] = "♕";
        board[7, 4] = "♔";
        for (int i = 0; i < 8; i++) board[6, i] = "♙";

        for (int r = 2; r < 6; r++)
            for (int c = 0; c < 8; c++)
                board[r, c] = " ";

        for (int i = 0; i < 8; i++)
        {
            for (int h = 0; h < 3; h++)
            {

                if (h == 1)
                {
                    Console.Write($"{8 - i}  ");
                }
                else
                {
                    Console.Write("   ");
                }


                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 0)
                        Console.BackgroundColor = ConsoleColor.White;
                    else
                        Console.BackgroundColor = ConsoleColor.DarkGray;

                    if (h == 1)
                    {
                        string piece = board[i, j];
                        Console.Write($"   {piece}   ");
                    }
                    else
                    {
                        Console.Write("       ");
                    }

                    Console.ResetColor();
                }
                Console.WriteLine();
            }

        }
        Console.WriteLine();
        Console.Write("      A      B      C      D      E      F      G      H");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("===============================================================\n");
        Console.ResetColor();

        return board;
    }




    static void ChessGame()
    {
        int number = 0;
        bool validInput = false;

        while (!validInput)
        {
            Console.WriteLine("За какой цвет вы хотите играть?");
            Console.WriteLine("Белые - 1\nЧёрные - 2");

            string input = Console.ReadLine();

            if (int.TryParse(input, out number) && (number == 1 || number == 2))
            {
                validInput = true;
            }
            else
            {
                Console.WriteLine("\nВведите 1 или 2!\n");
            }
        }

        bool isPlayerWhiteReady = false;
        bool isPlayerBlackReady = false;

        if (number == 1)
        {
            Console.WriteLine("Ваш выбор - белые фигуры");
        }
        else
        {
            Console.WriteLine("Ваш выбор - черные фигуры");
        }

        isPlayerWhiteReady = true;

        // Создание доски йоу

        string[,] board = MakeBoard();
        
        while (isPlayerWhiteReady)
        {
            
        }
        


    }

    static bool FifthCase()
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


    static int[] GetCopyOfArray(int[] array)
    {
        return (int[])array.Clone();
    }
    static void GnomeSort(int[] array)
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

    static void CocktailSort(int[] array)
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
