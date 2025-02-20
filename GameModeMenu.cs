using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace SeaBattleMenu_v._2
{
    public class GameModeMenu
    {
        // Индекс выбранного элемента меню
        private int _selectedIndex = 0;
        // Варианты режима игры
        private readonly string[] _modes = { "PvC", "CvC", "PvP" };
        private SoundPlayer _soundSelect;
        private SoundPlayer _soundNavigate;

        public void Run(Menu mainMenu)
        {
            // Инициализация звуков
            InitializeSounds();
            Console.Clear();
            // Скрытие курсора
            Console.CursorVisible = false;
            // Добавляем рисунок корабля
            ShipArt();

            while (true)
            {
                // Отрисовка меню
                DrawModes();
                // Чтение нажатой клавиши без отображения символа
                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        if (_selectedIndex < _modes.Length - 1)
                        {
                            _selectedIndex++;
                            // Воспроизведение звука при навигации
                            PlaySound(_soundNavigate);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (_selectedIndex > 0)
                        {
                            _selectedIndex--;
                            // Воспроизведение звука при навигации
                            PlaySound(_soundNavigate);
                        }
                        break;
                    case ConsoleKey.Enter:
                        // Воспроизведение звука при выборе
                        PlaySound(_soundSelect);
                        // Запуск игры
                        StartGame(_selectedIndex, mainMenu);
                        // Выход из метода Run
                        return;
                }
            }
        }
        // Метод инициализации звуков
        private void InitializeSounds()
        {
            _soundSelect = new SoundPlayer(@"C:\Users\User\Desktop\Enter.wav");
            _soundNavigate = new SoundPlayer(@"C:\Users\User\Desktop\Switch.wav");
        }
        // Метод воспроизведения звука
        private void PlaySound(SoundPlayer player)
        {
            try
            {
                // Синхронное воспроизведение звука
                player.PlaySync();
            }
            catch
            {
            }
        }

        private void DrawModes()
        {
            for (int i = 0; i < _modes.Length; i++)
            {
                var mode = _modes[i];
                // Центрирование текста по горизонтали
                var xPos = (Console.WindowWidth / 2) - (mode.Length / 2) - 2;
                // Смещение меню
                var yPos = Console.WindowHeight / 2 + i;

                if (i == _selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(xPos, yPos);
                    Console.Write("> ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(xPos, yPos);
                    Console.Write("  ");
                }

                Console.SetCursorPosition(xPos + 2, yPos);
                Console.Write(mode);

                if (i == _selectedIndex)
                {
                    Console.SetCursorPosition(xPos + mode.Length + 2, yPos);
                    Console.Write(" <");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(xPos + mode.Length + 2, yPos);
                    Console.Write("  ");
                }
            }
        }

        public void StartGame(int selectedMode, Menu mainMenu)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            switch (selectedMode)
            {
                case 0:
                    // PvC
                    GameMode_Person_VS_PC.StartGameMode_Person_VS_PC();

                    break;
                case 1:
                    // CvC
                    GameMode_PC_VS_PC.StartGameMode_PC_VS_PC();
                    break;
                case 2:
                    // PvP
                    GameMode_Person_VS_Person.Start_GameMode_Person_VS_Person();

                    break;
            }
            Console.ReadKey();
            // Возвращаемся к основному меню
            mainMenu.Run();
        }

        // Переносим метод ShipArt из класса Menu
        public void ShipArt()
        {
            string shipArt =
            @"               |    |    |                 
              )_)  )_)  )_)              
             )___))___))___)\            
             )____)____)_____)\\
          _____|____|____|____\\\__
----------\                   /---------
  ^^^^^ ^^^^^^^^^^^^^^^^^^^^^
    ^^^^      ^^^^     ^^^    ^^
         ^^^^      ^^^";

            // Центрирование изображения по горизонтали
            var xShipPos = (Console.WindowWidth / 2) - (shipArt.Split('\n').Max(s => s.Length) / 2);
            // Корректировка смещения по вертикали
            var yShipPos = Console.WindowHeight / 2 - 11;

            // Рисование корабля
            foreach (var line in shipArt.Split('\n'))
            {
                Console.SetCursorPosition(xShipPos, yShipPos++);

                // Окрас волн
                foreach (char c in line)
                {
                    if (c == '^' || c == '-')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(c);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write(c);
                    }
                }
            }

            Console.ResetColor();
        }
    }
}
