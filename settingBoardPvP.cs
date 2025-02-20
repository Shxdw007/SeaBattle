using System;

public static class SettingBoardPvP
{
    // Инициализация игрового поля
    public static void InitializeBoard(char[,] board, int boardSize)
    {
        for (int i = 0; i < boardSize; i++)
        {
            for (int j = 0; j < boardSize; j++)
            {
                // Заполняем поле пустыми символами
                board[i, j] = '-';
            }
        }
    }

    // Вывод игрового поля
    public static void PrintBoard(char[,] board)
    {
        const int BoardSize = 10;

        Console.Clear();
        Console.WriteLine("Текущее состояние поля:");
        Console.WriteLine("Легенда: '-' - пустая клетка, 'S' - корабль");

        // Вывод заголовка с номерами столбцов
        // Отступ слева
        Console.Write("   "); 
       
        for (int i = 1; i <= BoardSize; i++)
        {
            // Форматируем числа с выравниванием по левому краю
            Console.Write($"{i,-2}");
        }
        Console.WriteLine();

        // Вывод строк с номерами и содержимым ячеек
        for (int i = 0; i < BoardSize; i++)
        {
            // Номер строки с выравниванием по правому краю   
            Console.Write($"{i + 1,2} ");
            for (int j = 0; j < BoardSize; j++)
            {
                // Содержимое ячейки
                Console.Write($"{board[i, j]} "); 
            }
            Console.WriteLine();
        }
    }
}
