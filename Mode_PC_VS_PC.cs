using System;
using System.Threading;

class BattleshipAIvsAI
{
    const int SIZE = 10;
    static int lastMessageTop = 0;

    static void Main()
    {
        int consoleWidth = Console.WindowWidth;
        int boardWidth = SIZE * 2 + 5; // Ширина одного поля
        int padding = (consoleWidth - (boardWidth * 2)) / 4; // Отступ между элементами

        char[,] board1 = GenerateEmptyBoard();
        char[,] board2 = GenerateEmptyBoard();

        while (true)
        {
            PrintBoardsWithArt(board1, board2, padding);
            MakeMove(board1, "Компьютер 1", padding);
            Thread.Sleep(1000);
            PrintBoardsWithArt(board1, board2, padding);
            MakeMove(board2, "Компьютер 2", padding + boardWidth + padding);
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

    static void PrintBoardsWithArt(char[,] board1, char[,] board2, int padding)
    {
        Console.SetCursorPosition(0, 0);

        // Верхний арт
        PrintTopArt();

        // Смещение вниз для арта и полей
        int artOffset = 8;
        PrintAsciiArt(padding, artOffset);
        PrintAsciiArt(padding + SIZE * 2 + 5 + padding, artOffset);

        int boardOffset = artOffset + 6;
        PrintBoard(board1, padding, boardOffset);
        PrintBoard(board2, padding + SIZE * 2 + 5 + padding, boardOffset);

        // Нижний арт по центру
        int bottomArtLeft = Math.Max(0,(Console.WindowWidth - 20) / 2); // Центрирование
        PrintBottomArt(boardOffset + SIZE + 4, bottomArtLeft);
    }

    static void PrintTopArt()
    {
        Console.WriteLine("  (   (   (  (        (      ");
        Console.WriteLine(" )\\  )\\ ))\\ )(  (   ))\\ (    ");
        Console.WriteLine("((_)((_)((_|()\\ )\\ /((_))\\   ");
        Console.WriteLine("\\ \\ / (_))  ((_|(_|_))(((_) ");
        Console.WriteLine(" \\ V // -_)| '_(_-< || (_-<  ");
        Console.WriteLine("  \\_/ \\___||_| /__/_/\\_,_/__/ ");
        Console.WriteLine();
    }

    static void PrintBottomArt(int top, int left)
    {
        Console.SetCursorPosition(left, top);
        Console.WriteLine(" _______           _______ ");
        Console.SetCursorPosition(left, top + 1);
        Console.WriteLine("(  ____ \\|\\     /|(  ____ \\");
        Console.SetCursorPosition(left, top + 2);
        Console.WriteLine("| (    \\/| )   ( || (    \\/");
        Console.SetCursorPosition(left, top + 3);
        Console.WriteLine("| |      | |   | || |       ");
        Console.SetCursorPosition(left, top + 4);
        Console.WriteLine("| |      ( (   ) )| |       ");
        Console.SetCursorPosition(left, top + 5);
        Console.WriteLine("| |       \\ \\_/ / | |       ");
        Console.SetCursorPosition(left, top + 6);
        Console.WriteLine("| (____/\\  \\   /  | (____/\\");
        Console.SetCursorPosition(left, top + 7);
        Console.WriteLine("(_______/   \\_/   (_______/");
    }

    static void PrintAsciiArt(int left, int top)
    {
        Console.SetCursorPosition(left, top);
        Console.WriteLine("      _____");
        Console.SetCursorPosition(left, top + 1);
        Console.WriteLine("     | . . |");
        Console.SetCursorPosition(left, top + 2);
        Console.WriteLine("  [] | --- | []");
        Console.SetCursorPosition(left, top + 3);
        Console.WriteLine("     |_____|");
        Console.SetCursorPosition(left, top + 4);
        Console.WriteLine("      /   \\");
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
            Console.Write((i + 1) + " ");
            for (int j = 0; j < SIZE; j++)
                Console.Write(board[i, j] + " ");
            Console.WriteLine();
        }
    }

    static void MakeMove(char[,] board, string player, int left)
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

        // Очистка старого текста хода
        if (lastMessageTop > 0)
        {
            Console.SetCursorPosition(left, lastMessageTop);
            Console.Write(new string(' ', 40)); // Затирание старого текста
            Console.SetCursorPosition(left, lastMessageTop + 1);
            Console.Write(new string(' ', 40));
        }

        // Вывод нового хода
        lastMessageTop = SIZE + 12;
        Console.SetCursorPosition(left, lastMessageTop);
        Console.Write($"{player} делает ход...");
        Console.SetCursorPosition(left, lastMessageTop + 1);
        Console.Write(hit ? $"Попадание в ({x + 1}, {y + 1})!" : $"Промах в ({x + 1}, {y + 1}).");
    }
}