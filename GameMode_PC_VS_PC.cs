using System;
using System.Threading;

namespace SeaBattleMenu_v._2
{
    public class GameMode_PC_VS_PC
    {
        const int SIZE = 10; // Размер игрового поля (10x10)
        static int lastMessageTop = 0; // Позиция вывода сообщений
        const int topOffset = 5; // Отступ сверху, чтобы поля не прилипали к верхней части консоли

        public static void StartGameMode_PC_VS_PC()
        {
            char[,] board1 = GenerateEmptyBoard();
            char[,] board2 = GenerateEmptyBoard();

            while (true)
            {
                PrintBoards(board1, board2);

                MakeMove(board1, "Компьютер 1");
                Thread.Sleep(1000);

                PrintBoards(board1, board2);

                MakeMove(board2, "Компьютер 2");
                Thread.Sleep(1000);
            }
        }

        static char[,] GenerateEmptyBoard()
        {
            char[,] board = new char[SIZE, SIZE];
            for (int i = 0; i < SIZE; i++)
                for (int j = 0; j < SIZE; j++)
                    board[i, j] = '-';
            return board;
        }

        static void PrintBoards(char[,] board1, char[,] board2)
        {
            Console.Clear();

            int consoleWidth = Console.WindowWidth;
            int boardWidth = SIZE * 2 + 5; // Примерная ширина одного поля
            int totalWidth = boardWidth * 2 + 10; // Общая ширина с отступом

            // Начальная позиция первого поля (центр левой половины экрана)
            int leftBoardPosition = (consoleWidth / 2) - (totalWidth / 2);
            int rightBoardPosition = leftBoardPosition + boardWidth + 10; // Отступ между полями

            // Вывод заголовков (опущены вниз)
            Console.SetCursorPosition(leftBoardPosition, topOffset - 2);
            Console.Write("Компьютер 1");

            Console.SetCursorPosition(rightBoardPosition, topOffset - 2);
            Console.Write("Компьютер 2");

            // Вывод полей
            PrintBoard(board1, leftBoardPosition, topOffset);
            PrintBoard(board2, rightBoardPosition, topOffset);
        }

        static void PrintBoard(char[,] board, int left, int top)
        {
            Console.SetCursorPosition(left, top);
            Console.Write("  ");
            for (int i = 1; i <= SIZE; i++) Console.Write(i + " ");
            Console.WriteLine();

            for (int i = 0; i < SIZE; i++)
            {
                Console.SetCursorPosition(left, top + i + 1);
                Console.Write((i + 1).ToString().PadLeft(2) + " ");
                for (int j = 0; j < SIZE; j++)
                    Console.Write(board[i, j] + " ");
                Console.WriteLine();
            }
        }

        static void MakeMove(char[,] board, string player)
        {
            Random rand = new Random();
            int x, y;

            do
            {
                x = rand.Next(0, SIZE);
                y = rand.Next(0, SIZE);
            } while (board[x, y] == 'X' || board[x, y] == '0');

            bool hit = rand.Next(0, 2) == 0;
            board[x, y] = hit ? 'X' : '0';

            int consoleWidth = Console.WindowWidth;
            int messageLeft = consoleWidth / 2 - 10; // Центр экрана для сообщений
            int messageTop = topOffset + SIZE + 3; // Смещение сообщений вниз

            if (lastMessageTop > 0)
            {
                Console.SetCursorPosition(messageLeft, lastMessageTop);
                Console.Write(new string(' ', 40));
                Console.SetCursorPosition(messageLeft, lastMessageTop + 1);
                Console.Write(new string(' ', 40));
            }

            lastMessageTop = messageTop;
            Console.SetCursorPosition(messageLeft, lastMessageTop);
            Console.Write($"{player} делает ход...");
            Console.SetCursorPosition(messageLeft, lastMessageTop + 1);
            Console.Write(hit ? $"Попадание в ({x + 1}, {y + 1})!" : $"Промах в ({x + 1}, {y + 1}).");
        }
    }
}