using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Pipes;
using System.Net;
using System.Runtime;
using System.Security;
using System.Threading.Tasks.Dataflow;
using System.Text.RegularExpressions;
using System.Diagnostics.Contracts;

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


    static double DoubleInput()
    {
        double value;
        while (!double.TryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine("Не число");
        }
        return value;
    }

    static int IntInput()
    {
        int value;
        while (!int.TryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine("Не число");
        }
        return value;
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

    
    static void Guesser(double f)
    {
        const double EPSILON = 0.01;

        for (int i = 3; i != 0; i--)
        {
            Console.Write("Введите предполагаемый ответ: ");
            double guess = DoubleInput();

            if (Math.Abs(f - guess) < EPSILON)
            {
                Console.WriteLine("Правильный ответ! :)\n");
                return;
            }
            else
            {
                Console.WriteLine("Ваш ответ неправильный :(\n");
            }
        }
    }

    static double Function(double a, double b)
    {
        const double PI = Math.PI;

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

    static void FirstCase()
    {
        Console.Write("Введите значение A: ");
        double a = DoubleInput();

        Console.Write("Введите значение B: ");
        double b = DoubleInput();


        double f = Function(a, b);

        if (double.IsNaN(f))
        {          
            return;
        }   
        

        Guesser(f);

        Console.WriteLine($"Результат - {f:f2}\n");
    }



    static void SecondCase()
    {
        Console.WriteLine("\n----------------------------------------");
        Console.WriteLine("Кошель Виталий Михайлович / 6106-090301D");
        Console.WriteLine("----------------------------------------\n");
    }

    static int EnterSizeOfArray()
    {
        Console.Write("Введите размер массива: ");
        int sizeOfArray = IntInput();
        Console.Write("\n");

        while (sizeOfArray <= 0)
        {
            Console.WriteLine("Размер массива не может быть меньше 1! \n");
            sizeOfArray = IntInput();
        }
        
        return sizeOfArray;
    }
    
    static int[] CreateArray(int size)
    {
        int[] array = new int[size];

        Random rnd = new Random();
        for (int i = 0; i < size; i++)
        {
            array[i] = rnd.Next(0, 100);
        }


        return array;
    }

    static void ShowArray(int[] array)
    {
        Console.Write("[ ");

        if (array.Length <= 10)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
        else
        {
            Console.Write("Массивы не могут быть выведены на экран, так как длина массива больше 10 ");
        }
        Console.WriteLine("]\n");
    }

    static void ThirdCase()
    {

        int sizeOfArray = EnterSizeOfArray();
        
        
        int[] array = CreateArray(sizeOfArray);

        ShowArray(array);


        // таймер лол
        Stopwatch stopwatch = new Stopwatch();

        // Массив до сортировки

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
        
        Console.WriteLine("|-------------------------------------------------------------|");
        Console.WriteLine($"   После Gnome Sort: ");
        ShowArray(arrayForGnomeSort);
        Console.WriteLine($"   После Cocktail Sort: ");
        ShowArray(arrayForCocktailSort);
        Console.WriteLine("|-------------------------------------------------------------|\n");
    }

    static Piece[,] CreateBoard()
    {
        
        Piece?[,] board = new Piece?[8, 8];


        board[7, 0] = board[7, 7] = new Rook("White");
        board[7, 1] = board[7, 6] = new Knight("White");
        board[7, 2] = board[7, 5] = new Bishop("White");
        board[7, 3] = new Queen("White");
        board[7, 4] = new King("White");
        for (int i = 0; i < 8; i++) board[6, i] = new Pawn("White");

        board[0, 0] = board[0, 7] = new Rook("Black");
        board[0, 1] = board[0, 6] = new Knight("Black");
        board[0, 2] = board[0, 5] = new Bishop("Black");
        board[0, 3] = new Queen("Black");
        board[0, 4] = new King("Black");
        for (int i = 0; i < 8; i++) board[1, i] = new Pawn("Black");

        for (int r = 2; r < 6; r++)
            for (int c = 0; c < 8; c++)
                board[r, c] = null;


        return board;
    }

    static void  DrawBoard(Piece[,] board)
    {
        Console.WriteLine("===============================================================\n");

        Console.OutputEncoding = System.Text.Encoding.UTF8;

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
                        Piece piece = board[i, j];

                        if (piece != null)
                        {
                            Console.Write($"   {piece.Symbol}   ");
                        }
                        else
                        {
                            Console.Write("       ");
                        }
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
    }        


   static string MoveInput(string message)
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


    static bool CheckMove(Piece selected, string currentColor, string start, string end, Piece[,] board)
    {
        if (selected == null)
        {
            Console.WriteLine("В этой клетке нет фигуры!");
            return false;
        }
        if (selected.Color != currentColor)
        {
            Console.WriteLine("Вы не можете ходить чужой фигурой!");
            return false;
        }
        if (!selected.CanMove(start, end, board))
        {
            Console.WriteLine("Фигура не может так ходить!");
            return false;
        }
        return true;
    }

    static (int row, int col)? FindKing(Piece[,] board, string color)
    {
        for (int r = 0; r < 8; r++)
        {
            for (int c = 0; c < 8; c++)
            {
                if (board[r, c] != null && 
                    board[r, c].Type == Pieces.King && 
                    board[r, c].Color == color)
                {
                    return (r, c);
                }
            }
        }
        return null;
    }

    static bool IsKingChecked(Piece[,] board, string color)
    {
        var kingPos = FindKing(board, color);
        if (kingPos == null) return false;

        int kingRow = kingPos.Value.row;
        int kingCol = kingPos.Value.col;

        string enemy = color == "White" ? "Black" : "White";

        for (int r = 0; r < 8; r++)
        {
            for (int c = 0; c < 8; c++)
            {
                Piece piece = board[r, c];

                if (piece != null && piece.Color == enemy)
                {
                    string start = $"{(char)('A' + c)}{8 - r}";
                    string end   = $"{(char)('A' + kingCol)}{8 - kingRow}";

                    if (piece.CanMove(start, end, board))
                        return true;
                }
            }
        }

        return false;
    }

    static bool IsCheckmate(Piece[,] board, string color)
    {
        if (!IsKingChecked(board, color)) return false;

        for (int r = 0; r < 8; r++)
        {
            for (int c = 0; c < 8; c++)
            {
                Piece piece = board[r, c];
                if (piece == null || piece.Color != color) continue;

                string start = $"{(char)('A' + c)}{8 - r}";

                for (int rr = 0; rr < 8; rr++)
                {
                    for (int cc = 0; cc < 8; cc++)
                    {
                        string end = $"{(char)('A' + cc)}{8 - rr}";

                        if (!piece.CanMove(start, end, board)) continue;

                        Piece[,] clone = (Piece[,])board.Clone();
                        clone[rr, cc] = clone[r, c];
                        clone[r, c] = null;

                        if (!IsKingChecked(clone, color))
                            return false;
                    }
                }
            }
        }

        return true; 
    }


    static void ChessGame()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Piece[,] board = CreateBoard();
        bool whiteTurn = true;

        while (true)
        {
            DrawBoard(board);

            string currentColor = whiteTurn ? "White" : "Black";

            string opponentColor = whiteTurn ? "Black" : "White";


            string start = MoveInput($"{currentColor} ходят. Укажите фигуру (например A2): ");
            string end = MoveInput("Укажите куда хотите походить (например A4): ");


            

            int startRow = 8 - int.Parse(start[1].ToString());
            int startCol = start[0] - 'A';
            int endRow = 8 - int.Parse(end[1].ToString());
            int endCol = end[0] - 'A';

            Piece selected = board[startRow, startCol];

            if (!CheckMove(selected, currentColor, start, end, board))
            {
                continue;
            }
                        

            Piece backup = board[endRow, endCol];
            board[endRow, endCol] = board[startRow, startCol];
            board[startRow, startCol] = null;

            if (IsKingChecked(board, currentColor))
            {
                Console.WriteLine("НЕЛЬЗЯ так ходить — ваш король будет под шахом!");
                board[startRow, startCol] = selected;
                board[endRow, endCol] = backup;
                continue;
            }


            if (IsKingChecked(board, opponentColor))
            {
                Console.WriteLine($"{opponentColor} под шахом!");
            }

            if (IsCheckmate(board, opponentColor))
            {
                DrawBoard(board);
                Console.WriteLine($"МАТ! {currentColor} победили!");
                break;
            }

            whiteTurn = !whiteTurn;


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
        int[] copiedArr = new int[array.Length];

        for (int i = 0; i < array.Length; i++)
        {
            copiedArr[i] = array[i];
        }
        return copiedArr;
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
