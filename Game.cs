using System;
using Timer = System.Timers.Timer;

namespace ConsoleSnake
{
    class Game
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            const int rows = 15;
            const int columns = 30;

            float timestep = 0.08333f;
            Input input = new Input();

            Vector2 direction = new Vector2(0, 1);
            Vector2 position = new Vector2();

            Grid grid = new Grid(columns, rows);
            Console.SetWindowSize(columns, rows + 1);
            Console.SetBufferSize(columns, rows + 1);

            Snake snek = new Snake(grid);
            bool gameOver = false;

            Timer gameLoop = new Timer(timestep * 1000);

            gameLoop.Elapsed += (sender, e) =>
            {
                gameOver = snek.Step(direction);
                if (gameOver)
                    Environment.Exit(0);
            };

            gameLoop.Start();

            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey();
                var newDirection = input.HandleInput(keyInfo);

                //makes it so it can't do a 180 turn back onto itself
                if ((newDirection.x == 0 && direction.x != 0) || (newDirection.y == 0 && direction.y != 0))
                    direction = newDirection;
            }
            while (keyInfo.Key != ConsoleKey.X && !gameOver);
        }

    }
}
