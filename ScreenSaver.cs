using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeaBattleMenu_v._2
{
    public class ScreenSaver
    {
        public static void SplashScreen()
        {
            string[] str = new string[8];
            str[0] = "  ████████ ████████     ██        ██████       ██     ██████████ ██████████ ██       ████████";
            str[1] = " ██░░░░░░ ░██░░░░░     ████      ░█░░░░██     ████   ░░░░░██░░░ ░░░░░██░░░ ░██      ░██░░░░░ ";
            str[2] = "░██       ░██         ██░░██     ░█   ░██    ██░░██      ░██        ░██    ░██      ░██      ";
            str[3] = "░█████████░███████   ██  ░░██    ░██████    ██  ░░██     ░██        ░██    ░██      ░███████ ";
            str[4] = "░░░░░░░░██░██░░░░   ██████████   ░█░░░░ ██ ██████████    ░██        ░██    ░██      ░██░░░░  ";
            str[5] = "       ░██░██      ░██░░░░░░██   ░█    ░██░██░░░░░░██    ░██        ░██    ░██      ░██      ";
            str[6] = " ████████ ░████████░██     ░██   ░███████ ░██     ░██    ░██        ░██    ░████████░████████";
            str[7] = "░░░░░░░░  ░░░░░░░░ ░░      ░░    ░░░░░░░  ░░      ░░     ░░         ░░     ░░░░░░░░ ░░░░░░░░ ";

            // Проверка существует ли консольное окно
            if (Console.IsOutputRedirected || Console.IsErrorRedirected)
            {
                return;
            }

            // минимально возможные размеры консоли
            const int minWindowWidth = 80;
            const int minWindowHeight = 25;

            int consoleWidth = Math.Max(Console.WindowWidth, minWindowWidth);
            int consoleHeight = Math.Max(Console.WindowHeight, minWindowHeight);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.CursorVisible = false;

            bool skipInitialText = false;

            // быстрое начальное отображение текста
            for (int i = 0; i < str.Length && !skipInitialText; i++)
            {
                // отступ для центрирования строки
                int offset = (consoleWidth - str[i].Length) / 2;

                for (int j = 0; j < str[i].Length && !skipInitialText; j++)
                {
                    if (str[i][j] != ' ')
                    {
                        Console.SetCursorPosition(offset + j, i + 10);
                        Console.Write(str[i][j]);
                        Console.Beep(2000, 15);
                        Thread.Sleep(0);

                        // проверка была ли нажата любая клавиша
                        if (Console.KeyAvailable)
                        {
                            // сброс буфера нажатий
                            Console.ReadKey(true);
                            // оставшийся текст
                            skipInitialText = true;
                        }
                    }
                }
            }

            if (!skipInitialText)
            {
                // переход к новой строке, если текст был выведен полностью
                Console.WriteLine();
            }

            // смена цвета
            for (int i = 0; i < str.Length; i++)
            {
                // Отступ для центрирования строки
                int offset = (consoleWidth - str[i].Length) / 2;

                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(offset, i + 10);
                Console.WriteLine(str[i]);
                Thread.Sleep(35);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(offset, i + 10);
                Console.WriteLine(str[i]);
                Thread.Sleep(35);
            }

            string continueMessage = "«Нажмите любую клавишу чтобы продолжить»";
            int messageLength = continueMessage.Length;
            Console.SetCursorPosition((consoleWidth - messageLength) / 2, consoleHeight - 3);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(continueMessage);

            Console.ReadKey();
        }
    }
}