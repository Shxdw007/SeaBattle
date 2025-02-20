using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeaBattleMenu_v._2
{
    public class GameMode_Person_VS_PC
    {

        // Размер игрового поля (10x10)
        const int BoardSize = 10;

        // Поле игрока
        static char[,] playerBoard = new char[BoardSize, BoardSize];
        // Поле компьютера (скрытое)
        static char[,] computerBoard = new char[BoardSize, BoardSize];
        // Поле компьютера (то, что видит игрок)
        static char[,] computerDisplayBoard = new char[BoardSize, BoardSize];

        // Генератор случайных чисел
        static Random random = new Random();

        public static void StartGameMode_Person_VS_PC()
        {
            // Инициализация пустых полей
            InitializeBoard(playerBoard);
            InitializeBoard(computerBoard);
            InitializeBoard(computerDisplayBoard);

            // Вывод начального состояния поля игрока
            SettingsBoard.PrintBoard(playerBoard);

            // Расстановка кораблей игрока
            Console.WriteLine("\nРасставьте свои корабли:");
            Console.WriteLine("1 корабль (3 клетки), 2 корабля (2 клетки), 3 корабля (1 клетка)");
            PlaceShip(playerBoard, 3, false);
            for (int i = 0; i < 2; i++) PlaceShip(playerBoard, 2, false);
            for (int i = 0; i < 3; i++) PlaceShip(playerBoard, 1, false);

            // Расстановка кораблей компьютера
            Console.WriteLine("\nКомпьютер расставляет корабли...");
            PlaceShip(computerBoard, 3, true);
            for (int i = 0; i < 2; i++) PlaceShip(computerBoard, 2, true);
            for (int i = 0; i < 3; i++) PlaceShip(computerBoard, 1, true);

            // Основной игровой цикл
            bool playerTurn = true;
            while (true)
            {
                Console.Clear();
                PrintGameBoards();

                if (playerTurn)
                {
                    // Ход игрока
                    Console.Write("\nВаш ход (строка столбец): ");
                    string[] input = Console.ReadLine().Split();
                    if (input.Length != 2 || !int.TryParse(input[0], out int row) || !int.TryParse(input[1], out int col) ||
                        row < 1 || row > BoardSize || col < 1 || col > BoardSize)
                    {
                        Console.WriteLine("Некорректные координаты!");
                        continue;
                    }

                    // Преобразуем ввод в индексы массива
                    row--; col--;

                    // Если попали в корабль
                    if (computerBoard[row, col] == 'S')
                    {
                        Console.WriteLine("Попадание!");
                        computerBoard[row, col] = 'X';
                        computerDisplayBoard[row, col] = 'X';
                    }
                    // Если промах
                    else if (computerDisplayBoard[row, col] == '-')
                    {
                        Console.WriteLine("Мимо.");
                        computerDisplayBoard[row, col] = 'O';
                    }
                    else
                    {
                        Console.WriteLine("Вы уже стреляли сюда.");
                        continue;
                    }

                    if (CheckWin(computerBoard)) // Проверяем, не победил ли игрок
                    {
                        Console.Clear();
                        PrintGameBoards();
                        Console.WriteLine("Вы выиграли!");
                        break;
                    }
                }
                else
                {
                    // Ход компьютера
                    int row, col;
                    do
                    {
                        row = random.Next(0, BoardSize);
                        col = random.Next(0, BoardSize);
                    } while (playerBoard[row, col] == 'X' || playerBoard[row, col] == 'O');

                    if (playerBoard[row, col] == 'S')
                    {
                        Console.WriteLine($"Компьютер попал в ({row + 1}, {col + 1})!");
                        playerBoard[row, col] = 'X';
                    }
                    else
                    {
                        Console.WriteLine($"Компьютер промахнулся в ({row + 1}, {col + 1}).");
                        playerBoard[row, col] = 'O';
                    }

                    if (CheckWin(playerBoard)) // Проверяем, не победил ли компьютер
                    {
                        Console.Clear();
                        PrintGameBoards();
                        Console.WriteLine("Компьютер выиграл!");
                        break;
                    }
                }

                // Меняем очередь хода
                playerTurn = !playerTurn;
                Console.ReadKey();
            }
        }

        // Заполняет игровое поле пустыми клетками '-'
        static void InitializeBoard(char[,] board)
        {
            for (int i = 0; i < BoardSize; i++)
                for (int j = 0; j < BoardSize; j++)
                    board[i, j] = '-';
        }

        // Выводит игровое поле игрока и скрытое поле компьютера
        static void PrintGameBoards()
        {
            Console.WriteLine("\nИгрок                        Компьютер");

            // Вывод заголовков столбцов (номера)
            Console.Write("   "); // Отступ для номеров строк игрока
            for (int i = 0; i < BoardSize; i++)
                Console.Write($"{i + 1} "); // Номера столбцов для игрока
            Console.Write("     "); // Пробел между полями
            for (int i = 0; i < BoardSize; i++)
                Console.Write($"{i + 1} "); // Номера столбцов для компьютера
            Console.WriteLine();

            // Вывод строк полей
            for (int i = 0; i < BoardSize; i++)
            {
                // Номер строки для игрока
                Console.Write($"{i + 1,2} "); // Номер строки с выравниванием

                // Вывод клеток поля игрока
                for (int j = 0; j < BoardSize; j++)
                    Console.Write(playerBoard[i, j] + " ");

                Console.Write("     "); // Пробел между полями

                // Номер строки для компьютера
                Console.Write($"{i + 1,2} "); // Номер строки с выравниванием

                // Вывод клеток поля компьютера
                for (int j = 0; j < BoardSize; j++)
                    Console.Write(computerDisplayBoard[i, j] + " ");

                Console.WriteLine();
            }
        }

        // Размещает корабль на поле (проверяя возможность установки)
        static void PlaceShip(char[,] board, int size, bool isComputer)
        {
            while (true)
            {
                int row, col;
                // Случайно определяем ориентацию корабля
                bool isHorizontal = random.Next(2) == 0;

                if (isComputer)
                {
                    row = random.Next(0, BoardSize);
                    col = random.Next(0, BoardSize);
                }
                else
                {
                    Console.Write($"Введите координаты {size}-клеточного корабля (строка столбец): ");
                    string[] input = Console.ReadLine().Split();
                    if (input.Length != 2 || !int.TryParse(input[0], out row) || !int.TryParse(input[1], out col) ||
                        row < 1 || row > BoardSize || col < 1 || col > BoardSize)
                    {
                        Console.WriteLine("Некорректные координаты.");
                        continue;
                    }
                    row--; col--;
                    Console.Write("Выберите ориентацию (h - горизонтально, v - вертикально): ");
                    char orientation = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    if (orientation == 'h') isHorizontal = true;
                    else if (orientation == 'v') isHorizontal = false;
                    else
                    {
                        Console.WriteLine("Некорректный ввод.");
                        continue;
                    }
                }

                if ((isHorizontal && col + size > BoardSize) || (!isHorizontal && row + size > BoardSize))
                {
                    Console.WriteLine("Корабль выходит за границы! Попробуйте снова.");
                    continue;
                }

                if (!CanPlaceShip(board, row, col, size, isHorizontal))
                {
                    Console.WriteLine("Корабль пересекается с другим! Попробуйте снова.");
                    continue;
                }

                for (int i = 0; i < size; i++)
                {
                    int placeRow = isHorizontal ? row : row + i;
                    int placeCol = isHorizontal ? col + i : col;
                    board[placeRow, placeCol] = 'S';
                }

                // Отображаем поле после размещения корабля
                if (!isComputer)
                {
                    SettingsBoard.PrintBoard(board);
                }

                break;
            }
        }   

        // Проверяет, можно ли поставить корабль в указанное место
        static bool CanPlaceShip(char[,] board, int row, int col, int size, bool isHorizontal)
        {
            // Проверка выхода за границы доски
            if (isHorizontal && (col + size > board.GetLength(1)))
                return false;
            else if (!isHorizontal && (row + size > board.GetLength(0)))
                return false;

            // Проверяем каждую клетку корабля
            for (int i = 0; i < size; i++)
            {
                int checkRow = isHorizontal ? row : row + i;
                int checkCol = isHorizontal ? col + i : col;

                // Проверяем саму клетку
                if (board[checkRow, checkCol] == 'S')
                    return false;

                // Проверяем соседей
                for (int rOffset = -1; rOffset <= 1; rOffset++)
                {
                    for (int cOffset = -1; cOffset <= 1; cOffset++)
                    {
                        int neighborRow = checkRow + rOffset;
                        int neighborCol = checkCol + cOffset;

                        // Если координаты выходят за пределы доски, пропускаем их
                        if (neighborRow < 0 || neighborRow >= board.GetLength(0) ||
                            neighborCol < 0 || neighborCol >= board.GetLength(1))
                            continue;

                        // Если соседняя клетка занята кораблем, возвращаем false
                        if (board[neighborRow, neighborCol] == 'S')
                            return false;
                    }
                }
            }

            return true;
        }

        // Проверяет, есть ли еще корабли на поле
        static bool CheckWin(char[,] board)
        {
            foreach (char cell in board) if (cell == 'S') return false;
            return true;
        }


    }
}
