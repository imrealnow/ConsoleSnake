using System;

namespace ConsoleSnake
{
    public class Input
    {
        public Vector2 HandleInput(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key.ToString())
            {
                case "UpArrow":
                    return new Vector2(0, -1);
                case "DownArrow":
                    return new Vector2(0, 1);
                case "LeftArrow":
                    return new Vector2(-1, 0);
                case "RightArrow":
                    return new Vector2(1, 0);
            }
            return new Vector2(0, 0);
        }

    }
}
