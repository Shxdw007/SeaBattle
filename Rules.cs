using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattleMenu_v._2
{
    public static class Rules
    {
        public static void ShowRules(Menu menuInstance)
        {
            Console.Clear();

            string[] title = new string[]
            {
        "                                   ",
        "████ ████ ████ ████  █  █   ██ ████",
        "█  █ █  █ █  █ █  ██ █  █  █ █ █  █",
        "█  █ ████ ████ ████  █ ██ █  █ ████",
        "█  █ █    █  █ █  ██ ██ █ █  █ █  █",
        "█  █ █    █  █ ████  █  █ █  █ █  █"
            };

            // текущий цвет текста
            ConsoleColor originalForegroundColor = Console.ForegroundColor;

            // красный цвет для заголовка
            Console.ForegroundColor = ConsoleColor.Red;

            for (int i = 0; i < title.Length; i++)
            {
                int centerTitle = (Console.WindowWidth / 2) - (title[i].Length / 2);
                Console.SetCursorPosition(centerTitle, Console.CursorTop);
                Console.WriteLine(title[i]);
            }

            // исходный цвет текста
            Console.ForegroundColor = originalForegroundColor;

            string[] rules = new string[]
            {
        "1. Играют два игрока.",
        "2. У каждого игрока есть игровое поле 10x10 клеток.",
        "3. Игроки по очереди размещают свои корабли на поле.",
        "4. После размещения кораблей игроки начинают стрелять по полю противника.",
        "5. Победителем становится тот игрок, который первым потопит все корабли противника."
            };

            foreach (string rule in rules)
            {
                int centerRule = (Console.WindowWidth / 2) - (rule.Length / 2);
                Console.SetCursorPosition(centerRule, Console.CursorTop + 1);
                Console.WriteLine(rule);
            }

            string returnToMenu = "«Нажмите любую клавишу чтобы вернуться»";
            int centerReturn = (Console.WindowWidth / 2) - (returnToMenu.Length / 2);
            Console.SetCursorPosition(centerReturn, Console.CursorTop + 2);
            Console.WriteLine(returnToMenu);
            Console.ReadKey(true);
        }
    }
}
