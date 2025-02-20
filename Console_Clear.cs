using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattleMenu_v._2
{
    public class Console_Clear
    {
        public static void SaveAndClearConsole(int linesToSave)
        {
            List<string> savedLines = new List<string>();

            // Читаем ввод до тех пор, пока пользователь не введет пустую строку
            string input;
            while ((input = Console.ReadLine()) != "")
            {
                if (savedLines.Count >= linesToSave)
                {
                    // Удаляем последнюю строку, если уже достигли лимита
                    savedLines.RemoveAt(savedLines.Count - 1); 
                }
                // Добавляем новую строку в начало списка
                savedLines.Insert(0, input); 
            }

            // Очищаем консоль
            Console.Clear();

            // Выводим сохраненные строки обратно
            foreach (var line in savedLines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
