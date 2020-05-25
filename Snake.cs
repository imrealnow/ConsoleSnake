using System;
using System.Collections.Generic;

namespace ConsoleSnake
{
    public class Snake
    {
        Grid grid;
        Queue<Vector2> positions = new Queue<Vector2>();
        Vector2 headPosition = new Vector2(25, 25);
        Vector2 applePosition = new Vector2();

        int length = 5;

        public Snake(Grid grid)
        {
            this.grid = grid;
            MoveApple();
        }

        public bool Step(Vector2 direction)
        {
            headPosition.x += direction.x;
            headPosition.y += direction.y;

            grid.ModifyCell(applePosition.x, applePosition.y, true);
            Vector2 normalisedPosition = grid.ModifyCell(headPosition.x, headPosition.y, true);

            if (normalisedPosition.x.Equals(applePosition.x) && normalisedPosition.y.Equals(applePosition.y))
            {
                length++;
                MoveApple();
            }

            // end the game if you collide with yourself
            for (int i = 0; i < positions.Count; i++)
            {
                var positionsArray = positions.ToArray();
                if (normalisedPosition.x.Equals(positionsArray[i].x) && normalisedPosition.y.Equals(positionsArray[i].y))
                {
                    return true;
                }
            }

            positions.Enqueue(new Vector2(normalisedPosition.x, normalisedPosition.y));

            if (positions.Count > length)
            {
                var position = positions.Dequeue();
                grid.ModifyCell(position.x, position.y, false);
            }


            Console.Clear();
            Console.SetCursorPosition(0, 0);
            grid.PrintGrid();

            return false;
        }

        public void MoveApple()
        {
            var rand = new Random();
            applePosition.x = rand.Next(5, grid.columnLength - 5);
            applePosition.y = rand.Next(5, grid.rowLength - 5);

            // if space is occupied, look for another one
            if (grid.QueryCell(applePosition.x, applePosition.y))
            {
                MoveApple();
                return;
            }

            grid.ModifyCell(applePosition.x, applePosition.y, true);
        }
    }
}
