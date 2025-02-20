using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Media;

namespace SeaBattleMenu_v._2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // вызываем заставку
            ScreenSaver.SplashScreen();

            // запускаем основное меню
            Menu menu = new Menu();
            menu.Run();
        }
    }
}
