using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattleMenu_v._2
{
    public class SettingsBoard
    {
        const int BoardSize = 10;
        public static void PrintBoard(char[,] board)
        {
            Console.Clear();
            Console.WriteLine("Текущее состояние поля:");
            Console.WriteLine("Легенда: '-' - пустая клетка, 'S' - корабль");

            // Вывод заголовка с номерами столбцов
            Console.Write("   ");
            for (int i = 0; i < BoardSize; i++)
                Console.Write($"{i + 1} ");
            Console.WriteLine();

            for (int i = 0; i < BoardSize; i++)
            {
                Console.Write($"{i + 1,2} "); // Номер строки
                for (int j = 0; j < BoardSize; j++)
                {
                    Console.Write($"{board[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
