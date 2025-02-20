using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Data;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace SeaBattleMenu_v._2
{
    public class Menu
    {
        // Индекс выбранного элемента меню
        private int _selectedIndex = 0;
        private readonly string[] _options = { "Начать игру", "Правила", "Выход" };
        private SoundPlayer _soundSelect;
        private SoundPlayer _soundNavigate;

        public void Run()
        {
            // Инициализация звуков
            InitializeSounds();
            Console.Clear();
            // -курсор
            Console.CursorVisible = false;
            ShipArt();
            while (true)
            {
                // Отрисовывка меню
                DrawMenu();
                // Чтение нажатой клавиши без отображения символа
                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        if (_selectedIndex < _options.Length - 1)
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
                        // Обработка выбора
                        ProcessSelection(_selectedIndex, this);
                        Console.Clear();
                        ShipArt();
                        break;
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

        public void ShipArt()
        {
            string shipArt =
            @"              |    |    |                 
             )_)  )_)  )_)              
            )___))___))___)\            
           )____)____)_____)\\
         _____|____|____|____\\\__
---------\                   /---------
  ^^^^^ ^^^^^^^^^^^^^^^^^^^^^
    ^^^^      ^^^^     ^^^    ^^
         ^^^^      ^^^";

            // Центрирование изображения по горизонтали
            var xShipPos = (Console.WindowWidth / 2) - (shipArt.Split('\n').Max(s => s.Length) / 2);
            // Размещение корабля выше центра экрана
            var yShipPos = Console.WindowHeight / 2 - 10;

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

        public void DrawMenu()
        {
            for (int i = 0; i < _options.Length; i++)
            {
                var option = _options[i];
                // Центрирование текста по горизонтали
                var xPos = (Console.WindowWidth / 2) - (option.Length / 2) - 2;
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
                Console.Write(option);

                if (i == _selectedIndex)
                {
                    Console.SetCursorPosition(xPos + option.Length + 2, yPos);
                    Console.Write(" <");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(xPos + option.Length + 2, yPos);
                    Console.Write("  ");
                }
            }
        }

        private void ProcessSelection(int index, Menu menuInstance)
        {
            switch (index)
            {
                case 0:
                    new GameModeMenu().Run(this);
                    break;
                case 1:
                    Rules.ShowRules(menuInstance);
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}