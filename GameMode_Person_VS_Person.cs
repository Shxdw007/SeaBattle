using System;

namespace SeaBattleMenu_v._2
{
    public class GameMode_Person_VS_Person
    {
        const int BoardSize = 10;
        static char[,] player1Board = new char[BoardSize, BoardSize];
        static char[,] player2Board = new char[BoardSize, BoardSize];

        public static void Start_GameMode_Person_VS_Person()
        {
            // Вывод иконок персонажей и версуса
            Modes.Person_Icon_Right();
            Modes.Versus_Icon();
            Modes.Person_Icon_Left();
                                                    
            // Инициализация игровых полей
            SettingBoardPvP.InitializeBoard(player1Board, BoardSize);
            SettingBoardPvP.InitializeBoard(player2Board, BoardSize);

            Console.WriteLine();
            Console.WriteLine("Игрок 1, расставьте корабли.");
            PlaceShipsManually(player1Board);

            // Очистка консоли перед началом расстановки кораблей второго игрока
            Console.Clear();
            Console.WriteLine("Игрок 2, расставьте корабли.");
            PlaceShipsManually(player2Board);

            // Чей ход (true - игрок 1, false - игрок 2)
            bool turnPlayer1 = true;

            while (true)
            {
                Console.Clear();
                Console.WriteLine(turnPlayer1 ? "Ход Игрока 1" : "Ход Игрока 2");

                // Отображение доски противника
                SettingBoardPvP.PrintBoard(turnPlayer1 ? player2Board : player1Board);

                Console.Write("Введите координаты выстрела (строка столбец): ");
                string[] input = Console.ReadLine().Split();
                if (input.Length != 2 || !int.TryParse(input[0], out int row) || !int.TryParse(input[1], out int col) ||
                    row < 1 || row > BoardSize || col < 1 || col > BoardSize)
                {
                    Console.WriteLine("Некорректные координаты! Попробуйте снова.");
                    continue;
                }

                row--; col--;
                char[,] targetBoard = turnPlayer1 ? player2Board : player1Board;

                if (targetBoard[row, col] == 'X' || targetBoard[row, col] == 'O')
                {
                    Console.WriteLine("Вы уже стреляли сюда.");
                    continue;
                }

                // Проверка попадания
                if (targetBoard[row, col] == 'S')
                    // Попадание
                    targetBoard[row, col] = 'X';
                else
                    // Промах
                    targetBoard[row, col] = 'O';

                // Проверка победы
                if (CheckWin(targetBoard))
                {
                    Console.WriteLine(turnPlayer1 ? "Игрок 1 победил!" : "Игрок 2 победил!");
                    break;
                }

                // Передача хода
                turnPlayer1 = !turnPlayer1;
            }
        }

        // Ручное размещение кораблей
        static void PlaceShipsManually(char[,] board)
        {
            // Трёхпалубный корабль
            PlaceShip(board, 3);
            // Двухпалубные корабли
            for (int i = 0; i < 2; i++) PlaceShip(board, 2);
            // Однопалубные корабли
            for (int i = 0; i < 3; i++) PlaceShip(board, 1);
        }

        // Размещение корабля (ручное)
        static void PlaceShip(char[,] board, int size)
        {
            while (true)
            {
                Console.Write($"Введите координаты начала {size}-клеточного корабля (строка столбец): ");
                string[] input = Console.ReadLine().Split();

                if (input.Length != 2 || !int.TryParse(input[0], out int row) || !int.TryParse(input[1], out int col) ||
                    row < 1 || row > BoardSize || col < 1 || col > BoardSize)
                {
                    Console.WriteLine("Некорректные координаты! Попробуйте снова.");
                    continue;
                }

                row--; col--;
                Console.Write("Выберите ориентацию (h - горизонтально, v - вертикально): ");
                char orientation = Console.ReadKey().KeyChar;
                Console.WriteLine();

                bool isHorizontal = orientation == 'h';

                // Проверка возможности размещения корабля
                if (!CanPlaceShip(board, row, col, size, isHorizontal))
                {
                    Console.WriteLine("Невозможно разместить корабль здесь. Попробуйте снова.");
                    continue;
                }

                // Размещение корабля
                for (int i = 0; i < size; i++)
                {
                    int r = isHorizontal ? row : row + i;
                    int c = isHorizontal ? col + i : col;
                    board[r, c] = 'S';
                }

                // Отображение поля после размещения корабля
                SettingBoardPvP.PrintBoard(board);
                break;
            }
        }

        // Проверка возможности размещения корабля
        static bool CanPlaceShip(char[,] board, int row, int col, int size, bool isHorizontal)
        {
            for (int i = 0; i < size; i++)
            {
                int r = isHorizontal ? row : row + i;
                int c = isHorizontal ? col + i : col;

                // Проверка выхода за границы поля
                if (r < 0 || r >= BoardSize || c < 0 || c >= BoardSize)
                    return false;

                // Проверка занятости клеток
                if (board[r, c] != '-')
                    return false;

                // Проверка соседних клеток
                for (int dr = -1; dr <= 1; dr++)
                {
                    for (int dc = -1; dc <= 1; dc++)
                    {
                        int nr = r + dr;
                        int nc = c + dc;
                        if (nr >= 0 && nr < BoardSize && nc >= 0 && nc < BoardSize && board[nr, nc] != '-')
                            return false;
                    }
                }
            }
            return true;
        }

        // Проверка победы
        static bool CheckWin(char[,] board)
        {
            for (int i = 0; i < BoardSize; i++)
                for (int j = 0; j < BoardSize; j++)
                    if (board[i, j] == 'S')
                        return false;
            return true;
        }
    }
}