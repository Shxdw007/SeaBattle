using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Media;

namespace SeaBattleMenu_v._2
{
    public class Modes
    {

        public static void PC_Icon_Left()
        {
            string PC_Icon =
            @" 
              .----. 
  .---------. | == | 
  |.-.....-.| |----| 
  ||       || | == | 
  ||       || |----| 
  |'-.....-'| |::::| 
  `..)---(..` |___.| 
 /:::::::::::\. _  .  
/:::=======:::\`\`\ 
`..............` '-'";

            // Центрирование изображения по горизонтали
            var xShipPos = (Console.WindowWidth / 2) - (PC_Icon.Split('\n').Max(s => s.Length) / 2) - 24;
            // Размещение выше центра экрана
            var yShipPos = Console.WindowHeight / 2 - 15;

            // Вывод
            foreach (var line in PC_Icon.Split('\n'))
            {
                Console.SetCursorPosition(xShipPos, yShipPos++);

                // Окрас
                foreach (char c in line)
                {
                    if (c == '^' || c == '-')
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(c);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write(c);
                    }
                }
            }

        }


        public static void PC_Icon_Right()
        {
            string PC_Icon =
            @" 
              .----. 
  .---------. | == | 
  |.-.....-.| |----| 
  ||       || | == | 
  ||       || |----| 
  |'-.....-'| |::::| 
  `..)---(..` |___.| 
 /:::::::::::\. _  .  
/:::=======:::\`\`\ 
`..............` '-'";

            // Центрирование изображения по горизонтали
            var xShipPos = (Console.WindowWidth / 2) - (PC_Icon.Split('\n').Max(s => s.Length) / 2) + 30;
            // Размещение выше центра экрана
            var yShipPos = Console.WindowHeight / 2 - 15;

            // Вывод
            foreach (var line in PC_Icon.Split('\n'))
            {
                Console.SetCursorPosition(xShipPos, yShipPos++);

                // Окрас 
                foreach (char c in line)
                {
                    if (c == '^' || c == '-')
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(c);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write(c);
                    }
                }
            }

        }
        public static void Person_Icon_Left()
        {
            string Person_Icon =
    @"                                                                          
      ***        
    *******            
   *********       
/\* ### ### */\  
|    @ / @    |  
\/\    ^    /\/ 
   \  ===  /      
    \_____/          
     _|_|_            
  *$$$$$$$$$*";


            // Центрирование изображения по горизонтали
            var xShipPos = (Console.WindowWidth / 2) - (Person_Icon.Split('\n').Max(s => s.Length) / 2) + 8;
            // Размещение выше центра экрана
            var yShipPos = Console.WindowHeight / 2 - 15;

            // Вывод
            foreach (var line in Person_Icon.Split('\n'))
            {
                Console.SetCursorPosition(xShipPos, yShipPos++);

                // Окрас 
                foreach (char c in line)
                {
                    if (c == '^' || c == '-')
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(c);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write(c);
                    }
                }
            }
        }
        public static void Person_Icon_Right()
        {
            string Person_Icon =
    @"                                                                          
      ***        
    *******            
   *********       
/\* ### ### */\  
|    @ / @    |  
\/\    ^    /\/ 
   \  ===  /      
    \_____/          
     _|_|_            
  *$$$$$$$$$*";


            // Центрирование изображения по горизонтали
            var xShipPos = (Console.WindowWidth / 2) - (Person_Icon.Split('\n').Max(s => s.Length) / 2) + 56;
            // Размещение выше центра экрана
            var yShipPos = Console.WindowHeight / 2 - 15;

            // Вывод
            foreach (var line in Person_Icon.Split('\n'))
            {
                Console.SetCursorPosition(xShipPos, yShipPos++);

                // Окрас 
                foreach (char c in line)
                {
                    if (c == '^' || c == '-')
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(c);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write(c);
                    }
                }
            }

        }
        public static void Versus_Icon()
        {
            string Versus_Icon =
            @"                                                                        
 (   (   (  (        (
 )\  )\ ))\ )(  (   ))\ (            
((_)((_)((_|()\ )\ /((_))\
\ \ / (_))  ((_|(_|_))(((_)   
 \ V // -_)| '_(_-< || (_-<
  \_/ \___||_| /__/\_,_/__/
";

            // Центрирование изображения по горизонтали
            var xShipPos = (Console.WindowWidth / 2) - (Versus_Icon.Split('\n').Max(s => s.Length) / 2) + 25;
            // Размещение выше центра экрана
            var yShipPos = Console.WindowHeight / 2 - 13;
            // Вывод иконки                                                  
            foreach (var line in Versus_Icon.Split('\n'))
            {
                Console.SetCursorPosition(xShipPos, yShipPos++);

                // Окрас иконки versus
                foreach (char c in line)
                {
                    if (c == '^' || c == '-')
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(c);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write(c);
                    }
                }
            }

        }
    }
}
